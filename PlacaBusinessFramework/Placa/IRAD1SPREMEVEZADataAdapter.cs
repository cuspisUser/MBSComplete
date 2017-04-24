namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1SPREMEVEZADataAdapter
    {
        int Fill(RAD1SPREMEVEZADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME, int iDSTRUCNASPREMA);
        int FillByIDSTRUCNASPREMA(RAD1SPREMEVEZADataSet dataSet, int iDSTRUCNASPREMA);
        int FillByRAD1IDSPREME(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME);
        bool FillByRAD1IDSPREMEIDSTRUCNASPREMA(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME, int iDSTRUCNASPREMA);
        int FillPage(RAD1SPREMEVEZADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDSTRUCNASPREMA(RAD1SPREMEVEZADataSet dataSet, int iDSTRUCNASPREMA, int startRow, int maxRows);
        int FillPageByRAD1IDSPREME(RAD1SPREMEVEZADataSet dataSet, int rAD1IDSPREME, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDSTRUCNASPREMA(int iDSTRUCNASPREMA);
        int GetRecordCountByRAD1IDSPREME(int rAD1IDSPREME);
        int Update(DataSet dataSet);
    }
}

