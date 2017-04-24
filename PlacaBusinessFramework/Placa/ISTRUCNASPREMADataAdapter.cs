namespace Placa
{
    using System;
    using System.Data;

    public interface ISTRUCNASPREMADataAdapter
    {
        int Fill(STRUCNASPREMADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(STRUCNASPREMADataSet dataSet, int iDSTRUCNASPREMA);
        bool FillByIDSTRUCNASPREMA(STRUCNASPREMADataSet dataSet, int iDSTRUCNASPREMA);
        int FillPage(STRUCNASPREMADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

