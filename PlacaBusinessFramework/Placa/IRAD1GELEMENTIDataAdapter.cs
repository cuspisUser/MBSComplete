namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1GELEMENTIDataAdapter
    {
        int Fill(RAD1GELEMENTIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1GELEMENTIDataSet dataSet, int rAD1GELEMENTIID);
        bool FillByRAD1GELEMENTIID(RAD1GELEMENTIDataSet dataSet, int rAD1GELEMENTIID);
        int FillPage(RAD1GELEMENTIDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

