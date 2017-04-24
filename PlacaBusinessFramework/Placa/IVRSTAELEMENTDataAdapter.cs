namespace Placa
{
    using System;
    using System.Data;

    public interface IVRSTAELEMENTDataAdapter
    {
        int Fill(VRSTAELEMENTDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(VRSTAELEMENTDataSet dataSet, short iDVRSTAELEMENTA);
        bool FillByIDVRSTAELEMENTA(VRSTAELEMENTDataSet dataSet, short iDVRSTAELEMENTA);
        int FillPage(VRSTAELEMENTDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

