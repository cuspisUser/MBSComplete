namespace Placa
{
    using System;
    using System.Data;

    public interface IOSOBNIODBITAKDataAdapter
    {
        int Fill(OSOBNIODBITAKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OSOBNIODBITAKDataSet dataSet, int iDOSOBNIODBITAK);
        bool FillByIDOSOBNIODBITAK(OSOBNIODBITAKDataSet dataSet, int iDOSOBNIODBITAK);
        int FillPage(OSOBNIODBITAKDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

