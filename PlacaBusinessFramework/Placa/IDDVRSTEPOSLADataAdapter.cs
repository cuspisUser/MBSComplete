namespace Placa
{
    using System;
    using System.Data;

    public interface IDDVRSTEPOSLADataAdapter
    {
        int Fill(DDVRSTEPOSLADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DDVRSTEPOSLADataSet dataSet, int dDIDVRSTAPOSLA);
        bool FillByDDIDVRSTAPOSLA(DDVRSTEPOSLADataSet dataSet, int dDIDVRSTAPOSLA);
        int FillPage(DDVRSTEPOSLADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

