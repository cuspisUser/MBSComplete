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

public partial class frmPokazateljRazdoblje: Form
{
    SqlClient client = new SqlClient();
    public static DateTime datumDo;
    public static DateTime datumOd;
    public frmPokazateljRazdoblje()
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
        datumOd = udtDatumOd.DateTime;
        datumDo = udtDatumDo.DateTime;
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void frmPokazatelj_Load(object sender, EventArgs e)
    {

    }
}

