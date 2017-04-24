namespace Placa
{
    using System;
    using System.Data;

    public interface IUCENIKDataAdapter
    {
        int Fill(UCENIKDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(UCENIKDataSet dataSet, int iDUCENIK);
        bool FillByIDUCENIK(UCENIKDataSet dataSet, int iDUCENIK);
        int FillByPOSTANSKIBROJ(UCENIKDataSet dataSet, string pOSTANSKIBROJ);
        int FillPage(UCENIKDataSet dataSet, int startRow, int maxRows);
        int FillPageByPOSTANSKIBROJ(UCENIKDataSet dataSet, string pOSTANSKIBROJ, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByPOSTANSKIBROJ(string pOSTANSKIBROJ);
        int Update(DataSet dataSet);
    }
}

