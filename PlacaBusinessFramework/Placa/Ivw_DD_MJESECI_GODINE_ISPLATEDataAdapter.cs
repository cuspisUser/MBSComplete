namespace Placa
{
    using System;
    using System.Data;

    public interface Ivw_DD_MJESECI_GODINE_ISPLATEDataAdapter
    {
        int Fill(vw_DD_MJESECI_GODINE_ISPLATEDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(vw_DD_MJESECI_GODINE_ISPLATEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

