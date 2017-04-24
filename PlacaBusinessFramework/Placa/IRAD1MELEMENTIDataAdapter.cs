namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1MELEMENTIDataAdapter
    {
        int Fill(RAD1MELEMENTIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1MELEMENTIDataSet dataSet, int rAD1ELEMENTIID);
        bool FillByRAD1ELEMENTIID(RAD1MELEMENTIDataSet dataSet, int rAD1ELEMENTIID);
        int FillPage(RAD1MELEMENTIDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

