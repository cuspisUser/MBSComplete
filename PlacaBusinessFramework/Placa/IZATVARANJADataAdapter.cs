namespace Placa
{
    using System;
    using System.Data;

    public interface IZATVARANJADataAdapter
    {
        int Fill(ZATVARANJADataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA, int gK2IDGKSTAVKA);
        int FillByGK1IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA);
        bool FillByGK1IDGKSTAVKAGK2IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA, int gK2IDGKSTAVKA);
        int FillByGK2IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK2IDGKSTAVKA);
        int FillPage(ZATVARANJADataSet dataSet, int startRow, int maxRows);
        int FillPageByGK1IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK1IDGKSTAVKA, int startRow, int maxRows);
        int FillPageByGK2IDGKSTAVKA(ZATVARANJADataSet dataSet, int gK2IDGKSTAVKA, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByGK1IDGKSTAVKA(int gK1IDGKSTAVKA);
        int GetRecordCountByGK2IDGKSTAVKA(int gK2IDGKSTAVKA);
        int Update(DataSet dataSet);
    }
}

