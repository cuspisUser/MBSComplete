namespace Placa
{
    using System;
    using System.Data;

    public interface ISPOLDataAdapter
    {
        int Fill(SPOLDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SPOLDataSet dataSet, int iDSPOL);
        bool FillByIDSPOL(SPOLDataSet dataSet, int iDSPOL);
        int FillPage(SPOLDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

