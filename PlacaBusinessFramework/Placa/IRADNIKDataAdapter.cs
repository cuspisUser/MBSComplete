namespace Placa
{
    using System;
    using System.Data;

    public interface IRADNIKDataAdapter
    {
        int Fill(RADNIKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RADNIKDataSet dataSet, int iDRADNIK);
        int FillByIDBANKE(RADNIKDataSet dataSet, int iDBANKE);
        int FillByIDBENEFICIRANI(RADNIKDataSet dataSet, string iDBENEFICIRANI);
        int FillByIDBRACNOSTANJE(RADNIKDataSet dataSet, int iDBRACNOSTANJE);
        int FillByIDDRZAVLJANSTVO(RADNIKDataSet dataSet, int iDDRZAVLJANSTVO);
        int FillByIDIPIDENT(RADNIKDataSet dataSet, int iDIPIDENT);
        int FillByIDORGDIO(RADNIKDataSet dataSet, int iDORGDIO);
        bool FillByIDRADNIK(RADNIKDataSet dataSet, int iDRADNIK);
        int FillByIDRADNOMJESTO(RADNIKDataSet dataSet, int iDRADNOMJESTO);
        int FillByIDRADNOVRIJEME(RADNIKDataSet dataSet, int iDRADNOVRIJEME);
        int FillByIDSPOL(RADNIKDataSet dataSet, int iDSPOL);
        int FillByIDSTRUKA(RADNIKDataSet dataSet, int iDSTRUKA);
        int FillByIDTITULA(RADNIKDataSet dataSet, int iDTITULA);
        int FillByIDUGOVORORADU(RADNIKDataSet dataSet, int iDUGOVORORADU);
        int FillByJMBG(RADNIKDataSet dataSet, string jMBG);
        int FillByOPCINARADAIDOPCINE(RADNIKDataSet dataSet, string oPCINARADAIDOPCINE);
        int FillByOPCINASTANOVANJAIDOPCINE(RADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE);
        int FillByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
        int FillByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(RADNIKDataSet dataSet, int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
        int FillByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
        int FillPage(RADNIKDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDBANKE(RADNIKDataSet dataSet, int iDBANKE, int startRow, int maxRows);
        int FillPageByIDBENEFICIRANI(RADNIKDataSet dataSet, string iDBENEFICIRANI, int startRow, int maxRows);
        int FillPageByIDBRACNOSTANJE(RADNIKDataSet dataSet, int iDBRACNOSTANJE, int startRow, int maxRows);
        int FillPageByIDDRZAVLJANSTVO(RADNIKDataSet dataSet, int iDDRZAVLJANSTVO, int startRow, int maxRows);
        int FillPageByIDIPIDENT(RADNIKDataSet dataSet, int iDIPIDENT, int startRow, int maxRows);
        int FillPageByIDORGDIO(RADNIKDataSet dataSet, int iDORGDIO, int startRow, int maxRows);
        int FillPageByIDRADNOMJESTO(RADNIKDataSet dataSet, int iDRADNOMJESTO, int startRow, int maxRows);
        int FillPageByIDRADNOVRIJEME(RADNIKDataSet dataSet, int iDRADNOVRIJEME, int startRow, int maxRows);
        int FillPageByIDSPOL(RADNIKDataSet dataSet, int iDSPOL, int startRow, int maxRows);
        int FillPageByIDSTRUKA(RADNIKDataSet dataSet, int iDSTRUKA, int startRow, int maxRows);
        int FillPageByIDTITULA(RADNIKDataSet dataSet, int iDTITULA, int startRow, int maxRows);
        int FillPageByIDUGOVORORADU(RADNIKDataSet dataSet, int iDUGOVORORADU, int startRow, int maxRows);
        int FillPageByJMBG(RADNIKDataSet dataSet, string jMBG, int startRow, int maxRows);
        int FillPageByOPCINARADAIDOPCINE(RADNIKDataSet dataSet, string oPCINARADAIDOPCINE, int startRow, int maxRows);
        int FillPageByOPCINASTANOVANJAIDOPCINE(RADNIKDataSet dataSet, string oPCINASTANOVANJAIDOPCINE, int startRow, int maxRows);
        int FillPageByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA, int startRow, int maxRows);
        int FillPageByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(RADNIKDataSet dataSet, int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA, int startRow, int maxRows);
        int FillPageByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(RADNIKDataSet dataSet, int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDBANKE(int iDBANKE);
        int GetRecordCountByIDBENEFICIRANI(string iDBENEFICIRANI);
        int GetRecordCountByIDBRACNOSTANJE(int iDBRACNOSTANJE);
        int GetRecordCountByIDDRZAVLJANSTVO(int iDDRZAVLJANSTVO);
        int GetRecordCountByIDIPIDENT(int iDIPIDENT);
        int GetRecordCountByIDORGDIO(int iDORGDIO);
        int GetRecordCountByIDRADNOMJESTO(int iDRADNOMJESTO);
        int GetRecordCountByIDRADNOVRIJEME(int iDRADNOVRIJEME);
        int GetRecordCountByIDSPOL(int iDSPOL);
        int GetRecordCountByIDSTRUKA(int iDSTRUKA);
        int GetRecordCountByIDTITULA(int iDTITULA);
        int GetRecordCountByIDUGOVORORADU(int iDUGOVORORADU);
        int GetRecordCountByJMBG(string jMBG);
        int GetRecordCountByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE);
        int GetRecordCountByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE);
        int GetRecordCountByPOTREBNASTRUCNASPREMAIDSTRUCNASPREMA(int pOTREBNASTRUCNASPREMAIDSTRUCNASPREMA);
        int GetRecordCountByRADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA(int rADNIKPOREZIDOPRINOSIDSKUPPOREZAIDOPRINOSA);
        int GetRecordCountByTRENUTNASTRUCNASPREMAIDSTRUCNASPREMA(int tRENUTNASTRUCNASPREMAIDSTRUCNASPREMA);
        int Update(DataSet dataSet);
    }
}

