namespace Placa
{
    using System;
    using System.Data;

    public interface IS_DD_LISTA_IZNOSA_RADNIKADataAdapter
    {
        int Fill(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, int sORT);
        int FillPage(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_DD_LISTA_IZNOSA_RADNIKADataSet dataSet, string iDOBRACUN, int sORT, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN, int sORT);
    }
}

