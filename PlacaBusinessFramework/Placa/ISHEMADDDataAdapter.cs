namespace Placa
{
    using System;
    using System.Data;

    public interface ISHEMADDDataAdapter
    {
        int Fill(SHEMADDDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SHEMADDDataSet dataSet, int iDSHEMADD);
        bool FillByIDSHEMADD(SHEMADDDataSet dataSet, int iDSHEMADD);
        int FillBySHEMADDOJIDORGJED(SHEMADDDataSet dataSet, int sHEMADDOJIDORGJED);
        int FillPage(SHEMADDDataSet dataSet, int startRow, int maxRows);
        int FillPageBySHEMADDOJIDORGJED(SHEMADDDataSet dataSet, int sHEMADDOJIDORGJED, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountBySHEMADDOJIDORGJED(int sHEMADDOJIDORGJED);
        int Update(DataSet dataSet);
    }
}

