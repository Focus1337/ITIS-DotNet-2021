import { Body, Controller, Get, Header, Inject, Post } from '@nestjs/common';
import { CreditResultDto } from './dto/credit-result.dto';
import { QuestionnaireService } from './questionnaire.service';
import { Questionnaire } from './questionnaire.entity';

@Controller('credit')
export class QuestionnaireController {
  @Inject(QuestionnaireService)
  private readonly service: QuestionnaireService;

  // @Get()
  // @Header('X-Total-Count', '5')
  // @Header('Access-Control-Expose-Headers', 'X-Total-Count')
  // public async getAll(): Promise<Questionnaire[]> {
  //   return this.service.getAll();
  // }

  @Post('getCredit')
  public getCredit(@Body() body: Questionnaire): Promise<CreditResultDto> {
    return this.service.getCredit(body);
  }
}
