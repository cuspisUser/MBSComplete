namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_IP_ZBIRNIDataAdapter
    {
        int Fill(S_OD_IP_ZBIRNIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_IP_ZBIRNIDataSet dataSet, string gODINA);
        int FillPage(S_OD_IP_ZBIRNIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_IP_ZBIRNIDataSet dataSet, string gODINA, int startRow, int maxRows);
        int GetRecordCount(string gODINA);
    }
}

