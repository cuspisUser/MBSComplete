namespace Placa
{
    using System;
    using System.Data;

    public interface IV_DD_GODINE_ISPLATEDataAdapter
    {
        int Fill(V_DD_GODINE_ISPLATEDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(V_DD_GODINE_ISPLATEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

