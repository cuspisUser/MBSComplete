namespace Placa
{
    using System;
    using System.Data;

    public interface IVRSTAOBUSTAVEDataAdapter
    {
        int Fill(VRSTAOBUSTAVEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(VRSTAOBUSTAVEDataSet dataSet, short vRSTAOBUSTAVE);
        bool FillByVRSTAOBUSTAVE(VRSTAOBUSTAVEDataSet dataSet, short vRSTAOBUSTAVE);
        int FillPage(VRSTAOBUSTAVEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

