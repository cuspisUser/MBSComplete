namespace Placa
{
    using System;
    using System.Data;

    public interface IDDRADNIKDataAdapter
    {
        int Fill(DDRADNIKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DDRADNIKDataSet dataSet, int dDIDRADNIK);
        bool FillByDDIDRADNIK(DDRADNIKDataSet dataSet, int dDIDRADNIK);
        int FillByIDBANKE(DDRADNIKDataSet dataSet, int iDBANKE);
        int FillByOPCINARADAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINARADAIDOPCINE);
        int FillByOPCINASTANOVANJAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE);
        int FillPage(DDRADNIKDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDBANKE(DDRADNIKDataSet dataSet, int iDBANKE, int startRow, int maxRows);
        int FillPageByOPCINARADAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINARADAIDOPCINE, int startRow, int maxRows);
        int FillPageByOPCINASTANOVANJAIDOPCINE(DDRADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDBANKE(int iDBANKE);
        int GetRecordCountByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE);
        int GetRecordCountByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE);
        int Update(DataSet dataSet);
    }
}

