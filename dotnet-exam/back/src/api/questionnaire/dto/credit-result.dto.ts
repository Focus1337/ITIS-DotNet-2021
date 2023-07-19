import { IsBoolean, IsNotEmpty, IsNumber, IsString } from 'class-validator';

export class CreditResultDto {
  @IsNumber()
  @IsNotEmpty()
  public Score: number;

  @IsNumber()
  @IsNotEmpty()
  public creditRate: number;

  @IsBoolean()
  @IsNotEmpty()
  public Result: boolean;

  @IsString()
  @IsNotEmpty()
  public Message: string;
}
