namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataAdapter
    {
        int Fill(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet, int brojdok);
        int FillPage(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet dataSet, int brojdok, int startRow, int maxRows);
        int GetRecordCount(int brojdok);
    }
}

