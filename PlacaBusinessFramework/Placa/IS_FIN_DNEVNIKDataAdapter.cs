namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_DNEVNIKDataAdapter
    {
        int Fill(S_FIN_DNEVNIKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_DNEVNIKDataSet dataSet, int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS);
        int FillPage(S_FIN_DNEVNIKDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_DNEVNIKDataSet dataSet, int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS, int startRow, int maxRows);
        int GetRecordCount(int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS);
    }
}

