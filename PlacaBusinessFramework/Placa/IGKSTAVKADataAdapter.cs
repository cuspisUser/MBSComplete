namespace Placa
{
    using System;
    using System.Data;

    public interface IGKSTAVKADataAdapter
    {
        int Fill(GKSTAVKADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(GKSTAVKADataSet dataSet, int iDGKSTAVKA);
        int FillByBROJSTAVKE(GKSTAVKADataSet dataSet, int bROJSTAVKE);
        int FillByGKGODIDGODINE(GKSTAVKADataSet dataSet, short gKGODIDGODINE);
        int FillByIDDOKUMENT(GKSTAVKADataSet dataSet, int iDDOKUMENT);
        int FillByIDDOKUMENTBROJDOKUMENTA(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA);
        int FillByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE);
        bool FillByIDGKSTAVKA(GKSTAVKADataSet dataSet, int iDGKSTAVKA);
        int FillByIDKONTO(GKSTAVKADataSet dataSet, string iDKONTO);
        int FillByIDMJESTOTROSKA(GKSTAVKADataSet dataSet, int iDMJESTOTROSKA);
        int FillByIDORGJED(GKSTAVKADataSet dataSet, int iDORGJED);
        int FillByIDPARTNER(GKSTAVKADataSet dataSet, int iDPARTNER);
        int FillPage(GKSTAVKADataSet dataSet, int startRow, int maxRows);
        int FillPageByBROJSTAVKE(GKSTAVKADataSet dataSet, int bROJSTAVKE, int startRow, int maxRows);
        int FillPageByGKGODIDGODINE(GKSTAVKADataSet dataSet, short gKGODIDGODINE, int startRow, int maxRows);
        int FillPageByIDDOKUMENT(GKSTAVKADataSet dataSet, int iDDOKUMENT, int startRow, int maxRows);
        int FillPageByIDDOKUMENTBROJDOKUMENTA(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA, int startRow, int maxRows);
        int FillPageByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(GKSTAVKADataSet dataSet, int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE, int startRow, int maxRows);
        int FillPageByIDKONTO(GKSTAVKADataSet dataSet, string iDKONTO, int startRow, int maxRows);
        int FillPageByIDMJESTOTROSKA(GKSTAVKADataSet dataSet, int iDMJESTOTROSKA, int startRow, int maxRows);
        int FillPageByIDORGJED(GKSTAVKADataSet dataSet, int iDORGJED, int startRow, int maxRows);
        int FillPageByIDPARTNER(GKSTAVKADataSet dataSet, int iDPARTNER, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByBROJSTAVKE(int bROJSTAVKE);
        int GetRecordCountByGKGODIDGODINE(short gKGODIDGODINE);
        int GetRecordCountByIDDOKUMENT(int iDDOKUMENT);
        int GetRecordCountByIDDOKUMENTBROJDOKUMENTA(int iDDOKUMENT, int bROJDOKUMENTA);
        int GetRecordCountByIDDOKUMENTBROJDOKUMENTAGKGODIDGODINE(int iDDOKUMENT, int bROJDOKUMENTA, short gKGODIDGODINE);
        int GetRecordCountByIDKONTO(string iDKONTO);
        int GetRecordCountByIDMJESTOTROSKA(int iDMJESTOTROSKA);
        int GetRecordCountByIDORGJED(int iDORGJED);
        int GetRecordCountByIDPARTNER(int iDPARTNER);
        int Update(DataSet dataSet);
    }
}

