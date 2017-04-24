namespace Placa
{
    using System;
    using System.Data;

    public interface IGRUPEKOEFDataAdapter
    {
        int Fill(GRUPEKOEFDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(GRUPEKOEFDataSet dataSet, int iDGRUPEKOEF);
        bool FillByIDGRUPEKOEF(GRUPEKOEFDataSet dataSet, int iDGRUPEKOEF);
        int FillPage(GRUPEKOEFDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

