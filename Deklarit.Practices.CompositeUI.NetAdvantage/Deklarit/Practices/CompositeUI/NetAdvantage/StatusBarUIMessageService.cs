namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    using Deklarit.Practices.CompositeUI.Services;
    using Infragistics.Win.UltraWinStatusBar;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class StatusBarUIMessageService : IUIMessageService
    {
        private UltraStatusBar m_StatusBar;

        public StatusBarUIMessageService(UltraStatusBar statusBar)
        {
            this.m_StatusBar = statusBar;
        }

        public void Clear()
        {
            this.m_StatusBar.Appearance.BackColor = Color.Transparent;
            this.m_StatusBar.Text = "";
        }

        public void ShowError(Control control, string text)
        {
            this.m_StatusBar.Appearance.BackColor = Color.FromArgb(0xff, 0xc0, 0xc0);
            this.m_StatusBar.Text = text;
        }

        public void ShowInformation(Control control, string text)
        {
            this.Clear();
            this.m_StatusBar.Text = text;
        }

        public void ShowWarning(Control control, string text)
        {
            this.m_StatusBar.Appearance.BackColor = Color.FromArgb(0xff, 0xff, 0xc0);
            this.m_StatusBar.Text = text;
        }

        public object MessageControl
        {
            get
            {
                return this.m_StatusBar;
            }
            set
            {
                this.m_StatusBar = (UltraStatusBar) value;
            }
        }
    }
}

