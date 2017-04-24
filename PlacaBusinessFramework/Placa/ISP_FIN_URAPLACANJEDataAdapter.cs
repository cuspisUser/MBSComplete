namespace Placa
{
    using System;
    using System.Data;

    public interface ISP_FIN_URAPLACANJEDataAdapter
    {
        int Fill(SP_FIN_URAPLACANJEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SP_FIN_URAPLACANJEDataSet dataSet, int iDDOKUMENT);
        int FillPage(SP_FIN_URAPLACANJEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(SP_FIN_URAPLACANJEDataSet dataSet, int iDDOKUMENT, int startRow, int maxRows);
        int GetRecordCount(int iDDOKUMENT);
    }
}

