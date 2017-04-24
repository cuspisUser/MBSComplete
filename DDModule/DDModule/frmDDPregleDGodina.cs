using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DDModule
{
    public class frmDDPregleDGodina : Form
    {
        private CurrencyManager cm;
        private System.ComponentModel.IContainer components = null;
        private DataRowView drv;
        private V_DD_GODINE_ISPLATEDataSet dsa;


        private Infragistics.Win.Misc.UltraButton UltraButton1;
        private Infragistics.Win.UltraWinGrid.UltraGrid UltraGrid1;

        public frmDDPregleDGodina()
        {
            InitializeComponent();
            base.Load += new EventHandler(this.frmPregledMjeseciGodina_Load);
            this.dsa = new V_DD_GODINE_ISPLATEDataSet();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmPregledMjeseciGodina_Load(object sender, EventArgs e)
        {
            this.dsa.Clear();

            new V_DD_GODINE_ISPLATEDataAdapter().Fill(this.dsa);
            this.UltraGrid1.DataSource = this.dsa;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDDPregleDGodina));
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UltraGrid1.Location = new System.Drawing.Point(0, 49);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(212, 568);
            this.UltraGrid1.TabIndex = 1;
            this.UltraGrid1.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid1_InitializeLayout);
            this.UltraGrid1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.UltraGrid1_DoubleClickRow);
            // 
            // UltraButton1
            // 
            this.UltraButton1.Location = new System.Drawing.Point(39, 12);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(123, 23);
            this.UltraButton1.TabIndex = 0;
            this.UltraButton1.Text = "Odaberi";
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // frmDDPregleDGodina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 617);
            this.Controls.Add(this.UltraButton1);
            this.Controls.Add(this.UltraGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDDPregleDGodina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mjeseci i godine isplate";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Odaberi()
        {
            this.cm = (CurrencyManager)this.BindingContext[this.dsa, "v_dd_godine_isplate"];
            if (this.cm.Count != 0)
            {
                this.drv = (DataRowView)this.cm.Current;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.Odaberi();
        }

        private void UltraGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.Odaberi();
        }

        private void UltraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        public object OdabraniGodinaIsplate
        {
            get
            {
                object objectValue = new object();
                if ((this.drv != null) && (this.cm.Count != 0))
                {
                    objectValue = RuntimeHelpers.GetObjectValue(this.drv["godinaisplate"]);
                }
                return objectValue;
            }
            set
            {
                this.OdabraniGodinaIsplate = RuntimeHelpers.GetObjectValue(value);
            }
        }
    }
}

