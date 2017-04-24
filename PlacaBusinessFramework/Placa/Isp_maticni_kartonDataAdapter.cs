namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_maticni_kartonDataAdapter
    {
        int Fill(sp_maticni_kartonDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_maticni_kartonDataSet dataSet, string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata);
        int FillPage(sp_maticni_kartonDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_maticni_kartonDataSet dataSet, string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata, int startRow, int maxRows);
        int GetRecordCount(string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata);
    }
}

