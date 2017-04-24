namespace Placa
{
    using System;
    using System.Data;

    public interface IRSVRSTEOBVEZNIKADataAdapter
    {
        int Fill(RSVRSTEOBVEZNIKADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RSVRSTEOBVEZNIKADataSet dataSet, string iDRSVRSTEOBVEZNIKA);
        bool FillByIDRSVRSTEOBVEZNIKA(RSVRSTEOBVEZNIKADataSet dataSet, string iDRSVRSTEOBVEZNIKA);
        int FillPage(RSVRSTEOBVEZNIKADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

