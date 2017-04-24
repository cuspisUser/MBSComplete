namespace Placa
{
    using System;
    using System.Data;

    public interface IS_FIN_DNEVNIKBLAGAJNEODDODataAdapter
    {
        int Fill(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet, int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA);
        int FillPage(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_FIN_DNEVNIKBLAGAJNEODDODataSet dataSet, int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA, int startRow, int maxRows);
        int GetRecordCount(int oDD, int dOO, int vRSTA, int bLAG, short aKTIVNAGODINA);
    }
}

