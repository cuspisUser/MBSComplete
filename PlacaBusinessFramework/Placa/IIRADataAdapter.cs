namespace Placa
{
    using System;
    using System.Data;

    public interface IIRADataAdapter
    {
        int Fill(IRADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int iRABROJ);
        int FillByIDTIPIRA(IRADataSet dataSet, int iDTIPIRA);
        int FillByIRADOKIDDOKUMENT(IRADataSet dataSet, int iRADOKIDDOKUMENT);
        int FillByIRAGODIDGODINE(IRADataSet dataSet, short iRAGODIDGODINE);
        int FillByIRAGODIDGODINEIRADOKIDDOKUMENT(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT);
        bool FillByIRAGODIDGODINEIRADOKIDDOKUMENTIRABROJ(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int iRABROJ);
        int FillByIRAPARTNERIDPARTNER(IRADataSet dataSet, int iRAPARTNERIDPARTNER);
        int FillPage(IRADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDTIPIRA(IRADataSet dataSet, int iDTIPIRA, int startRow, int maxRows);
        int FillPageByIRADOKIDDOKUMENT(IRADataSet dataSet, int iRADOKIDDOKUMENT, int startRow, int maxRows);
        int FillPageByIRAGODIDGODINE(IRADataSet dataSet, short iRAGODIDGODINE, int startRow, int maxRows);
        int FillPageByIRAGODIDGODINEIRADOKIDDOKUMENT(IRADataSet dataSet, short iRAGODIDGODINE, int iRADOKIDDOKUMENT, int startRow, int maxRows);
        int FillPageByIRAPARTNERIDPARTNER(IRADataSet dataSet, int iRAPARTNERIDPARTNER, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDTIPIRA(int iDTIPIRA);
        int GetRecordCountByIRADOKIDDOKUMENT(int iRADOKIDDOKUMENT);
        int GetRecordCountByIRAGODIDGODINE(short iRAGODIDGODINE);
        int GetRecordCountByIRAGODIDGODINEIRADOKIDDOKUMENT(short iRAGODIDGODINE, int iRADOKIDDOKUMENT);
        int GetRecordCountByIRAPARTNERIDPARTNER(int iRAPARTNERIDPARTNER);
        int Update(DataSet dataSet);
    }
}

