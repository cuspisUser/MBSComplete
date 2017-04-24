namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_KONTO_KARTICEDataAdapter
    {
        int Fill(S_FIN_KONTO_KARTICEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_KONTO_KARTICEDataSet dataSet, int oRG, string mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO);
        int FillPage(S_FIN_KONTO_KARTICEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_KONTO_KARTICEDataSet dataSet, int oRG, string mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, int startRow, int maxRows);
        int GetRecordCount(int oRG, string mT, int dOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO);
    }
}

