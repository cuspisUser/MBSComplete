namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_id_zaglavljeDataAdapter
    {
        int Fill(sp_id_zaglavljeDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_id_zaglavljeDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI);
        int FillPage(sp_id_zaglavljeDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_id_zaglavljeDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI);
    }
}

