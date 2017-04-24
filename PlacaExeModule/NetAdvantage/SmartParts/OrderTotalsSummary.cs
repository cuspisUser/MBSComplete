namespace NetAdvantage.SmartParts
{
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    public class OrderTotalsSummary : ICustomSummaryCalculator
    {
        private decimal totals = new decimal();

        void ICustomSummaryCalculator.AggregateCustomSummary(SummarySettings summarySettings, UltraGridRow row)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(row.GetCellValue(summarySettings.SourceColumn.Band.Columns["iznosbruto"]));
            if (objectValue != DBNull.Value)
            {
                try
                {
                    decimal num = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(objectValue));
                    this.totals = decimal.Add(this.totals, num);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                }
            }
        }

        void ICustomSummaryCalculator.BeginCustomSummary(SummarySettings summarySettings, RowsCollection rows)
        {
            this.totals = new decimal();
        }

        object ICustomSummaryCalculator.EndCustomSummary(SummarySettings summarySettings, RowsCollection rows)
        {
            return this.totals;
        }
    }
}

