import {
  IsBoolean,
  IsDateString,
  IsEnum,
  IsInt,
  IsNotEmpty,
  IsNumber,
  IsString,
  Length,
  Max,
  MaxLength,
  Min,
} from 'class-validator';

export enum Employment {
  Unemployed = 'Unemployed',
  Contract = 'Contract',
  Individual = 'Individual',
  Freelancer = 'Freelancer',
  Pensioner = 'Pensioner',
}

export enum Goal {
  Consumer = 'Consumer',
  RealEstate = 'RealEstate',
  OnLending = 'OnLending',
}

export enum Pledge {
  NonPledge = 'NonPledge',
  RealEstate = 'RealEstate',
  Car = 'Car',
  Guarantee = 'Guarantee',
}

export enum OtherLoans {
  Yes = 'Yes',
  No = 'No',
}

export enum CriminalRecord {
  Yes = 'Yes',
  No = 'No',
}

export class Questionnaire {
  @IsString()
  @IsNotEmpty()
  @MaxLength(100)
  public fullName: string;

  @IsString()
  @IsNotEmpty()
  @Length(4, 4)
  public passportSeries?: string;

  @IsString()
  @IsNotEmpty()
  @Length(6, 6)
  public passportNumber?: string;

  @IsString()
  @IsNotEmpty()
  @Length(10, 40)
  public passportGiven: string;

  @IsDateString()
  @IsNotEmpty()
  public passportGivenDate?: Date;

  @IsString()
  @IsNotEmpty()
  @Length(5, 40)
  public passportRegistration: string;

  @IsNumber()
  @IsNotEmpty()
  @Min(18)
  @Max(100)
  public age?: number;

  @IsEnum(CriminalRecord)
  @IsNotEmpty()
  public criminalRecord: CriminalRecord;

  @IsNumber()
  @IsNotEmpty()
  @Min(0)
  @Max(10000000)
  public sum?: number;

  @IsEnum(Goal)
  @IsNotEmpty()
  public goal?: Goal;

  @IsEnum(Employment)
  @IsNotEmpty()
  public employment?: Employment;

  @IsEnum(OtherLoans)
  @IsNotEmpty()
  public otherLoans?: OtherLoans;

  @IsEnum(Pledge)
  @IsNotEmpty()
  public pledge: Pledge;

  @IsNumber()
  @Min(0)
  @Max(50)
  public carAge?: number;
}
