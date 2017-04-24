namespace Placa
{
    using System;
    using System.Data;

    public interface IAMSKUPINEDataAdapter
    {
        int Fill(AMSKUPINEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(AMSKUPINEDataSet dataSet, int iDAMSKUPINE);
        bool FillByIDAMSKUPINE(AMSKUPINEDataSet dataSet, int iDAMSKUPINE);
        int FillByKTOISPRAVKAIDKONTO(AMSKUPINEDataSet dataSet, string kTOISPRAVKAIDKONTO);
        int FillByKTOIZVORAIDKONTO(AMSKUPINEDataSet dataSet, string kTOIZVORAIDKONTO);
        int FillByKTONABAVKEIDKONTO(AMSKUPINEDataSet dataSet, string kTONABAVKEIDKONTO);
        int FillPage(AMSKUPINEDataSet dataSet, int startRow, int maxRows);
        int FillPageByKTOISPRAVKAIDKONTO(AMSKUPINEDataSet dataSet, string kTOISPRAVKAIDKONTO, int startRow, int maxRows);
        int FillPageByKTOIZVORAIDKONTO(AMSKUPINEDataSet dataSet, string kTOIZVORAIDKONTO, int startRow, int maxRows);
        int FillPageByKTONABAVKEIDKONTO(AMSKUPINEDataSet dataSet, string kTONABAVKEIDKONTO, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByKTOISPRAVKAIDKONTO(string kTOISPRAVKAIDKONTO);
        int GetRecordCountByKTOIZVORAIDKONTO(string kTOIZVORAIDKONTO);
        int GetRecordCountByKTONABAVKEIDKONTO(string kTONABAVKEIDKONTO);
        int Update(DataSet dataSet);
    }
}

