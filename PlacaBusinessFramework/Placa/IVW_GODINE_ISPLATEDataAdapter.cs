namespace Placa
{
    using System;
    using System.Data;

    public interface IVW_GODINE_ISPLATEDataAdapter
    {
        int Fill(VW_GODINE_ISPLATEDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(VW_GODINE_ISPLATEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

