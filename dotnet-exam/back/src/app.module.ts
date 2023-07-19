import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { QuestionnaireModule } from './api/questionnaire/questionnaire.module';
import { getEnvPath } from './common/helper/env.helper';
import { ConfigModule } from '@nestjs/config';
import { CreditRateModule } from './api/credit-rate/credit-rate.module';
import { CreditScoreModule } from '@/api/credit-score/credit-score.module';
import { CriminalStatusModule } from '@/external-services/criminal-status.module';

const envFilePath: string = getEnvPath(`${__dirname}/common/envs`);

@Module({
  imports: [
    QuestionnaireModule,
    CreditRateModule,
    CreditScoreModule,
    CriminalStatusModule,
    ConfigModule.forRoot({ envFilePath, isGlobal: true }),
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
