namespace Placa
{
    using System;
    using System.Data;

    public interface IDDIZDATAKDataAdapter
    {
        int Fill(DDIZDATAKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DDIZDATAKDataSet dataSet, int dDIDIZDATAK);
        bool FillByDDIDIZDATAK(DDIZDATAKDataSet dataSet, int dDIDIZDATAK);
        int FillPage(DDIZDATAKDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

