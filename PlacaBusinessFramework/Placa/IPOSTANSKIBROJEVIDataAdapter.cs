namespace Placa
{
    using System;
    using System.Data;

    public interface IPOSTANSKIBROJEVIDataAdapter
    {
        int Fill(POSTANSKIBROJEVIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(POSTANSKIBROJEVIDataSet dataSet, string pOSTANSKIBROJ);
        bool FillByPOSTANSKIBROJ(POSTANSKIBROJEVIDataSet dataSet, string pOSTANSKIBROJ);
        int FillPage(POSTANSKIBROJEVIDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

