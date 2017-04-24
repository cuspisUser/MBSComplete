namespace Placa
{
    using System;
    using System.Data;

    public interface IEVIDENCIJADataAdapter
    {
        int Fill(EVIDENCIJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE, int bROJEVIDENCIJE);
        int FillByIDGODINE(EVIDENCIJADataSet dataSet, short iDGODINE);
        int FillByMJESEC(EVIDENCIJADataSet dataSet, int mJESEC);
        int FillByMJESECIDGODINE(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE);
        bool FillByMJESECIDGODINEBROJEVIDENCIJE(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE, int bROJEVIDENCIJE);
        int FillPage(EVIDENCIJADataSet dataSet, int startRow, int maxRows);
        int FillPageByIDGODINE(EVIDENCIJADataSet dataSet, short iDGODINE, int startRow, int maxRows);
        int FillPageByMJESEC(EVIDENCIJADataSet dataSet, int mJESEC, int startRow, int maxRows);
        int FillPageByMJESECIDGODINE(EVIDENCIJADataSet dataSet, int mJESEC, short iDGODINE, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDGODINE(short iDGODINE);
        int GetRecordCountByMJESEC(int mJESEC);
        int GetRecordCountByMJESECIDGODINE(int mJESEC, short iDGODINE);
        int Update(DataSet dataSet);
    }
}

