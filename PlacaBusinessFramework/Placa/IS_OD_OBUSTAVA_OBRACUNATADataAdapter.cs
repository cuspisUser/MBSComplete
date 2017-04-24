namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OD_OBUSTAVA_OBRACUNATADataAdapter
    {
        int Fill(S_OD_OBUSTAVA_OBRACUNATADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OD_OBUSTAVA_OBRACUNATADataSet dataSet, string iDOBRACUN);
        int FillPage(S_OD_OBUSTAVA_OBRACUNATADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OD_OBUSTAVA_OBRACUNATADataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

