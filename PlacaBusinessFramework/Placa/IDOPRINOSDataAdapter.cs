namespace Placa
{
    using System;
    using System.Data;

    public interface IDOPRINOSDataAdapter
    {
        int Fill(DOPRINOSDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DOPRINOSDataSet dataSet, int iDDOPRINOS);
        bool FillByIDDOPRINOS(DOPRINOSDataSet dataSet, int iDDOPRINOS);
        int FillByIDVRSTADOPRINOS(DOPRINOSDataSet dataSet, int iDVRSTADOPRINOS);
        int FillPage(DOPRINOSDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDVRSTADOPRINOS(DOPRINOSDataSet dataSet, int iDVRSTADOPRINOS, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDVRSTADOPRINOS(int iDVRSTADOPRINOS);
        int Update(DataSet dataSet);
    }
}

