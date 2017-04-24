namespace Placa
{
    using System;
    using System.Data;

    public interface IOTISLIDataAdapter
    {
        int Fill(OTISLIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OTISLIDataSet dataSet, int iDRADNIK, DateTime dATUMODLASKA);
        int FillByIDRADNIK(OTISLIDataSet dataSet, int iDRADNIK);
        bool FillByIDRADNIKDATUMODLASKA(OTISLIDataSet dataSet, int iDRADNIK, DateTime dATUMODLASKA);
        int FillPage(OTISLIDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDRADNIK(OTISLIDataSet dataSet, int iDRADNIK, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDRADNIK(int iDRADNIK);
        int Update(DataSet dataSet);
    }
}

