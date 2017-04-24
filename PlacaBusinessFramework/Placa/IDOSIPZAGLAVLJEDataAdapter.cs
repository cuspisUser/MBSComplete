namespace Placa
{
    using System;
    using System.Data;

    public interface IDOSIPZAGLAVLJEDataAdapter
    {
        int Fill(DOSIPZAGLAVLJEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT, string dOSJMBG);
        int FillByDOSIPIDENT(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT);
        bool FillByDOSIPIDENTDOSJMBG(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT, string dOSJMBG);
        int FillPage(DOSIPZAGLAVLJEDataSet dataSet, int startRow, int maxRows);
        int FillPageByDOSIPIDENT(DOSIPZAGLAVLJEDataSet dataSet, string dOSIPIDENT, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByDOSIPIDENT(string dOSIPIDENT);
        int Update(DataSet dataSet);
    }
}

