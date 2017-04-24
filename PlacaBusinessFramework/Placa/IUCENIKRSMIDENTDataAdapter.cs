namespace Placa
{
    using System;
    using System.Data;

    public interface IUCENIKRSMIDENTDataAdapter
    {
        int Fill(UCENIKRSMIDENTDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(UCENIKRSMIDENTDataSet dataSet, string uCENIKRSMIDENT);
        bool FillByUCENIKRSMIDENT(UCENIKRSMIDENTDataSet dataSet, string uCENIKRSMIDENT);
        int FillPage(UCENIKRSMIDENTDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

