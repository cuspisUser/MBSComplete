namespace Placa
{
    using System;
    using System.Data;

    public interface ITIPURADataAdapter
    {
        int Fill(TIPURADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(TIPURADataSet dataSet, int iDTIPURA);
        bool FillByIDTIPURA(TIPURADataSet dataSet, int iDTIPURA);
        int FillPage(TIPURADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

