namespace Placa
{
    using System;
    using System.Data;

    public interface IIPIDENTDataAdapter
    {
        int Fill(IPIDENTDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(IPIDENTDataSet dataSet, int iDIPIDENT);
        bool FillByIDIPIDENT(IPIDENTDataSet dataSet, int iDIPIDENT);
        int FillPage(IPIDENTDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

