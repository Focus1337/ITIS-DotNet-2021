import { Injectable } from '@nestjs/common';
import {
  CriminalRecord,
  Employment,
  Goal,
  OtherLoans,
  Pledge,
  Questionnaire,
} from '@/api/questionnaire/questionnaire.entity';

@Injectable()
export class CreditScoreService {
  public calculateScore(questionnaire: Questionnaire): number {
    const {
      age,
      criminalRecord,
      sum,
      goal,
      employment,
      otherLoans,
      pledge,
      carAge,
    }: Questionnaire = questionnaire;

    let score = 0;

    // Баллы после учёта возраста
    if (age >= 21 && age <= 28) {
      if (sum < 1000000) {
        score += 12;
      } else {
        if (sum < 3000000) {
          score += 9;
        } else {
          score += 0;
        }
      }
    } else if (age >= 29 && age <= 59) {
      score += 14;
    } else if (age >= 60 && age <= 72) {
      if (pledge != Pledge.NonPledge) {
        score += 8;
      } else {
        score += 0;
      }
    } else {
      score += 0;
    }

    // Баллы после учёта сведений об учёте
    if (criminalRecord == CriminalRecord.Yes) {
      score += 0;
    } else {
      score += 15;
    }

    // Баллы после учёта трудоустройства
    switch (employment) {
      case Employment.Unemployed:
        score += 0;
        break;
      case Employment.Individual:
        score += 12;
        break;
      case Employment.Contract:
        score += 14;
        break;
      case Employment.Freelancer:
        score += 8;
        break;
      case Employment.Pensioner:
        if (age < 70) {
          score += 5;
        } else {
          score += 0;
        }
        break;
      default:
        throw new Error('bad request: employment');
    }

    // Баллы после учёта цели
    switch (goal) {
      case Goal.Consumer:
        score += 14;
        break;
      case Goal.RealEstate:
        score += 8;
        break;
      case Goal.OnLending:
        score += 12;
        break;
      default:
        throw new Error('bad request: goal');
    }

    // Баллы после учёта залога
    switch (pledge) {
      case Pledge.RealEstate:
        score += 14;
        break;
      case Pledge.Car:
        score += carAge < 3 ? 8 : 3;
        break;
      case Pledge.Guarantee:
        score += 12;
        break;
      case Pledge.NonPledge:
        score += 0;
        break;
      default:
        throw new Error('bad request: pledge');
    }

    // Баллы после учёта наличия других кредитов
    if (otherLoans == OtherLoans.Yes) {
      score += 0;
    } else {
      if (goal == Goal.OnLending) {
        score += 0;
      } else {
        score += 15;
      }
    }

    // Баллы после учёта предполагаемой суммы для взятия кредита
    if (sum >= 0 && sum <= 1000000) score += 12;
    else if (sum <= 5000000) score += 14;
    else if (sum <= 10000000) score += 8;
    else score += 0;

    return score;
  }
}
