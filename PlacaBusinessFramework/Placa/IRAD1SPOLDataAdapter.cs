namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1SPOLDataAdapter
    {
        int Fill(RAD1SPOLDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1SPOLDataSet dataSet, int rAD1SPOLID);
        bool FillByRAD1SPOLID(RAD1SPOLDataSet dataSet, int rAD1SPOLID);
        int FillPage(RAD1SPOLDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

