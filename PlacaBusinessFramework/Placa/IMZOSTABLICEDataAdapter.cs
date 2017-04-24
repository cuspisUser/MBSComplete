namespace Placa
{
    using System;
    using System.Data;

    public interface IMZOSTABLICEDataAdapter
    {
        int Fill(MZOSTABLICEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(MZOSTABLICEDataSet dataSet, int iDMZOSTABLICE);
        bool FillByIDMZOSTABLICE(MZOSTABLICEDataSet dataSet, int iDMZOSTABLICE);
        int FillPage(MZOSTABLICEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

