namespace Placa
{
    using System;
    using System.Data;

    public interface IFINPOREZDataAdapter
    {
        int Fill(FINPOREZDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(FINPOREZDataSet dataSet, int fINPOREZIDPOREZ);
        bool FillByFINPOREZIDPOREZ(FINPOREZDataSet dataSet, int fINPOREZIDPOREZ);
        int FillPage(FINPOREZDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

