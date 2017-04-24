namespace Placa
{
    using System;
    using System.Data;

    public interface ITITULADataAdapter
    {
        int Fill(TITULADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(TITULADataSet dataSet, int iDTITULA);
        bool FillByIDTITULA(TITULADataSet dataSet, int iDTITULA);
        int FillPage(TITULADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

