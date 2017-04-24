namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_STANJE_LOKACIJADataAdapter
    {
        int Fill(S_OS_STANJE_LOKACIJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OS_STANJE_LOKACIJADataSet dataSet, long invbroj);
        int FillPage(S_OS_STANJE_LOKACIJADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OS_STANJE_LOKACIJADataSet dataSet, long invbroj, int startRow, int maxRows);
        int GetRecordCount(long invbroj);
    }
}

