namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    using Infragistics.Win.UltraWinTabControl;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public static class NetAdvantageUtil
    {
        private static void AutoSizeControl(Control outerControl, Control innerControl)
        {
            Size size = outerControl.Size;
            if (innerControl.Size.Height > outerControl.Size.Height)
            {
                size.Height = innerControl.Size.Height;
            }
            if (innerControl.Size.Width > outerControl.Size.Width)
            {
                size.Width = innerControl.Size.Width;
            }
            outerControl.Size = size;
        }

        public static void AutoSizeTabControl(UltraTabControl tabControl)
        {
            UltraTabsCollection.TabEnumerator enumerator = tabControl.Tabs.GetEnumerator();

            while (enumerator.MoveNext())
            {
                foreach (Control control in enumerator.Current.TabPage.Controls)
                {
                    AutoSizeControl(tabControl, control);
                }
            }
        }
    }
}

