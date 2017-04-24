namespace Placa
{
    using System;
    using System.Data;

    public interface IPARTNERDataAdapter
    {
        int Fill(PARTNERDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(PARTNERDataSet dataSet, int iDPARTNER);
        bool FillByIDPARTNER(PARTNERDataSet dataSet, int iDPARTNER);
        int FillPage(PARTNERDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

