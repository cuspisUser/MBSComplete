namespace Placa
{
    using System;
    using System.Data;

    public interface ITIPIRADataAdapter
    {
        int Fill(TIPIRADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(TIPIRADataSet dataSet, int iDTIPIRA);
        bool FillByIDTIPIRA(TIPIRADataSet dataSet, int iDTIPIRA);
        int FillPage(TIPIRADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

