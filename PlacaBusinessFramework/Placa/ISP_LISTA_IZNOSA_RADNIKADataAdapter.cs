namespace Placa
{
    using System;
    using System.Data;

    public interface ISP_LISTA_IZNOSA_RADNIKADataAdapter
    {
        int Fill(SP_LISTA_IZNOSA_RADNIKADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SP_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT);
        int FillPage(SP_LISTA_IZNOSA_RADNIKADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(SP_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN, string mJESECOBRACUNA, string gODINAOBRACUNA, int sORT);
    }
}

