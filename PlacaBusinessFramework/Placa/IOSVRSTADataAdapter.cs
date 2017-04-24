namespace Placa
{
    using System;
    using System.Data;

    public interface IOSVRSTADataAdapter
    {
        int Fill(OSVRSTADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OSVRSTADataSet dataSet, int iDOSVRSTA);
        bool FillByIDOSVRSTA(OSVRSTADataSet dataSet, int iDOSVRSTA);
        int FillPage(OSVRSTADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

