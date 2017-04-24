namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_RAD1GDataAdapter
    {
        int Fill(S_PLACA_RAD1GDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_RAD1GDataSet dataSet, string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA);
        int FillPage(S_PLACA_RAD1GDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_RAD1GDataSet dataSet, string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA, int startRow, int maxRows);
        int GetRecordCount(string gODINAISPLATE, string mJESECISPLATE, DateTime dATUMNAKOJIRACUNAMSTAROST, string mJESECODLASKA);
    }
}

