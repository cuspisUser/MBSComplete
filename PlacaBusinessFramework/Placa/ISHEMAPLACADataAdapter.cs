namespace Placa
{
    using System;
    using System.Data;

    public interface ISHEMAPLACADataAdapter
    {
        int Fill(SHEMAPLACADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SHEMAPLACADataSet dataSet, int iDSHEMAPLACA);
        bool FillByIDSHEMAPLACA(SHEMAPLACADataSet dataSet, int iDSHEMAPLACA);
        int FillBySHEMAPLOJIDORGJED(SHEMAPLACADataSet dataSet, int sHEMAPLOJIDORGJED);
        int FillPage(SHEMAPLACADataSet dataSet, int startRow, int maxRows);
        int FillPageBySHEMAPLOJIDORGJED(SHEMAPLACADataSet dataSet, int sHEMAPLOJIDORGJED, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountBySHEMAPLOJIDORGJED(int sHEMAPLOJIDORGJED);
        int Update(DataSet dataSet);
    }
}

