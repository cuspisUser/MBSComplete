namespace Placa
{
    using System;
    using System.Data;

    public interface IOSDataAdapter
    {
        int Fill(OSDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OSDataSet dataSet, long iNVBROJ);
        int FillByIDAMSKUPINE(OSDataSet dataSet, int iDAMSKUPINE);
        int FillByIDOSVRSTA(OSDataSet dataSet, int iDOSVRSTA);
        bool FillByINVBROJ(OSDataSet dataSet, long iNVBROJ);
        int FillPage(OSDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDAMSKUPINE(OSDataSet dataSet, int iDAMSKUPINE, int startRow, int maxRows);
        int FillPageByIDOSVRSTA(OSDataSet dataSet, int iDOSVRSTA, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDAMSKUPINE(int iDAMSKUPINE);
        int GetRecordCountByIDOSVRSTA(int iDOSVRSTA);
        int Update(DataSet dataSet);
    }
}

