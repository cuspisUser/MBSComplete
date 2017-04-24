namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_diskete_za_bankuDataAdapter
    {
        int Fill(sp_diskete_za_bankuDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_diskete_za_bankuDataSet dataSet, string idobracun, string vbdibanke);
        int FillPage(sp_diskete_za_bankuDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_diskete_za_bankuDataSet dataSet, string idobracun, string vbdibanke, int startRow, int maxRows);
        int GetRecordCount(string idobracun, string vbdibanke);
    }
}

