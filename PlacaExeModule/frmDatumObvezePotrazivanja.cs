using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer;
using FinPosModule;

public partial class frmDatumObvezePotrazivanja: Form
{
    SqlClient client = new SqlClient();
    public static DateTime datum;
    public frmDatumObvezePotrazivanja()
    {
        InitializeComponent();
    }

    private void btnOdustani_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();

    }

    private void btnGeneriraj_Click(object sender, EventArgs e)
    {
        datum = udtDatum.DateTime;
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }
}

