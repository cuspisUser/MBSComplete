namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_VIRMANIDataAdapter
    {
        int Fill(sp_VIRMANIDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_VIRMANIDataSet dataSet, string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd);
        int FillPage(sp_VIRMANIDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_VIRMANIDataSet dataSet, string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd);
    }
}

