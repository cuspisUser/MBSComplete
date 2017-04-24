namespace Placa
{
    using System;
    using System.Data;

    public interface Ivw_mjeseci_godine_isplateDataAdapter
    {
        int Fill(vw_mjeseci_godine_isplateDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(vw_mjeseci_godine_isplateDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

