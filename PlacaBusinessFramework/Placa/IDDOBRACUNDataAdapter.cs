namespace Placa
{
    using System;
    using System.Data;

    public interface IDDOBRACUNDataAdapter
    {
        int Fill(DDOBRACUNDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DDOBRACUNDataSet dataSet, string dDOBRACUNIDOBRACUN);
        bool FillByDDOBRACUNIDOBRACUN(DDOBRACUNDataSet dataSet, string dDOBRACUNIDOBRACUN);
        int FillPage(DDOBRACUNDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

