namespace Placa
{
    using System;
    using System.Data;

    public interface ITIPOLAKSICEDataAdapter
    {
        int Fill(TIPOLAKSICEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(TIPOLAKSICEDataSet dataSet, int iDTIPOLAKSICE);
        bool FillByIDTIPOLAKSICE(TIPOLAKSICEDataSet dataSet, int iDTIPOLAKSICE);
        int FillPage(TIPOLAKSICEDataSet dataSet, int startRow, int maxRows);
        int GetRecordCount();
        int Update(DataSet dataSet);
    }
}

