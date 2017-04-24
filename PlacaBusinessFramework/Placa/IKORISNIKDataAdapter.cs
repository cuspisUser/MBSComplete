namespace Placa
{
    using System;
    using System.Data;

    public interface IKORISNIKDataAdapter
    {
        int Fill(KORISNIKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(KORISNIKDataSet dataSet, int iDKORISNIK);
        bool FillByIDKORISNIK(KORISNIKDataSet dataSet, int iDKORISNIK);
        int FillPage(KORISNIKDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

