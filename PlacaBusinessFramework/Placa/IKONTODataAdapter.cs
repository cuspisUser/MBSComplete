namespace Placa
{
    using System;
    using System.Data;

    public interface IKONTODataAdapter
    {
        int Fill(KONTODataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(KONTODataSet dataSet, string iDKONTO);
        int FillByIDAKTIVNOST(KONTODataSet dataSet, int iDAKTIVNOST);
        bool FillByIDKONTO(KONTODataSet dataSet, string iDKONTO);
        int FillPage(KONTODataSet dataSet, int startRow, int maxRows);
        int FillPageByIDAKTIVNOST(KONTODataSet dataSet, int iDAKTIVNOST, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDAKTIVNOST(int iDAKTIVNOST);
        int Update(DataSet dataSet);
    }
}

