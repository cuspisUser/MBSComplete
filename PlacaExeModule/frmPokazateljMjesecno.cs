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

public partial class frmPokazateljMjesecno: Form
{
    SqlClient client = new SqlClient();
    public static DateTime datumDo;
    public static DateTime datumOd;
    public frmPokazateljMjesecno()
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
        datumOd = new DateTime(mipsed.application.framework.Application.ActiveYear, (int)uneObracuniGodina.Value, 1);

        datumDo = new DateTime(mipsed.application.framework.Application.ActiveYear, (int)uneObracuniGodina.Value, DateTime.DaysInMonth(mipsed.application.framework.Application.ActiveYear, (int)uneObracuniGodina.Value));
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }

    private void frmPokazatelj_Load(object sender, EventArgs e)
    {

    }
}

