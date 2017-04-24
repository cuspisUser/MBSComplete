namespace Placa
{
    using System;
    using System.Data;

    public interface ISTRUKADataAdapter
    {
        int Fill(STRUKADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(STRUKADataSet dataSet, int iDSTRUKA);
        bool FillByIDSTRUKA(STRUKADataSet dataSet, int iDSTRUKA);
        int FillPage(STRUKADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

