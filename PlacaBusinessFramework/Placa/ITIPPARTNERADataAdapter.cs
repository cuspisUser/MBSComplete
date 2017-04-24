namespace Placa
{
    using System;
    using System.Data;

    public interface ITIPPARTNERADataAdapter
    {
        int Fill(TIPPARTNERADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(TIPPARTNERADataSet dataSet, int iDTIPPARTNERA);
        bool FillByIDTIPPARTNERA(TIPPARTNERADataSet dataSet, int iDTIPPARTNERA);
        int FillPage(TIPPARTNERADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

