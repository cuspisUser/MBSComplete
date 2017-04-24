namespace Placa
{
    using System;
    using System.Data;

    public interface IS_PLACA_KREDITI_KARTICEDataAdapter
    {
        int Fill(S_PLACA_KREDITI_KARTICEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(S_PLACA_KREDITI_KARTICEDataSet dataSet, string iDOBRACUN);
        int FillPage(S_PLACA_KREDITI_KARTICEDataSet dataSet, int startRow, int maxRows);
        int FillPage(DataSet dataSet, int startRow, int maxRows);
        int FillPage(S_PLACA_KREDITI_KARTICEDataSet dataSet, string iDOBRACUN, int startRow, int maxRows);
        int GetRecordCount(string iDOBRACUN);
    }
}

