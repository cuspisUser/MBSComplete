namespace Placa
{
    using System;
    using System.Data;

    public interface IPRPLACEDataAdapter
    {
        int Fill(PRPLACEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(PRPLACEDataSet dataSet, short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU);
        int FillByPRPLACEID(PRPLACEDataSet dataSet, int pRPLACEID);
        int FillByPRPLACEIDPRPLACEZAMJESEC(PRPLACEDataSet dataSet, int pRPLACEID, short pRPLACEZAMJESEC);
        bool FillByPRPLACEZAMJESECPRPLACEIDPRPLACEZAGODINU(PRPLACEDataSet dataSet, short pRPLACEZAMJESEC, int pRPLACEID, short pRPLACEZAGODINU);
        int FillPage(PRPLACEDataSet dataSet, int startRow, int maxRows);
        int FillPageByPRPLACEID(PRPLACEDataSet dataSet, int pRPLACEID, int startRow, int maxRows);
        int FillPageByPRPLACEIDPRPLACEZAMJESEC(PRPLACEDataSet dataSet, int pRPLACEID, short pRPLACEZAMJESEC, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByPRPLACEID(int pRPLACEID);
        int GetRecordCountByPRPLACEIDPRPLACEZAMJESEC(int pRPLACEID, short pRPLACEZAMJESEC);
        int Update(DataSet dataSet);
    }
}

