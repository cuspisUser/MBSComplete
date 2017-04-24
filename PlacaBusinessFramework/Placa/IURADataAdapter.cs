namespace Placa
{
    using System;
    using System.Data;

    public interface IURADataAdapter
    {
        int Fill(URADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int uRABROJ);
        int FillByIDTIPURA(URADataSet dataSet, int iDTIPURA);
        int FillByURADOKIDDOKUMENT(URADataSet dataSet, int uRADOKIDDOKUMENT);
        int FillByURAGODIDGODINE(URADataSet dataSet, short uRAGODIDGODINE);
        int FillByURAGODIDGODINEURADOKIDDOKUMENT(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT);
        bool FillByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int uRABROJ);
        int FillByurapartnerIDPARTNER(URADataSet dataSet, int urapartnerIDPARTNER);
        int FillPage(URADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDTIPURA(URADataSet dataSet, int iDTIPURA, int startRow, int maxRows);
        int FillPageByURADOKIDDOKUMENT(URADataSet dataSet, int uRADOKIDDOKUMENT, int startRow, int maxRows);
        int FillPageByURAGODIDGODINE(URADataSet dataSet, short uRAGODIDGODINE, int startRow, int maxRows);
        int FillPageByURAGODIDGODINEURADOKIDDOKUMENT(URADataSet dataSet, short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int startRow, int maxRows);
        int FillPageByurapartnerIDPARTNER(URADataSet dataSet, int urapartnerIDPARTNER, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDTIPURA(int iDTIPURA);
        int GetRecordCountByURADOKIDDOKUMENT(int uRADOKIDDOKUMENT);
        int GetRecordCountByURAGODIDGODINE(short uRAGODIDGODINE);
        int GetRecordCountByURAGODIDGODINEURADOKIDDOKUMENT(short uRAGODIDGODINE, int uRADOKIDDOKUMENT);
        int GetRecordCountByurapartnerIDPARTNER(int urapartnerIDPARTNER);
        int Update(DataSet dataSet);
    }
}

