namespace Placa
{
    using System;
    using System.Data;

    public interface ISHEMAURADataAdapter
    {
        int Fill(SHEMAURADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SHEMAURADataSet dataSet, int iDSHEMAURA);
        bool FillByIDSHEMAURA(SHEMAURADataSet dataSet, int iDSHEMAURA);
        int FillByPARTNERSHEMAURAIDPARTNER(SHEMAURADataSet dataSet, int pARTNERSHEMAURAIDPARTNER);
        int FillPage(SHEMAURADataSet dataSet, int startRow, int maxRows);
        int FillPageByPARTNERSHEMAURAIDPARTNER(SHEMAURADataSet dataSet, int pARTNERSHEMAURAIDPARTNER, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByPARTNERSHEMAURAIDPARTNER(int pARTNERSHEMAURAIDPARTNER);
        int Update(DataSet dataSet);
    }
}

