namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataAdapter
    {
        int Fill(S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet dataSet, DateTime dATUM, string sORT, int vRSTA);
        int FillPage(S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OS_BILANCA_STANJA_NA_DAN_PO_LOKACIJIDataSet dataSet, DateTime dATUM, string sORT, int vRSTA, int startRow, int maxRows);
        int GetRecordCount(DateTime dATUM, string sORT, int vRSTA);
    }
}

