import React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";

import { IAverageInsuranceQuote, IInsuranceQuote } from "../../interfaces/insuranceQuote";

function TableComponent({ rows, averageIsuranceQuote }: { rows: IInsuranceQuote[], averageIsuranceQuote: IAverageInsuranceQuote }) {
  console.log(averageIsuranceQuote)
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Marca</TableCell>
            <TableCell align="right">Nome</TableCell>
            <TableCell align="right">Nº Documento</TableCell>
            <TableCell align="right">Idade</TableCell>
            <TableCell align="right">Modelo</TableCell>
            <TableCell align="right">Valor</TableCell>
            <TableCell align="right">Taxa de Risco</TableCell>
            <TableCell align="right">Prêmio de Risco</TableCell>
            <TableCell align="right">Prêmio Puro</TableCell>
            <TableCell align="right">Prêmio Comercial</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow
              key={row.id}
              sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
            >
              <TableCell>{row.make}</TableCell>
              <TableCell align="right">{row.name}</TableCell>
              <TableCell align="right">{row.documentNumber}</TableCell>
              <TableCell align="right">{row.age}</TableCell>
              <TableCell align="right">{row.model}</TableCell>
              <TableCell align="right">{row.value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</TableCell>
              <TableCell align="right">{row.riskRate.toFixed(2)} %</TableCell>
              <TableCell align="right">{row.riskPremium.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</TableCell>
              <TableCell align="right">{row.purePrize.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</TableCell>
              <TableCell align="right">{row.commercialAward.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</TableCell>
            </TableRow>
          ))}
          <TableRow
            sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
          >
            <TableCell><strong>Medias</strong></TableCell>
            <TableCell></TableCell>
            <TableCell></TableCell>
            <TableCell></TableCell>
            <TableCell></TableCell>
            <TableCell></TableCell>
            <TableCell align="right">{averageIsuranceQuote.avgRiskRate.toFixed(2)} %</TableCell>
            <TableCell align="right">{averageIsuranceQuote.avgRiskPremium.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</TableCell>
            <TableCell align="right">{averageIsuranceQuote.avgPurePrize.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</TableCell>
            <TableCell align="right">{averageIsuranceQuote.avgCommercialAward.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</TableCell>
          </TableRow>
        </TableBody>
      </Table>
    </TableContainer>
  );
}

export default TableComponent;
