namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1GELEMENTIVEZADataAdapter
    {
        int Fill(RAD1GELEMENTIVEZADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID, int iDELEMENT);
        int FillByIDELEMENT(RAD1GELEMENTIVEZADataSet dataSet, int iDELEMENT);
        int FillByRAD1GELEMENTIID(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID);
        bool FillByRAD1GELEMENTIIDIDELEMENT(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID, int iDELEMENT);
        int FillPage(RAD1GELEMENTIVEZADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDELEMENT(RAD1GELEMENTIVEZADataSet dataSet, int iDELEMENT, int startRow, int maxRows);
        int FillPageByRAD1GELEMENTIID(RAD1GELEMENTIVEZADataSet dataSet, int rAD1GELEMENTIID, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDELEMENT(int iDELEMENT);
        int GetRecordCountByRAD1GELEMENTIID(int rAD1GELEMENTIID);
        int Update(DataSet dataSet);
    }
}

