namespace Placa
{
    using System;
    using System.Data;

    public interface IBENEFICIRANIDataAdapter
    {
        int Fill(BENEFICIRANIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(BENEFICIRANIDataSet dataSet, string iDBENEFICIRANI);
        bool FillByIDBENEFICIRANI(BENEFICIRANIDataSet dataSet, string iDBENEFICIRANI);
        int FillPage(BENEFICIRANIDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

