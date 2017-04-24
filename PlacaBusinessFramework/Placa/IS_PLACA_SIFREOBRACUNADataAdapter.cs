namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_SIFREOBRACUNADataAdapter
    {
        int Fill(S_PLACA_SIFREOBRACUNADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_SIFREOBRACUNADataSet dataSet, string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA);
        int FillPage(S_PLACA_SIFREOBRACUNADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_SIFREOBRACUNADataSet dataSet, string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA, int startRow, int maxRows);
        int GetRecordCount(string oDGODINE, string oDMJESECA, string dOGODINE, string dOMJESECA);
    }
}

