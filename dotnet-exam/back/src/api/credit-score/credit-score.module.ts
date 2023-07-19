import { Module } from '@nestjs/common';
import { CreditScoreService } from '@/api/credit-score/credit-score.service';

@Module({
  providers: [CreditScoreService],
  exports: [CreditScoreService],
})
export class CreditScoreModule {}
