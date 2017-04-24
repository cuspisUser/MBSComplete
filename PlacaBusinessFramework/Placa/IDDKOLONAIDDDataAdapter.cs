namespace Placa
{
    using System;
    using System.Data;

    public interface IDDKOLONAIDDDataAdapter
    {
        int Fill(DDKOLONAIDDDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DDKOLONAIDDDataSet dataSet, int iDKOLONAIDD);
        bool FillByIDKOLONAIDD(DDKOLONAIDDDataSet dataSet, int iDKOLONAIDD);
        int FillPage(DDKOLONAIDDDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

