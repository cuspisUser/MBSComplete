namespace Placa
{
    using System;
    using System.Data;

    public interface Is_od_pripremaDataAdapter
    {
        int Fill(s_od_pripremaDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(s_od_pripremaDataSet dataSet, int godina, int id, int mjesec, string vrsta);
        int FillPage(s_od_pripremaDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(s_od_pripremaDataSet dataSet, int godina, int id, int mjesec, string vrsta, int startRow, int maxRows);
        int GetRecordCount(int godina, int id, int mjesec, string vrsta);
    }
}

