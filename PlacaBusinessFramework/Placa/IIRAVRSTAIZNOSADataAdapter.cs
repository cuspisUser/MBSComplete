namespace Placa
{
    using System;
    using System.Data;

    public interface IIRAVRSTAIZNOSADataAdapter
    {
        int Fill(IRAVRSTAIZNOSADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(IRAVRSTAIZNOSADataSet dataSet, int iDIRAVRSTAIZNOSA);
        bool FillByIDIRAVRSTAIZNOSA(IRAVRSTAIZNOSADataSet dataSet, int iDIRAVRSTAIZNOSA);
        int FillPage(IRAVRSTAIZNOSADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

