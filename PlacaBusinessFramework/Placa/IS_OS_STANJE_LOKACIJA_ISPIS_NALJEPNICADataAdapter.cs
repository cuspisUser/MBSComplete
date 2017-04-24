namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataAdapter
    {
        int Fill(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet, int iDLOKACIJE);
        int FillPage(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet dataSet, int iDLOKACIJE, int startRow, int maxRows);
        int GetRecordCount(int iDLOKACIJE);
    }
}

