import { Module } from '@nestjs/common';
import { CreditRateService } from './credit-rate.service';

@Module({
  providers: [CreditRateService],
  exports: [CreditRateService],
})
export class CreditRateModule {}
