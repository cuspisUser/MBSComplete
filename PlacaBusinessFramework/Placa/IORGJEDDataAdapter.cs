namespace Placa
{
    using System;
    using System.Data;

    public interface IORGJEDDataAdapter
    {
        int Fill(ORGJEDDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(ORGJEDDataSet dataSet, int iDORGJED);
        bool FillByIDORGJED(ORGJEDDataSet dataSet, int iDORGJED);
        int FillPage(ORGJEDDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

