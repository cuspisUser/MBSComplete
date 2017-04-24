namespace Placa
{
    using System;
    using System.Data;

    public interface ITIPIZNOSADataAdapter
    {
        int Fill(TIPIZNOSADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(TIPIZNOSADataSet dataSet, int iDTIPAIZNOSA);
        bool FillByIDTIPAIZNOSA(TIPIZNOSADataSet dataSet, int iDTIPAIZNOSA);
        int FillPage(TIPIZNOSADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

