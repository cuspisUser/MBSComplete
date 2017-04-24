namespace Placa
{
    using System;
    using System.Data;

    public interface IJEDINICAMJEREDataAdapter
    {
        int Fill(JEDINICAMJEREDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(JEDINICAMJEREDataSet dataSet, int iDJEDINICAMJERE);
        bool FillByIDJEDINICAMJERE(JEDINICAMJEREDataSet dataSet, int iDJEDINICAMJERE);
        int FillPage(JEDINICAMJEREDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

