namespace Placa
{
    using System;
    using System.Data;

    public interface IVRSTADOPRINOSDataAdapter
    {
        int Fill(VRSTADOPRINOSDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(VRSTADOPRINOSDataSet dataSet, int iDVRSTADOPRINOS);
        bool FillByIDVRSTADOPRINOS(VRSTADOPRINOSDataSet dataSet, int iDVRSTADOPRINOS);
        int FillPage(VRSTADOPRINOSDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

