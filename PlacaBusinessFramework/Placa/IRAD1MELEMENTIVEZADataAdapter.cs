namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1MELEMENTIVEZADataAdapter
    {
        int Fill(RAD1MELEMENTIVEZADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID, int iDELEMENT);
        int FillByIDELEMENT(RAD1MELEMENTIVEZADataSet dataSet, int iDELEMENT);
        int FillByRAD1ELEMENTIID(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID);
        bool FillByRAD1ELEMENTIIDIDELEMENT(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID, int iDELEMENT);
        int FillPage(RAD1MELEMENTIVEZADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDELEMENT(RAD1MELEMENTIVEZADataSet dataSet, int iDELEMENT, int startRow, int maxRows);
        int FillPageByRAD1ELEMENTIID(RAD1MELEMENTIVEZADataSet dataSet, int rAD1ELEMENTIID, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDELEMENT(int iDELEMENT);
        int GetRecordCountByRAD1ELEMENTIID(int rAD1ELEMENTIID);
        int Update(DataSet dataSet);
    }
}

