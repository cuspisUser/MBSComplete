namespace Placa
{
    using System;
    using System.Data;

    public interface ITIPDOKUMENTADataAdapter
    {
        int Fill(TIPDOKUMENTADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(TIPDOKUMENTADataSet dataSet, int iDTIPDOKUMENTA);
        bool FillByIDTIPDOKUMENTA(TIPDOKUMENTADataSet dataSet, int iDTIPDOKUMENTA);
        int FillPage(TIPDOKUMENTADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

