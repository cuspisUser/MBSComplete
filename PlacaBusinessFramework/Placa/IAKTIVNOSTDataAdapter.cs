namespace Placa
{
    using System;
    using System.Data;

    public interface IAKTIVNOSTDataAdapter
    {
        int Fill(AKTIVNOSTDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(AKTIVNOSTDataSet dataSet, int iDAKTIVNOST);
        bool FillByIDAKTIVNOST(AKTIVNOSTDataSet dataSet, int iDAKTIVNOST);
        int FillPage(AKTIVNOSTDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

