namespace Placa
{
    using System;
    using System.Data;

    public interface IGRUPEOLAKSICADataAdapter
    {
        int Fill(GRUPEOLAKSICADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(GRUPEOLAKSICADataSet dataSet, int iDGRUPEOLAKSICA);
        bool FillByIDGRUPEOLAKSICA(GRUPEOLAKSICADataSet dataSet, int iDGRUPEOLAKSICA);
        int FillPage(GRUPEOLAKSICADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

