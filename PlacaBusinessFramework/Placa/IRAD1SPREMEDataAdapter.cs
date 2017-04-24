namespace Placa
{
    using System;
    using System.Data;

    public interface IRAD1SPREMEDataAdapter
    {
        int Fill(RAD1SPREMEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RAD1SPREMEDataSet dataSet, int rAD1IDSPREME);
        bool FillByRAD1IDSPREME(RAD1SPREMEDataSet dataSet, int rAD1IDSPREME);
        int FillPage(RAD1SPREMEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

