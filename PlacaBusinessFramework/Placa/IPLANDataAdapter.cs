namespace Placa
{
    using System;
    using System.Data;

    public interface IPLANDataAdapter
    {
        int Fill(PLANDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(PLANDataSet dataSet, int iDPLAN, short pLANGODINAIDGODINE);
        int FillByIDPLAN(PLANDataSet dataSet, int iDPLAN);
        bool FillByIDPLANPLANGODINAIDGODINE(PLANDataSet dataSet, int iDPLAN, short pLANGODINAIDGODINE);
        int FillByPLANGODINAIDGODINE(PLANDataSet dataSet, short pLANGODINAIDGODINE);
        int FillPage(PLANDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDPLAN(PLANDataSet dataSet, int iDPLAN, int startRow, int maxRows);
        int FillPageByPLANGODINAIDGODINE(PLANDataSet dataSet, short pLANGODINAIDGODINE, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDPLAN(int iDPLAN);
        int GetRecordCountByPLANGODINAIDGODINE(short pLANGODINAIDGODINE);
        int Update(DataSet dataSet);
    }
}

