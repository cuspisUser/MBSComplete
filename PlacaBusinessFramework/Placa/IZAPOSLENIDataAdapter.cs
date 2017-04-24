namespace Placa
{
    using System;
    using System.Data;

    public interface IZAPOSLENIDataAdapter
    {
        int Fill(ZAPOSLENIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(ZAPOSLENIDataSet dataSet, int iDRADNIK, DateTime dATUMZAPOSLENJA);
        int FillByIDRADNIK(ZAPOSLENIDataSet dataSet, int iDRADNIK);
        bool FillByIDRADNIKDATUMZAPOSLENJA(ZAPOSLENIDataSet dataSet, int iDRADNIK, DateTime dATUMZAPOSLENJA);
        int FillPage(ZAPOSLENIDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDRADNIK(ZAPOSLENIDataSet dataSet, int iDRADNIK, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDRADNIK(int iDRADNIK);
        int Update(DataSet dataSet);
    }
}

