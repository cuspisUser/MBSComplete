namespace Placa
{
    using System;
    using System.Data;

    public interface IRACUNDataAdapter
    {
        int Fill(RACUNDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(RACUNDataSet dataSet, int iDRACUN, short rACUNGODINAIDGODINE);
        int FillByIDPARTNER(RACUNDataSet dataSet, int iDPARTNER);
        int FillByIDRACUN(RACUNDataSet dataSet, int iDRACUN);
        bool FillByIDRACUNRACUNGODINAIDGODINE(RACUNDataSet dataSet, int iDRACUN, short rACUNGODINAIDGODINE);
        int FillByRACUNGODINAIDGODINE(RACUNDataSet dataSet, short rACUNGODINAIDGODINE);
        int FillPage(RACUNDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDPARTNER(RACUNDataSet dataSet, int iDPARTNER, int startRow, int maxRows);
        int FillPageByIDRACUN(RACUNDataSet dataSet, int iDRACUN, int startRow, int maxRows);
        int FillPageByRACUNGODINAIDGODINE(RACUNDataSet dataSet, short rACUNGODINAIDGODINE, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDPARTNER(int iDPARTNER);
        int GetRecordCountByIDRACUN(int iDRACUN);
        int GetRecordCountByRACUNGODINAIDGODINE(short rACUNGODINAIDGODINE);
        int Update(DataSet dataSet);
    }
}

