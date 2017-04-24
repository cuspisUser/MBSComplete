namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_ip_detaljiDataAdapter
    {
        int Fill(sp_ip_detaljiDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_ip_detaljiDataSet dataSet, string godina);
        int FillPage(sp_ip_detaljiDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_ip_detaljiDataSet dataSet, string godina, int startRow, int maxRows);
        int GetRecordCount(string godina);
    }
}

