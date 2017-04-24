namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_STANJE_OBUSTAVADataAdapter
    {
        int Fill(S_OD_STANJE_OBUSTAVADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_STANJE_OBUSTAVADataSet dataSet, string idobracun);
        int FillPage(S_OD_STANJE_OBUSTAVADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_STANJE_OBUSTAVADataSet dataSet, string idobracun, int startRow, int maxRows);
        int GetRecordCount(string idobracun);
    }
}

