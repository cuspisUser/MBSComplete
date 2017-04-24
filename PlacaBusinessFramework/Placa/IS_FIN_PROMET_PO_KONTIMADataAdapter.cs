namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_PROMET_PO_KONTIMADataAdapter
    {
        int Fill(S_FIN_PROMET_PO_KONTIMADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_PROMET_PO_KONTIMADataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO);
        int FillPage(S_FIN_PROMET_PO_KONTIMADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_PROMET_PO_KONTIMADataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int startRow, int maxRows);
        int GetRecordCount(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO);
    }
}

