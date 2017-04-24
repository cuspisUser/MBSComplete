namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_PROMET_PO_PARTNERIMADataAdapter
    {
        int Fill(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet, int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO);
        int FillPage(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_PROMET_PO_PARTNERIMADataSet dataSet, int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO, int startRow, int maxRows);
        int GetRecordCount(int oDPARTNERA, int dOPARTNERA, int mT, int oRG, int iDAKTIVNOST, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string dODATNIUVJET, string pOCETNIKONTO, string zAVRSNIKONTO);
    }
}

