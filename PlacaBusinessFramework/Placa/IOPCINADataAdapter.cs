namespace Placa
{
    using System;
    using System.Data;

    public interface IOPCINADataAdapter
    {
        int Fill(OPCINADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OPCINADataSet dataSet, string iDOPCINE);
        bool FillByIDOPCINE(OPCINADataSet dataSet, string iDOPCINE);
        int FillPage(OPCINADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

