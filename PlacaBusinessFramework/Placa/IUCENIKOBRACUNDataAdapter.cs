namespace Placa
{
    using System;
    using System.Data;

    public interface IUCENIKOBRACUNDataAdapter
    {
        int Fill(UCENIKOBRACUNDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC, int uCOBRGODINA);
        int FillByUCOBRMJESEC(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC);
        bool FillByUCOBRMJESECUCOBRGODINA(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC, int uCOBRGODINA);
        int FillPage(UCENIKOBRACUNDataSet dataSet, int startRow, int maxRows);
        int FillPageByUCOBRMJESEC(UCENIKOBRACUNDataSet dataSet, int uCOBRMJESEC, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByUCOBRMJESEC(int uCOBRMJESEC);
        int Update(DataSet dataSet);
    }
}

