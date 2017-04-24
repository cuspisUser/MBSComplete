namespace Placa
{
    using System;
    using System.Data;

    public interface IVW_MJESECI_GODINE_OBRACUNADataAdapter
    {
        int Fill(VW_MJESECI_GODINE_OBRACUNADataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(VW_MJESECI_GODINE_OBRACUNADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

