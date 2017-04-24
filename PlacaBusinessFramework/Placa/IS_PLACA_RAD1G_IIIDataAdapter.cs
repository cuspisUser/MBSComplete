namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_RAD1G_IIIDataAdapter
    {
        int Fill(S_PLACA_RAD1G_IIIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_RAD1G_IIIDataSet dataSet, string mJESECISPLATE, string gODINAISPLATE);
        int FillPage(S_PLACA_RAD1G_IIIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_RAD1G_IIIDataSet dataSet, string mJESECISPLATE, string gODINAISPLATE, int startRow, int maxRows);
        int GetRecordCount(string mJESECISPLATE, string gODINAISPLATE);
    }
}

