namespace Placa
{
    using System;
    using System.Data;

    public interface IPROIZVODDataAdapter
    {
        int Fill(PROIZVODDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(PROIZVODDataSet dataSet, int iDPROIZVOD);
        int FillByFINPOREZIDPOREZ(PROIZVODDataSet dataSet, int fINPOREZIDPOREZ);
        int FillByIDJEDINICAMJERE(PROIZVODDataSet dataSet, int iDJEDINICAMJERE);
        bool FillByIDPROIZVOD(PROIZVODDataSet dataSet, int iDPROIZVOD);
        int FillPage(PROIZVODDataSet dataSet, int startRow, int maxRows);
        int FillPageByFINPOREZIDPOREZ(PROIZVODDataSet dataSet, int fINPOREZIDPOREZ, int startRow, int maxRows);
        int FillPageByIDJEDINICAMJERE(PROIZVODDataSet dataSet, int iDJEDINICAMJERE, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByFINPOREZIDPOREZ(int fINPOREZIDPOREZ);
        int GetRecordCountByIDJEDINICAMJERE(int iDJEDINICAMJERE);
        int Update(DataSet dataSet);
    }
}

