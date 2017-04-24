namespace Placa
{
    using System;
    using System.Data;

    public interface IGODINA_I_MJESEC_OBRACUNADataAdapter
    {
        int Fill(GODINA_I_MJESEC_OBRACUNADataSet dataSet);
        int Fill(DataSet dataSet);
        int FillPage(GODINA_I_MJESEC_OBRACUNADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
    }
}

