namespace NetAdvantage.SmartParts
{
    using Hlp;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;

    public class pROSJEKsATI : ICustomSummaryCalculator
    {
        private decimal totalbruto = new decimal();
        private decimal totalsati = new decimal();

        void ICustomSummaryCalculator.AggregateCustomSummary(SummarySettings summarySettings, UltraGridRow row)
        {
            object objectValue = RuntimeHelpers.GetObjectValue(row.GetCellValue(summarySettings.SourceColumn.Band.Columns["satiukupno"]));
            object obj2 = RuntimeHelpers.GetObjectValue(row.GetCellValue(summarySettings.SourceColumn.Band.Columns["iznosbruto"]));
            if ((objectValue != DBNull.Value) && (obj2 != DBNull.Value))
            {
                try
                {
                    decimal num = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(objectValue));
                    this.totalsati = decimal.Add(this.totalsati, num);
                    decimal num2 = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(obj2));
                    this.totalbruto = decimal.Add(this.totalbruto, num2);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                }
            }
        }

        void ICustomSummaryCalculator.BeginCustomSummary(SummarySettings summarySettings, RowsCollection rows)
        {
            this.totalsati = new decimal();
            this.totalbruto = new decimal();
        }

        object ICustomSummaryCalculator.EndCustomSummary(SummarySettings summarySettings, RowsCollection rows)
        {
            if (decimal.Compare(this.totalsati, decimal.Zero) > 0)
            {
                return DB.RoundUP(decimal.Divide(this.totalbruto, this.totalsati));
            }
            return 0;
        }
    }
}

