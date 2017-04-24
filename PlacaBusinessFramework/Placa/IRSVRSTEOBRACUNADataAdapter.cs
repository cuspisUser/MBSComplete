namespace Placa
{
    using System;
    using System.Data;

    public interface IRSVRSTEOBRACUNADataAdapter
    {
        int Fill(RSVRSTEOBRACUNADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RSVRSTEOBRACUNADataSet dataSet, string iDRSVRSTEOBRACUNA);
        bool FillByIDRSVRSTEOBRACUNA(RSVRSTEOBRACUNADataSet dataSet, string iDRSVRSTEOBRACUNA);
        int FillPage(RSVRSTEOBRACUNADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

