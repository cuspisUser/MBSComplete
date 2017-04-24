namespace Placa
{
    using System;
    using System.Data;

    public interface IBRACNOSTANJEDataAdapter
    {
        int Fill(BRACNOSTANJEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(BRACNOSTANJEDataSet dataSet, int iDBRACNOSTANJE);
        bool FillByIDBRACNOSTANJE(BRACNOSTANJEDataSet dataSet, int iDBRACNOSTANJE);
        int FillPage(BRACNOSTANJEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

