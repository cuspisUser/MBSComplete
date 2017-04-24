using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Materijalno.UI.Skladista
{
    public partial class PregledStanjaSkladista : UserControl
    {
        public PregledStanjaSkladista()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Iz grida treba maknuti prikazne artikle (proizvode) sa stanjem 0,00 u količini
        }
    }
}
