namespace Placa
{
    using System;
    using System.Data;

    public interface IELEMENTDataAdapter
    {
        int Fill(ELEMENTDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(ELEMENTDataSet dataSet, int iDELEMENT);
        bool FillByIDELEMENT(ELEMENTDataSet dataSet, int iDELEMENT);
        int FillByIDOSNOVAOSIGURANJA(ELEMENTDataSet dataSet, string iDOSNOVAOSIGURANJA);
        int FillByIDVRSTAELEMENTA(ELEMENTDataSet dataSet, short iDVRSTAELEMENTA);
        int FillPage(ELEMENTDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDOSNOVAOSIGURANJA(ELEMENTDataSet dataSet, string iDOSNOVAOSIGURANJA, int startRow, int maxRows);
        int FillPageByIDVRSTAELEMENTA(ELEMENTDataSet dataSet, short iDVRSTAELEMENTA, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDOSNOVAOSIGURANJA(string iDOSNOVAOSIGURANJA);
        int GetRecordCountByIDVRSTAELEMENTA(short iDVRSTAELEMENTA);
        int Update(DataSet dataSet);
    }
}

