namespace Placa
{
    using System;
    using System.Data;

    public interface Isp_id_detaljiDataAdapter
    {
        int Fill(sp_id_detaljiDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(sp_id_detaljiDataSet dataSet, string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI);
        int FillPage(sp_id_detaljiDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(sp_id_detaljiDataSet dataSet, string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI, int startRow, int maxRows);
        int GetRecordCount(string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI);
    }
}

