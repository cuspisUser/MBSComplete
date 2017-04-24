namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_OTVORENE_STAVKEDataAdapter
    {
        int Fill(S_FIN_OTVORENE_STAVKEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_OTVORENE_STAVKEDataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA);
        int FillPage(S_FIN_OTVORENE_STAVKEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_OTVORENE_STAVKEDataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA, int startRow, int maxRows);
        int GetRecordCount(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string dODATNIUVJET, short gODINA);
    }
}

