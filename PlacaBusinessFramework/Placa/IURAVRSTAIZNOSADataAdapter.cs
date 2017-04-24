namespace Placa
{
    using System;
    using System.Data;

    public interface IURAVRSTAIZNOSADataAdapter
    {
        int Fill(URAVRSTAIZNOSADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(URAVRSTAIZNOSADataSet dataSet, int iDURAVRSTAIZNOSA);
        bool FillByIDURAVRSTAIZNOSA(URAVRSTAIZNOSADataSet dataSet, int iDURAVRSTAIZNOSA);
        int FillPage(URAVRSTAIZNOSADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

