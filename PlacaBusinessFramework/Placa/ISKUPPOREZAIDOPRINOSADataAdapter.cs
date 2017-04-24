namespace Placa
{
    using System;
    using System.Data;

    public interface ISKUPPOREZAIDOPRINOSADataAdapter
    {
        int Fill(SKUPPOREZAIDOPRINOSADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(SKUPPOREZAIDOPRINOSADataSet dataSet, int iDSKUPPOREZAIDOPRINOSA);
        bool FillByIDSKUPPOREZAIDOPRINOSA(SKUPPOREZAIDOPRINOSADataSet dataSet, int iDSKUPPOREZAIDOPRINOSA);
        int FillPage(SKUPPOREZAIDOPRINOSADataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

