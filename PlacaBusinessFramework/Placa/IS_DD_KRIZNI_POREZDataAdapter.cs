namespace Placa
{
    using System;
    using System.Data;

    public interface IS_DD_KRIZNI_POREZDataAdapter
    {
        int Fill(S_DD_KRIZNI_POREZDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_DD_KRIZNI_POREZDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE);
        int FillPage(S_DD_KRIZNI_POREZDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_DD_KRIZNI_POREZDataSet dataSet, string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE);
    }
}

