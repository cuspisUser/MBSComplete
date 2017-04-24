namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_ip_zaglavljeDataAdapter
    {
        int Fill(sp_ip_zaglavljeDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_ip_zaglavljeDataSet dataSet, string godina);
        int FillPage(sp_ip_zaglavljeDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_ip_zaglavljeDataSet dataSet, string godina, int startRow, int maxRows);
        int GetRecordCount(string godina);
    }
}

