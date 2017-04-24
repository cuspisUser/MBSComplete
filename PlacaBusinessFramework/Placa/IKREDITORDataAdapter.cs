namespace Placa
{
    using System;
    using System.Data;

    public interface IKREDITORDataAdapter
    {
        int Fill(KREDITORDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(KREDITORDataSet dataSet, int iDKREDITOR);
        bool FillByIDKREDITOR(KREDITORDataSet dataSet, int iDKREDITOR);
        int FillPage(KREDITORDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

