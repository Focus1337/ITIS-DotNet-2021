import { Injectable } from '@nestjs/common';
import { CriminalRecord } from '@/api/questionnaire/questionnaire.entity';

@Injectable()
export class CriminalStatusVerification {
  public async verifyCriminalStatus(
    passportSeries: number,
    passportNumber: number,
    criminalRecord: boolean,
  ): Promise<boolean> {
    return (
      ((passportNumber + passportSeries + new Date(Date.now()).getSeconds()) %
        2 ==
        0) ==
      criminalRecord
    );
  }
}
