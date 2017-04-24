namespace Placa
{
    using System;
    using System.Data;

    public interface IKRIZNIPOREZDataAdapter
    {
        int Fill(KRIZNIPOREZDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(KRIZNIPOREZDataSet dataSet, int iDKRIZNIPOREZ);
        bool FillByIDKRIZNIPOREZ(KRIZNIPOREZDataSet dataSet, int iDKRIZNIPOREZ);
        int FillPage(KRIZNIPOREZDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

