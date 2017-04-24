namespace Placa
{
    using System;
    using System.Data;

    public interface IVALUTEDataAdapter
    {
        int Fill(VALUTEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(VALUTEDataSet dataSet, int iDVALUTA);
        bool FillByIDVALUTA(VALUTEDataSet dataSet, int iDVALUTA);
        int FillPage(VALUTEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

