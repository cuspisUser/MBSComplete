namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_BOLOVANJE_POSLODAVACDataAdapter
    {
        int Fill(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet, string odd, string dooo, int iDRADNIK);
        int FillPage(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_BOLOVANJE_POSLODAVACDataSet dataSet, string odd, string dooo, int iDRADNIK, int startRow, int maxRows);
        int GetRecordCount(string odd, string dooo, int iDRADNIK);
    }
}

