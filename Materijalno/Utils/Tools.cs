using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Materijalno.Utils.Exceptions;
using Infragistics.Win.UltraWinGrid;

namespace Materijalno.Utils
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

        internal static void UltraGridStyling(UltraGrid ultraGrid, string[] koloneZaEdit = null)
        {
            // Set font size
            ultraGrid.DisplayLayout.Appearance.FontData.SizeInPoints = 8.5F;

            // Set padding
            ultraGrid.DisplayLayout.Override.CellPadding = 2;

            // Set vertical alignment
            ultraGrid.DisplayLayout.Override.CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            // Resize all columns to content
            ultraGrid.DisplayLayout.PerformAutoResizeColumns(false, PerformAutoSizeType.AllRowsInBand);
            

            // TURN-ON edit mode
            foreach (UltraGridBand band in ultraGrid.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn column in band.Columns)
                {
                    // current column not specified
                    if (koloneZaEdit != null ? koloneZaEdit.Contains(column.Key) : false)
                        column.CellActivation = Activation.AllowEdit;                    
                }

                //db - 5.12.2016 - morao dodati i zabranu edita, jer nije dovoljno samo propustiti EDIT za navedenu kolonu, jer moronski grid odmah to prihvaca za sve kolone
                foreach (UltraGridColumn col in band.Columns)
                {
                    if (koloneZaEdit != null)
                    { 
                        if(!(koloneZaEdit.Contains(col.Key)))
                        {
                            col.CellActivation = Activation.NoEdit;                    
                        }
                    }
                }
            }
        }




    }
}
