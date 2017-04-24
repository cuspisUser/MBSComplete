namespace Placa
{
    using System;
    using System.Data;

    public interface IOBRACUNDataAdapter
    {
        int Fill(OBRACUNDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OBRACUNDataSet dataSet, string iDOBRACUN);
        bool FillByIDOBRACUN(OBRACUNDataSet dataSet, string iDOBRACUN);
        int FillPage(OBRACUNDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

