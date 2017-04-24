namespace Placa
{
    using System;
    using System.Data;

    public interface IIZVORDOKUMENTADataAdapter
    {
        int Fill(IZVORDOKUMENTADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(IZVORDOKUMENTADataSet dataSet, string sIFRAIZVORA);
        bool FillBySIFRAIZVORA(IZVORDOKUMENTADataSet dataSet, string sIFRAIZVORA);
        int FillPage(IZVORDOKUMENTADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

