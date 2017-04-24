namespace Placa
{
    using System;
    using System.Data;

    public interface IRADNOMJESTODataAdapter
    {
        int Fill(RADNOMJESTODataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RADNOMJESTODataSet dataSet, int iDRADNOMJESTO);
        bool FillByIDRADNOMJESTO(RADNOMJESTODataSet dataSet, int iDRADNOMJESTO);
        int FillPage(RADNOMJESTODataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

