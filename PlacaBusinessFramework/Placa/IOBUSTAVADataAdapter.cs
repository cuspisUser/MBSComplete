namespace Placa
{
    using System;
    using System.Data;

    public interface IOBUSTAVADataAdapter
    {
        int Fill(OBUSTAVADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OBUSTAVADataSet dataSet, int iDOBUSTAVA);
        bool FillByIDOBUSTAVA(OBUSTAVADataSet dataSet, int iDOBUSTAVA);
        int FillByVRSTAOBUSTAVE(OBUSTAVADataSet dataSet, short vRSTAOBUSTAVE);
        int FillPage(OBUSTAVADataSet dataSet, int startRow, int maxRows);
        int FillPageByVRSTAOBUSTAVE(OBUSTAVADataSet dataSet, short vRSTAOBUSTAVE, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByVRSTAOBUSTAVE(short vRSTAOBUSTAVE);
        int Update(DataSet dataSet);
    }
}

