namespace Placa
{
    using System;
    using System.Data;

    public interface IBLAGAJNADataAdapter
    {
        int Fill(BLAGAJNADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(BLAGAJNADataSet dataSet, int bLGDOKIDDOKUMENT);
        bool FillByBLGDOKIDDOKUMENT(BLAGAJNADataSet dataSet, int bLGDOKIDDOKUMENT);
        int FillByBLGKONTOIDKONTO(BLAGAJNADataSet dataSet, string bLGKONTOIDKONTO);
        int FillPage(BLAGAJNADataSet dataSet, int startRow, int maxRows);
        int FillPageByBLGKONTOIDKONTO(BLAGAJNADataSet dataSet, string bLGKONTOIDKONTO, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByBLGKONTOIDKONTO(string bLGKONTOIDKONTO);
        int Update(DataSet dataSet);
    }
}

