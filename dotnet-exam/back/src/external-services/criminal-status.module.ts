import { Module } from '@nestjs/common';
import { CriminalStatusVerification } from '@/external-services/criminal-status.verification';

@Module({
  providers: [CriminalStatusVerification],
  exports: [CriminalStatusVerification],
})
export class CriminalStatusModule {}
