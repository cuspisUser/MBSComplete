namespace Placa
{
    using System;
    using System.Data;

    public interface IOLAKSICEDataAdapter
    {
        int Fill(OLAKSICEDataSet dataSet);
        int Fill(DataSet dataSet);
        int Fill(OLAKSICEDataSet dataSet, int iDOLAKSICE);
        int FillByIDGRUPEOLAKSICA(OLAKSICEDataSet dataSet, int iDGRUPEOLAKSICA);
        bool FillByIDOLAKSICE(OLAKSICEDataSet dataSet, int iDOLAKSICE);
        int FillByIDTIPOLAKSICE(OLAKSICEDataSet dataSet, int iDTIPOLAKSICE);
        int FillPage(OLAKSICEDataSet dataSet, int startRow, int maxRows);
        int FillPageByIDGRUPEOLAKSICA(OLAKSICEDataSet dataSet, int iDGRUPEOLAKSICA, int startRow, int maxRows);
        int FillPageByIDTIPOLAKSICE(OLAKSICEDataSet dataSet, int iDTIPOLAKSICE, int startRow, int maxRows);
        int GetRecordCount();
        int GetRecordCountByIDGRUPEOLAKSICA(int iDGRUPEOLAKSICA);
        int GetRecordCountByIDTIPOLAKSICE(int iDTIPOLAKSICE);
        int Update(DataSet dataSet);
    }
}

