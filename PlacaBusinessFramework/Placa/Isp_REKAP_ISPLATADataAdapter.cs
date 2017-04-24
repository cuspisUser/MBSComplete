namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_REKAP_ISPLATADataAdapter
    {
        int Fill(sp_REKAP_ISPLATADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_REKAP_ISPLATADataSet dataSet, string iDOBRACUN, string vBDIBANKE);
        int FillPage(sp_REKAP_ISPLATADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_REKAP_ISPLATADataSet dataSet, string iDOBRACUN, string vBDIBANKE, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN, string vBDIBANKE);
    }
}

