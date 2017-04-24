namespace Placa
{
    using System;
    using System.Data;

    public interface IOSDOKUMENTDataAdapter
    {
        int Fill(OSDOKUMENTDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OSDOKUMENTDataSet dataSet, int iDOSDOKUMENT);
        bool FillByIDOSDOKUMENT(OSDOKUMENTDataSet dataSet, int iDOSDOKUMENT);
        int FillPage(OSDOKUMENTDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

