using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace JOPPD
{
    public class Tools
    {
        public static string ReturnNULLIfEmpty(string value)
        {
            if (value != null)
                if (string.IsNullOrEmpty(value.Trim()))
                    return null;

            return value;
        }

        internal static void UltraGridStyling(UltraGrid ultraGrid, string[] columnsToAllowEdit = null)
        {
            // Set font size
            ultraGrid.DisplayLayout.Appearance.FontData.SizeInPoints = 8.5F;

            // Set padding
            ultraGrid.DisplayLayout.Override.CellPadding = 2;

            // Set vertical alignment
            ultraGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // Resize all columns to content
            ultraGrid.DisplayLayout.PerformAutoResizeColumns(false, PerformAutoSizeType.AllRowsInBand);
            

            // TURN-OFF edit mode
            foreach (UltraGridBand band in ultraGrid.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    // current column not specified
                    if (columnsToAllowEdit != null ? !columnsToAllowEdit.Contains(column.Key) : true)
                        column.CellActivation = Activation.NoEdit;

                }
            }
        }
    }
}
