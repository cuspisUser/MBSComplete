namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1VEZASPOLDataAdapter
    {
        int Fill(RAD1VEZASPOLDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID, int iDSPOL);
        int FillByIDSPOL(RAD1VEZASPOLDataSet dataSet, int iDSPOL);
        int FillByRAD1SPOLID(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID);
        bool FillByRAD1SPOLIDIDSPOL(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID, int iDSPOL);
        int FillPage(RAD1VEZASPOLDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDSPOL(RAD1VEZASPOLDataSet dataSet, int iDSPOL, int startRow, int maxRows);
        int FillPageByRAD1SPOLID(RAD1VEZASPOLDataSet dataSet, int rAD1SPOLID, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDSPOL(int iDSPOL);
        int GetRecordCountByRAD1SPOLID(int rAD1SPOLID);
        int Update(DataSet dataSet);
    }
}

