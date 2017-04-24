namespace Placa
{
    using System;
    using System.Data;

    public interface IS_OS_REKAP_TEMELJNICEDataAdapter
    {
        int Fill(S_OS_REKAP_TEMELJNICEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_OS_REKAP_TEMELJNICEDataSet dataSet, int bROJOSTEMELJNICE, int vrstaostemeljnice);
        int FillPage(S_OS_REKAP_TEMELJNICEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_OS_REKAP_TEMELJNICEDataSet dataSet, int bROJOSTEMELJNICE, int vrstaostemeljnice, int startRow, int maxRows);
        int GetRecordCount(int bROJOSTEMELJNICE, int vrstaostemeljnice);
    }
}

