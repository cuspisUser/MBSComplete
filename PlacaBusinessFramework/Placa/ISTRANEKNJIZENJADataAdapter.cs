namespace Placa
{
    using System;
    using System.Data;

    public interface ISTRANEKNJIZENJADataAdapter
    {
        int Fill(STRANEKNJIZENJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(STRANEKNJIZENJADataSet dataSet, int iDSTRANEKNJIZENJA);
        bool FillByIDSTRANEKNJIZENJA(STRANEKNJIZENJADataSet dataSet, int iDSTRANEKNJIZENJA);
        int FillPage(STRANEKNJIZENJADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

