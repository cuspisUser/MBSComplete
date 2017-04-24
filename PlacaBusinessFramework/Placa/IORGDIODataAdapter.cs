namespace Placa
{
    using System;
    using System.Data;

    public interface IORGDIODataAdapter
    {
        int Fill(ORGDIODataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(ORGDIODataSet dataSet, int iDORGDIO);
        bool FillByIDORGDIO(ORGDIODataSet dataSet, int iDORGDIO);
        int FillPage(ORGDIODataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

