import axios from "axios";
import { IGetAverageInsuranceQuote } from "../interfaces/insuranceQuote";

export const GetAllInsuranceQuote =
  async (): Promise<IGetAverageInsuranceQuote> => {
    return await axios.get("https://localhost:44353/Insurance/GetReportInsurance");
  };
