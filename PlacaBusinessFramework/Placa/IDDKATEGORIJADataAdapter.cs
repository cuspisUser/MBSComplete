namespace Placa
{
    using System;
    using System.Data;

    public interface IDDKATEGORIJADataAdapter
    {
        int Fill(DDKATEGORIJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DDKATEGORIJADataSet dataSet, int iDKATEGORIJA);
        bool FillByIDKATEGORIJA(DDKATEGORIJADataSet dataSet, int iDKATEGORIJA);
        int FillByIDKOLONAIDD(DDKATEGORIJADataSet dataSet, int iDKOLONAIDD);
        int FillPage(DDKATEGORIJADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDKOLONAIDD(DDKATEGORIJADataSet dataSet, int iDKOLONAIDD, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDKOLONAIDD(int iDKOLONAIDD);
        int Update(DataSet dataSet);
    }
}

