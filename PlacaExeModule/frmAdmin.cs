using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class frmAdmin : Form
{
    public frmAdmin()
    {
        InitializeComponent();
    }

    private void btnPotvrdi_Click(object sender, EventArgs e)
    {
        if (txtSifra.Text.Trim() == "serviser123")
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    private void btnOdustani_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void txtSifra_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            btnPotvrdi_Click(null, null);
        }
    }

}

