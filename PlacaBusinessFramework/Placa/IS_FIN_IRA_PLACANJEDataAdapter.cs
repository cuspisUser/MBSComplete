namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_IRA_PLACANJEDataAdapter
    {
        int Fill(S_FIN_IRA_PLACANJEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_IRA_PLACANJEDataSet dataSet, int iDDOKUMENT);
        int FillPage(S_FIN_IRA_PLACANJEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_IRA_PLACANJEDataSet dataSet, int iDDOKUMENT, int startRow, int maxRows);
        int GetRecordCount(int iDDOKUMENT);
    }
}

