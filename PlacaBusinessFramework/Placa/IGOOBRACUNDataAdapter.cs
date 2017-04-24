namespace Placa
{
    using System;
    using System.Data;

    public interface IGOOBRACUNDataAdapter
    {
        int Fill(GOOBRACUNDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(GOOBRACUNDataSet dataSet, int iDGOOBRACUN);
        bool FillByIDGOOBRACUN(GOOBRACUNDataSet dataSet, int iDGOOBRACUN);
        int FillByIDRADNIK(GOOBRACUNDataSet dataSet, int iDRADNIK);
        int FillPage(GOOBRACUNDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDRADNIK(GOOBRACUNDataSet dataSet, int iDRADNIK, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDRADNIK(int iDRADNIK);
        int Update(DataSet dataSet);
    }
}

