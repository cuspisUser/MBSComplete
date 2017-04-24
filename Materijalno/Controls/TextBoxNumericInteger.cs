using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JavnaNabava.Controls
{
    public class TextBoxNumericInteger : Infragistics.Win.UltraWinEditors.UltraTextEditor
    {
        /// <summary>
        /// Handles paste-ing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            foreach (char slovo in this.Text)
            {
                if (!char.IsDigit(slovo))
                    this.Text = this.Text.Replace(slovo.ToString(), string.Empty);
            }

            base.OnTextChanged(e);
        }

        /// <summary>
        /// Handles typing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = (e.KeyCode == Keys.D0 ||
                e.KeyCode == Keys.D1 ||
                e.KeyCode == Keys.D2 ||
                e.KeyCode == Keys.D3 ||
                e.KeyCode == Keys.D4 ||
                e.KeyCode == Keys.D5 ||
                e.KeyCode == Keys.D6 ||
                e.KeyCode == Keys.D7 ||
                e.KeyCode == Keys.D8 ||
                e.KeyCode == Keys.D9);

            base.OnKeyDown(e);
        }
    }
}
