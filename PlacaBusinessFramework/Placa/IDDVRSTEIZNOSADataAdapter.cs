namespace Placa
{
    using System;
    using System.Data;

    public interface IDDVRSTEIZNOSADataAdapter
    {
        int Fill(DDVRSTEIZNOSADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DDVRSTEIZNOSADataSet dataSet, int iDDDVRSTEIZNOSA);
        bool FillByIDDDVRSTEIZNOSA(DDVRSTEIZNOSADataSet dataSet, int iDDDVRSTEIZNOSA);
        int FillPage(DDVRSTEIZNOSADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

