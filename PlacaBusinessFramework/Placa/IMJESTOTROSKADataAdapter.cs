namespace Placa
{
    using System;
    using System.Data;

    public interface IMJESTOTROSKADataAdapter
    {
        int Fill(MJESTOTROSKADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(MJESTOTROSKADataSet dataSet, int iDMJESTOTROSKA);
        bool FillByIDMJESTOTROSKA(MJESTOTROSKADataSet dataSet, int iDMJESTOTROSKA);
        int FillPage(MJESTOTROSKADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

