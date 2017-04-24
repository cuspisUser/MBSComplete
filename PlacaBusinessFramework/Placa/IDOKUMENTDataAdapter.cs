namespace Placa
{
    using System;
    using System.Data;

    public interface IDOKUMENTDataAdapter
    {
        int Fill(DOKUMENTDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DOKUMENTDataSet dataSet, int iDDOKUMENT);
        bool FillByIDDOKUMENT(DOKUMENTDataSet dataSet, int iDDOKUMENT);
        int FillByIDTIPDOKUMENTA(DOKUMENTDataSet dataSet, int iDTIPDOKUMENTA);
        int FillPage(DOKUMENTDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDTIPDOKUMENTA(DOKUMENTDataSet dataSet, int iDTIPDOKUMENTA, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDTIPDOKUMENTA(int iDTIPDOKUMENTA);
        int Update(DataSet dataSet);
    }
}

