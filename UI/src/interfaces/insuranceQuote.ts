export interface IInsuranceQuote {
  id: number;
  name: string;
  documentNumber: string;
  age: number;
  make: string;
  model: string;
  value: number;
  riskRate: number;
  riskPremium: number;
  purePrize: number;
  commercialAward: number;
}

export interface IAverageInsuranceQuote {
  avgRiskRate: number,
  avgRiskPremium: number,
  avgPurePrize: number,
  avgCommercialAward: number,
  data?: IInsuranceQuote | never[]
}

export interface IGetAverageInsuranceQuote {
  data: IAverageInsuranceQuote
}