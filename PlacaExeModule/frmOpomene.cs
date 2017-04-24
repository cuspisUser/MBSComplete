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

public partial class frmOpomene: Form
{
    SqlClient client = new SqlClient();
    public static int id_partnera = 0;
    public frmOpomene()
    {
        InitializeComponent();
        LoadPartneri();
    }
    private void LoadPartneri()
    {
       ucbPartneri.DataSource = SQL().DefaultView;
       ucbPartneri.DataBind();
    }
    private DataTable SQL()
    {
        DataTable dt = client.GetDataTable("Select RTRIM(IDPARTNER) as ŠIFRA, (RTRIM(Partner.IDPARTNER) + ' | ' +  NAZIVPARTNER) As NAZIV  From Partner");
        return dt;
    }

    private void btnOdustani_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();

    }

    private void btnGeneriraj_Click(object sender, EventArgs e)
    {
        id_partnera = Convert.ToInt32(ucbPartneri.Value);
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }
}

