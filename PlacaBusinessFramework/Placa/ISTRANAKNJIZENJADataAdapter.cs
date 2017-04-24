namespace Placa
{
    using System;
    using System.Data;

    public interface ISTRANAKNJIZENJADataAdapter
    {
        int Fill(STRANAKNJIZENJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(STRANAKNJIZENJADataSet dataSet, int iDSTRANA);
        bool FillByIDSTRANA(STRANAKNJIZENJADataSet dataSet, int iDSTRANA);
        int FillPage(STRANAKNJIZENJADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

