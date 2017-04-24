namespace Deklarit.Practices.CompositeUI.NetAdvantage.Services
{
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Utils;
    using Infragistics.Win.UltraWinGrid;
    using System;
    using System.Data;

    public class UltraGridSelectedRowsProviderService<T> : ISelectedRowsProviderService where T: DataSet, new()
    {
        private UltraGrid m_Grid;

        public UltraGridSelectedRowsProviderService(UltraGrid grid)
        {
            this.m_Grid = grid;
        }

        public DataSet GetSelectedRows()
        {
            DataSet ds = Activator.CreateInstance<T>();
            foreach (UltraGridRow row in this.m_Grid.Rows)
            {
                UltraGridGroupByRow group = row as UltraGridGroupByRow;
                if (group != null)
                {
                    this.SelectedGroupByRows(ds, group);
                }
                else if (row.Selected && (row.ListObject != null))
                {
                    DataSetUtil.AddRelatedRows(ds, ((DataRowView) row.ListObject).Row);
                }
            }
            return ds;
        }

        private DataSet SelectedGroupByRows(DataSet ds, UltraGridGroupByRow group)
        {
            foreach (UltraGridRow row in group.Rows)
            {
                UltraGridGroupByRow row2 = row as UltraGridGroupByRow;
                if (row2 != null)
                {
                    this.SelectedGroupByRows(ds, row2);
                }
                else if (row.Selected)
                {
                    DataSetUtil.AddRelatedRows(ds, ((DataRowView) row.ListObject).Row);
                }
            }
            return ds;
        }
    }
}

