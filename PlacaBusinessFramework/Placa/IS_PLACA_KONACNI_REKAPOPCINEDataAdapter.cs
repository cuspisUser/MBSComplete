namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_KONACNI_REKAPOPCINEDataAdapter
    {
        int Fill(S_PLACA_KONACNI_REKAPOPCINEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_KONACNI_REKAPOPCINEDataSet dataSet, string iDOBRACUN);
        int FillPage(S_PLACA_KONACNI_REKAPOPCINEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_KONACNI_REKAPOPCINEDataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

