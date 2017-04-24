namespace Placa
{
    using System;
    using System.Data;

    public interface ISHEMAIRADataAdapter
    {
        int Fill(SHEMAIRADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SHEMAIRADataSet dataSet, int iDSHEMAIRA);
        bool FillByIDSHEMAIRA(SHEMAIRADataSet dataSet, int iDSHEMAIRA);
        int FillBySHEMAIRADOKIDDOKUMENT(SHEMAIRADataSet dataSet, int sHEMAIRADOKIDDOKUMENT);
        int FillPage(SHEMAIRADataSet dataSet, int startRow, int maxRows);
        int FillPageBySHEMAIRADOKIDDOKUMENT(SHEMAIRADataSet dataSet, int sHEMAIRADOKIDDOKUMENT, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountBySHEMAIRADOKIDDOKUMENT(int sHEMAIRADOKIDDOKUMENT);
        int Update(DataSet dataSet);
    }
}

