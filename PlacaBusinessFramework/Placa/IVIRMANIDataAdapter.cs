namespace Placa
{
    using System;
    using System.Data;

    public interface IVIRMANIDataAdapter
    {
        int Fill(VIRMANIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(VIRMANIDataSet dataSet, int iDVIRMAN);
        bool FillByIDVIRMAN(VIRMANIDataSet dataSet, int iDVIRMAN);
        int FillBySIFRAOBRACUNAVIRMAN(VIRMANIDataSet dataSet, string sIFRAOBRACUNAVIRMAN);
        int FillPage(VIRMANIDataSet dataSet, int startRow, int maxRows);
        int FillPageBySIFRAOBRACUNAVIRMAN(VIRMANIDataSet dataSet, string sIFRAOBRACUNAVIRMAN, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountBySIFRAOBRACUNAVIRMAN(string sIFRAOBRACUNAVIRMAN);
        int Update(DataSet dataSet);
    }
}

