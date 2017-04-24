namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter
    {
        int Fill(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO);
        int FillPage(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, int startRow, int maxRows);
        int GetRecordCount(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO);
    }
}

