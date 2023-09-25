import * as React from "react";

import TableComponent from "./components/Table";
import { GetAllInsuranceQuote } from "./service/InsuranceQuoteService";
import { IAverageInsuranceQuote, IGetAverageInsuranceQuote, IInsuranceQuote } from "./interfaces/insuranceQuote";

export default function App() {
  const [rows, setRows] = React.useState<IInsuranceQuote[]>([]);
  const [averageIsuranceQuote, setAverageInsuranceQuote] = React.useState<IAverageInsuranceQuote>({
    avgRiskRate: 0,
    avgRiskPremium: 0,
    avgPurePrize: 0,
    avgCommercialAward: 0,
  })
  React.useEffect(() => {
    GetAllInsuranceQuote().then(({ data }: IGetAverageInsuranceQuote) => {
      const average = {
        avgRiskRate: data.avgRiskRate,
        avgRiskPremium: data.avgRiskPremium,
        avgPurePrize: data.avgPurePrize,
        avgCommercialAward: data.avgCommercialAward
      };
      setAverageInsuranceQuote(average);
      setRows([...rows, ...data.data as any]);
    });
  }, [setRows, setAverageInsuranceQuote]);
  return <main>
    {rows.length &&
        <TableComponent rows={rows} averageIsuranceQuote={averageIsuranceQuote} />
    }
  </main>;
}
