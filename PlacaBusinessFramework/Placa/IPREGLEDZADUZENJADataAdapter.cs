namespace Placa
{
    using System;
    using System.Data;

    public interface IPREGLEDZADUZENJADataAdapter
    {
        int Fill(PREGLEDZADUZENJADataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(PREGLEDZADUZENJADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();

        string Filter { get; set; }
    }
}

