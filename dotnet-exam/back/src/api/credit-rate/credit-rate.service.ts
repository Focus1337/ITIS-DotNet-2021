import { Injectable } from '@nestjs/common';

@Injectable()
export class CreditRateService {
  public calculateRate(score: number): number {
    if (score >= 100) return 12.5;
    if (score >= 96) return 15;
    if (score >= 92) return 19;
    if (score >= 88) return 22;
    if (score >= 84) return 26;
    if (score >= 80) return 30;

    throw new Error('Score less than 80');
  }
}
