namespace Placa
{
    using System;
    using System.Data;

    public interface IPLVRSTEIZNOSADataAdapter
    {
        int Fill(PLVRSTEIZNOSADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(PLVRSTEIZNOSADataSet dataSet, int iDPLVRSTEIZNOSA);
        bool FillByIDPLVRSTEIZNOSA(PLVRSTEIZNOSADataSet dataSet, int iDPLVRSTEIZNOSA);
        int FillPage(PLVRSTEIZNOSADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

