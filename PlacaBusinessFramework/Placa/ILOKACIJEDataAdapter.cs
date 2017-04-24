namespace Placa
{
    using System;
    using System.Data;

    public interface ILOKACIJEDataAdapter
    {
        int Fill(LOKACIJEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(LOKACIJEDataSet dataSet, int iDLOKACIJE);
        bool FillByIDLOKACIJE(LOKACIJEDataSet dataSet, int iDLOKACIJE);
        int FillPage(LOKACIJEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

