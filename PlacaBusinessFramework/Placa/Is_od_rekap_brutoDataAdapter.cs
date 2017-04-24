namespace Placa
{
    using System;
    using System.Data;

    public interface Is_od_rekap_brutoDataAdapter
    {
        int Fill(s_od_rekap_brutoDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(s_od_rekap_brutoDataSet dataSet, string idobracun);
        int FillPage(s_od_rekap_brutoDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(s_od_rekap_brutoDataSet dataSet, string idobracun, int startRow, int maxRows);
        int GetRecordCount(string idobracun);
    }
}

