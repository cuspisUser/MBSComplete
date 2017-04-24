namespace Placa
{
    using System;
    using System.Data;

    public interface IBANKEDataAdapter
    {
        int Fill(BANKEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(BANKEDataSet dataSet, int iDBANKE);
        bool FillByIDBANKE(BANKEDataSet dataSet, int iDBANKE);
        int FillPage(BANKEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

