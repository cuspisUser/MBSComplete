namespace Placa
{
    using System;
    using System.Data;

    public interface IBOLOVANJEFONDDataAdapter
    {
        int Fill(BOLOVANJEFONDDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(BOLOVANJEFONDDataSet dataSet, int eLEMENTBOLOVANJEIDELEMENT);
        bool FillByELEMENTBOLOVANJEIDELEMENT(BOLOVANJEFONDDataSet dataSet, int eLEMENTBOLOVANJEIDELEMENT);
        int FillPage(BOLOVANJEFONDDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

