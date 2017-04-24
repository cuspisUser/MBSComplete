namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_IZVRSENJE_PLANADataAdapter
    {
        int Fill(S_FIN_IZVRSENJE_PLANADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_IZVRSENJE_PLANADataSet dataSet, int iDORGJED, string godina);
        int FillPage(S_FIN_IZVRSENJE_PLANADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_IZVRSENJE_PLANADataSet dataSet, int iDORGJED, string godina, int startRow, int maxRows);
        int GetRecordCount(int iDORGJED, string godina);
    }
}

