namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_POSTOJECI_DOKUMENTIDataAdapter
    {
        int Fill(S_OS_POSTOJECI_DOKUMENTIDataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(S_OS_POSTOJECI_DOKUMENTIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
    }
}

