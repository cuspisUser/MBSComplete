namespace Placa
{
    using System;
    using System.Data;

    public interface ISMJENEDataAdapter
    {
        int Fill(SMJENEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SMJENEDataSet dataSet, int iDSMJENE);
        bool FillByIDSMJENE(SMJENEDataSet dataSet, int iDSMJENE);
        int FillPage(SMJENEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

