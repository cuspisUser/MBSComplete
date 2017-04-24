namespace Placa
{
    using System;
    using System.Data;

    public interface IRADNOVRIJEMEDataAdapter
    {
        int Fill(RADNOVRIJEMEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RADNOVRIJEMEDataSet dataSet, int iDRADNOVRIJEME);
        bool FillByIDRADNOVRIJEME(RADNOVRIJEMEDataSet dataSet, int iDRADNOVRIJEME);
        int FillPage(RADNOVRIJEMEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

