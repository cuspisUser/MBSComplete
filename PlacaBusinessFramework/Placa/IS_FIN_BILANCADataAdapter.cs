namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_BILANCADataAdapter
    {
        int Fill(S_FIN_BILANCADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_BILANCADataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE);
        int FillPage(S_FIN_BILANCADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_BILANCADataSet dataSet, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE, int startRow, int maxRows);
        int GetRecordCount(DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string oRG, string mT, string dOK, short aNA, short sKR, string kLASA, short vRSTABILANCE);
    }
}

