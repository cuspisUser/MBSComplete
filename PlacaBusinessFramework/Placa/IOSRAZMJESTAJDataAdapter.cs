namespace Placa
{
    using System;
    using System.Data;

    public interface IOSRAZMJESTAJDataAdapter
    {
        int Fill(OSRAZMJESTAJDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OSRAZMJESTAJDataSet dataSet, Guid iDOSRAZMJESTAJ);
        int FillByIDLOKACIJE(OSRAZMJESTAJDataSet dataSet, int iDLOKACIJE);
        bool FillByIDOSRAZMJESTAJ(OSRAZMJESTAJDataSet dataSet, Guid iDOSRAZMJESTAJ);
        int FillByINVBROJ(OSRAZMJESTAJDataSet dataSet, long iNVBROJ);
        int FillPage(OSRAZMJESTAJDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDLOKACIJE(OSRAZMJESTAJDataSet dataSet, int iDLOKACIJE, int startRow, int maxRows);
        int FillPageByINVBROJ(OSRAZMJESTAJDataSet dataSet, long iNVBROJ, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDLOKACIJE(int iDLOKACIJE);
        int GetRecordCountByINVBROJ(long iNVBROJ);
        int Update(DataSet dataSet);
    }
}

