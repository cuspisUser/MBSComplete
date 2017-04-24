namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_PREGLED_AMORTIZACIJEDataAdapter
    {
        int Fill(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet, int bROJDOK);
        int FillPage(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OS_PREGLED_AMORTIZACIJEDataSet dataSet, int bROJDOK, int startRow, int maxRows);
        int GetRecordCount(int bROJDOK);
    }
}

