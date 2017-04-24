namespace Placa
{
    using System;
    using System.Data;

    public interface IPOREZDataAdapter
    {
        int Fill(POREZDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(POREZDataSet dataSet, int iDPOREZ);
        bool FillByIDPOREZ(POREZDataSet dataSet, int iDPOREZ);
        int FillPage(POREZDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

