namespace Placa
{
    using System;
    using System.Data;

    public interface IUGOVORORADUDataAdapter
    {
        int Fill(UGOVORORADUDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(UGOVORORADUDataSet dataSet, int iDUGOVORORADU);
        bool FillByIDUGOVORORADU(UGOVORORADUDataSet dataSet, int iDUGOVORORADU);
        int FillPage(UGOVORORADUDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

