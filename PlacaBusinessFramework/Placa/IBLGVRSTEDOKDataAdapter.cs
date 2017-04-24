namespace Placa
{
    using System;
    using System.Data;

    public interface IBLGVRSTEDOKDataAdapter
    {
        int Fill(BLGVRSTEDOKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(BLGVRSTEDOKDataSet dataSet, int iDBLGVRSTEDOK);
        bool FillByIDBLGVRSTEDOK(BLGVRSTEDOKDataSet dataSet, int iDBLGVRSTEDOK);
        int FillPage(BLGVRSTEDOKDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

