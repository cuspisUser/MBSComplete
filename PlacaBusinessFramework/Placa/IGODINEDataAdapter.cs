namespace Placa
{
    using System;
    using System.Data;

    public interface IGODINEDataAdapter
    {
        int Fill(GODINEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(GODINEDataSet dataSet, short iDGODINE);
        bool FillByIDGODINE(GODINEDataSet dataSet, short iDGODINE);
        int FillPage(GODINEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

