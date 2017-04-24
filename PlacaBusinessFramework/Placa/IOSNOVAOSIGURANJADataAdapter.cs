namespace Placa
{
    using System;
    using System.Data;

    public interface IOSNOVAOSIGURANJADataAdapter
    {
        int Fill(OSNOVAOSIGURANJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OSNOVAOSIGURANJADataSet dataSet, string iDOSNOVAOSIGURANJA);
        bool FillByIDOSNOVAOSIGURANJA(OSNOVAOSIGURANJADataSet dataSet, string iDOSNOVAOSIGURANJA);
        int FillByZAMOOIDOSNOVAOSIGURANJA(OSNOVAOSIGURANJADataSet dataSet, string zAMOOIDOSNOVAOSIGURANJA);
        int FillPage(OSNOVAOSIGURANJADataSet dataSet, int startRow, int maxRows);
        int FillPageByZAMOOIDOSNOVAOSIGURANJA(OSNOVAOSIGURANJADataSet dataSet, string zAMOOIDOSNOVAOSIGURANJA, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByZAMOOIDOSNOVAOSIGURANJA(string zAMOOIDOSNOVAOSIGURANJA);
        int Update(DataSet dataSet);
    }
}

