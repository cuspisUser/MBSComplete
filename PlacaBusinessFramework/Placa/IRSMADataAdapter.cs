namespace Placa
{
    using System;
    using System.Data;

    public interface IRSMADataAdapter
    {
        int Fill(RSMADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RSMADataSet dataSet, string iDENTIFIKATOROBRASCA);
        bool FillByIDENTIFIKATOROBRASCA(RSMADataSet dataSet, string iDENTIFIKATOROBRASCA);
        int FillByIDOBRACUN(RSMADataSet dataSet, string iDOBRACUN);
        int FillByIDRSVRSTEOBRACUNA(RSMADataSet dataSet, string iDRSVRSTEOBRACUNA);
        int FillByIDRSVRSTEOBVEZNIKA(RSMADataSet dataSet, string iDRSVRSTEOBVEZNIKA);
        int FillPage(RSMADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDOBRACUN(RSMADataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int FillPageByIDRSVRSTEOBRACUNA(RSMADataSet dataSet, string iDRSVRSTEOBRACUNA, int startRow, int maxRows);
        int FillPageByIDRSVRSTEOBVEZNIKA(RSMADataSet dataSet, string iDRSVRSTEOBVEZNIKA, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDOBRACUN(string iDOBRACUN);
        int GetRecordCountByIDRSVRSTEOBRACUNA(string iDRSVRSTEOBRACUNA);
        int GetRecordCountByIDRSVRSTEOBVEZNIKA(string iDRSVRSTEOBVEZNIKA);
        int Update(DataSet dataSet);
    }
}

