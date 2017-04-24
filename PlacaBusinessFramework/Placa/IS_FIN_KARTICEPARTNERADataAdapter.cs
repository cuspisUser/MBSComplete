namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_KARTICEPARTNERADataAdapter
    {
        int Fill(S_FIN_KARTICEPARTNERADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_KARTICEPARTNERADataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string sORT);
        int FillPage(S_FIN_KARTICEPARTNERADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_KARTICEPARTNERADataSet dataSet, int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string sORT, int startRow, int maxRows);
        int GetRecordCount(int oRG, int mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int iDAKTIVNOST, int iDPARTNER, string sORT);
    }
}

