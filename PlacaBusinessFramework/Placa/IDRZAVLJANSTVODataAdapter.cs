namespace Placa
{
    using System;
    using System.Data;

    public interface IDRZAVLJANSTVODataAdapter
    {
        int Fill(DRZAVLJANSTVODataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DRZAVLJANSTVODataSet dataSet, int iDDRZAVLJANSTVO);
        bool FillByIDDRZAVLJANSTVO(DRZAVLJANSTVODataSet dataSet, int iDDRZAVLJANSTVO);
        int FillPage(DRZAVLJANSTVODataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

