using Deklarit.Practices.CompositeUI.Workspaces;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NetAdvantage.Controllers;
using NetAdvantage.Controls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[SmartPart]
public class IznosiNabave : UserControl
{
    private IContainer components { get; set; }

    public IznosiNabave()
    {
        base.Load += new EventHandler(this.IznosiNabave_Load);
        this.InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        IEnumerator enumerator = null;
        try
        {
            enumerator = this.OSController.DataSet.OSTEMELJNICA.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ((DataRow) enumerator.Current).Delete();
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
        this.OSController.DoUpdate();
        this.Provjera();
        this.nabavna.Value = 0;
        this.ispravak.Value = 0;
        this.sadasnja.Value = 0;
        this.nmStanje.Value = 0;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
        this.Spremi();
        if (Operators.ConditionalCompareObjectEqual(this.nabavna.Value, 0, false))
        {
            Interaction.MsgBox("Nabavna vrijednost obavezna za unos!!", MsgBoxStyle.Information, "Osnovna sredstva");
        }
        else if (Operators.ConditionalCompareObjectEqual(this.nmStanje.Value, 0, false))
        {
            Interaction.MsgBox("Količina obavezna za unos!!", MsgBoxStyle.Information, "Osnovna sredstva");
        }
        else if (Operators.ConditionalCompareObjectGreater(this.ispravak.Value, this.nabavna.Value, false))
        {
            Interaction.MsgBox("Ispravak vrijednosti veći od nabavne!", MsgBoxStyle.Information, "Osnovna sredstva");
        }
        else
        {
            if (Operators.ConditionalCompareObjectGreater(this.nabavna.Value, 0, false))
            {
                DataRow row = this.OSController.DataSet.OSTEMELJNICA.NewRow();
                row["invbroj"] = RuntimeHelpers.GetObjectValue(((UltraNumericEditor) this.OSController.OSFormDefinition.Control.Controls[0].Controls[1]).Value);
                row["idosdokument"] = 1;
                row["osbrojdokumenta"] = 0;
                row["osdatumdok"] = RuntimeHelpers.GetObjectValue(((UltraDateTimeEditor) this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x11]).Value);
                row["oskolicina"] = RuntimeHelpers.GetObjectValue(this.nmStanje.Value);
                row["osstopa"] = 0;
                row["ososnovica"] = 0;
                row["osduguje"] = RuntimeHelpers.GetObjectValue(this.nabavna.Value);
                row["ospotrazuje"] = 0;
                row["rashodlokacijeidlokacije"] = DBNull.Value;
                row["osopis"] = "PS-Nabavna";
                this.OSController.DataSet.OSTEMELJNICA.Rows.Add(row);
                this.OSController.DoUpdate();
            }
            if (Operators.ConditionalCompareObjectGreater(this.ispravak.Value, 0, false))
            {
                DataRow row2 = this.OSController.DataSet.OSTEMELJNICA.NewRow();
                row2["invbroj"] = RuntimeHelpers.GetObjectValue(((UltraNumericEditor) this.OSController.OSFormDefinition.Control.Controls[0].Controls[1]).Value);
                row2["idosdokument"] = 2;
                row2["osbrojdokumenta"] = 0;
                row2["osdatumdok"] = RuntimeHelpers.GetObjectValue(((UltraDateTimeEditor) this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x11]).Value);
                row2["oskolicina"] = RuntimeHelpers.GetObjectValue(this.nmStanje.Value);
                row2["osstopa"] = 0;
                row2["ososnovica"] = 0;
                row2["osduguje"] = 0;
                row2["ospotrazuje"] = RuntimeHelpers.GetObjectValue(this.ispravak.Value);
                row2["osopis"] = "PS-Ispravak";
                row2["rashodlokacijeidlokacije"] = DBNull.Value;
                this.OSController.DataSet.OSTEMELJNICA.Rows.Add(row2);
            }
            this.OSController.DoUpdate();
            this.Provjera();
            this.Izracunaj_Kolicine();
            if (((RazmjestajSredstava) this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[1].Controls[0].Controls[0]) != null)
            {
                ((RazmjestajSredstava) this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[1].Controls[0].Controls[0]).TekuceStanje();
            }
        }
    }

    private void Button4_Click(object sender, EventArgs e)
    {
        UltraGrid grid = (UltraGrid) this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[1].Controls[0].Controls[0];
        if (grid.Selected.Rows != null)
        {
            grid.Selected.Rows[0].Delete(true);
            this.Spremi();
            this.Provjera();
            this.Izracunaj_Kolicine();
        }
    }

    private void Button4_Click_1(object sender, EventArgs e)
    {
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    private void InitializeComponent()
    {
            this.nabavna = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ispravak = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.nmStanje = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.sadasnja = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.btnUnosPocetnogStanja = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnBrisanjePocetnogStanja = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nabavna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispravak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStanje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadasnja)).BeginInit();
            this.SuspendLayout();
            // 
            // nabavna
            // 
            this.nabavna.FormatString = "#,##0.00";
            this.nabavna.Location = new System.Drawing.Point(6, 21);
            this.nabavna.MaskInput = "nnnnnnnnnnnn.nn";
            this.nabavna.Name = "nabavna";
            this.nabavna.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.nabavna.Size = new System.Drawing.Size(100, 21);
            this.nabavna.TabIndex = 1;
            // 
            // ispravak
            // 
            this.ispravak.FormatString = "#,##0.00";
            this.ispravak.Location = new System.Drawing.Point(112, 21);
            this.ispravak.MaskInput = "nnnnnnnnnnnn.nn";
            this.ispravak.Name = "ispravak";
            this.ispravak.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.ispravak.Size = new System.Drawing.Size(100, 21);
            this.ispravak.TabIndex = 2;
            // 
            // nmStanje
            // 
            this.nmStanje.FormatString = "#,##0";
            this.nmStanje.Location = new System.Drawing.Point(324, 21);
            this.nmStanje.MaskInput = "nnnnnn";
            this.nmStanje.Name = "nmStanje";
            this.nmStanje.Size = new System.Drawing.Size(100, 21);
            this.nmStanje.TabIndex = 3;
            // 
            // sadasnja
            // 
            this.sadasnja.FormatString = "#,##0.00";
            this.sadasnja.Location = new System.Drawing.Point(218, 21);
            this.sadasnja.MaskInput = "nnnnnnnnnnnn.nn";
            this.sadasnja.Name = "sadasnja";
            this.sadasnja.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.sadasnja.Size = new System.Drawing.Size(100, 21);
            this.sadasnja.TabIndex = 4;
            this.sadasnja.TabStop = false;
            // 
            // btnUnosPocetnogStanja
            // 
            this.btnUnosPocetnogStanja.Location = new System.Drawing.Point(6, 60);
            this.btnUnosPocetnogStanja.Name = "btnUnosPocetnogStanja";
            this.btnUnosPocetnogStanja.Size = new System.Drawing.Size(138, 23);
            this.btnUnosPocetnogStanja.TabIndex = 5;
            this.btnUnosPocetnogStanja.Text = "Unos početnog stanja";
            this.btnUnosPocetnogStanja.UseVisualStyleBackColor = true;
            this.btnUnosPocetnogStanja.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(3, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(51, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Nabavna";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(109, 4);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(48, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Ispravak";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(215, 4);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(51, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Sadašnja";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(327, 4);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(87, 13);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Količina sredstva";
            // 
            // btnBrisanjePocetnogStanja
            // 
            this.btnBrisanjePocetnogStanja.Location = new System.Drawing.Point(150, 60);
            this.btnBrisanjePocetnogStanja.Name = "btnBrisanjePocetnogStanja";
            this.btnBrisanjePocetnogStanja.Size = new System.Drawing.Size(138, 23);
            this.btnBrisanjePocetnogStanja.TabIndex = 10;
            this.btnBrisanjePocetnogStanja.Text = "Brisanje početnog stanja";
            this.btnBrisanjePocetnogStanja.UseVisualStyleBackColor = true;
            this.btnBrisanjePocetnogStanja.Click += new System.EventHandler(this.Button1_Click);
            // 
            // IznosiNabave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBrisanjePocetnogStanja);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnUnosPocetnogStanja);
            this.Controls.Add(this.sadasnja);
            this.Controls.Add(this.nmStanje);
            this.Controls.Add(this.ispravak);
            this.Controls.Add(this.nabavna);
            this.Name = "IznosiNabave";
            this.Size = new System.Drawing.Size(445, 90);
            ((System.ComponentModel.ISupportInitialize)(this.nabavna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispravak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStanje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sadasnja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private void IznosiNabave_Load(object sender, EventArgs e)
    {
        InfraCustom.PostaviSelectAllSvimEditKontrolama(this);

        this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[0].Controls[0].Controls[1].Controls[0].Controls[0].Visible = false;
        this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[0].Controls[0].Controls[1].Controls[0].Controls[1].Visible = false;
        this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[0].Controls[0].Controls[1].Controls[0].Controls[2].Visible = false;
        ((UltraGrid)this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[0].Controls[0].Controls[0]).DisplayLayout.Bands[0].Override.AllowDelete = DefaultableBoolean.False;

        Size size = new System.Drawing.Size(300, 700);
        ((UltraGrid)this.OSController.OSFormDefinition.Control.Controls[0].Controls[0x15].Controls[0].Controls[0].Controls[0]).Size = size;

        this.Provjera();
        this.Izracunaj_Kolicine();
    }

    public void Izracunaj_Kolicine()
    {
        IEnumerator enumerator = null;
        try
        {
            enumerator = this.OSController.DataSet.OSTEMELJNICA.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DataRow current = (DataRow) enumerator.Current;
                if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(current["idosdokument"], 1, false), Operators.CompareObjectEqual(current["idosdokument"], 6, false))))
                {
                    int num2 = 0;
                    num2 = Conversions.ToInteger(Operators.AddObject(num2, current["OSKOLICINA"]));
                }
                if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(current["idosdokument"], 3, false), Operators.CompareObjectEqual(current["idosdokument"], 7, false))))
                {
                    int num = 0;
                    num = Conversions.ToInteger(Operators.AddObject(num, current["OSKOLICINA"]));
                }
            }
        }
        finally
        {
            if (enumerator is IDisposable)
            {
                (enumerator as IDisposable).Dispose();
            }
        }
    }

    public void Provjera()
    {
        bool flag = false;
        this.sadasnja.Appearance.BackColor = Color.Red;
        this.sadasnja.ReadOnly = true;

        if (this.OSController == null)
            return;

        if (this.OSController.DataSet.OSTEMELJNICA.Rows.Count > 0)
        {
            this.nabavna.Appearance.BackColor = Color.Red;
            this.ispravak.Appearance.BackColor = Color.Red;
            this.nmStanje.Appearance.BackColor = Color.Red;
            this.nabavna.ReadOnly = true;
            this.ispravak.ReadOnly = true;
            this.nmStanje.ReadOnly = true;
            this.btnUnosPocetnogStanja.Enabled = false;
            ((UltraDateTimeEditor)this.OSController.OSFormDefinition.GetControl("datePickerDATUMNABAVKE")).ReadOnly = true;
            ((UltraDateTimeEditor)this.OSController.OSFormDefinition.GetControl("datePickerDATUMUPORABE")).ReadOnly = true;
            ((OSVRSTAComboBox)this.OSController.OSFormDefinition.GetControl("comboIDOSVRSTA")).Enabled = false;
        }
        else
        {
            this.btnUnosPocetnogStanja.Enabled = true;
            this.nabavna.Appearance.BackColor = Color.Snow;
            this.ispravak.Appearance.BackColor = Color.Snow;
            this.nmStanje.Appearance.BackColor = Color.Snow;
            this.nabavna.ReadOnly = false;
            this.ispravak.ReadOnly = false;
            this.nmStanje.ReadOnly = false;
            ((UltraDateTimeEditor)this.OSController.OSFormDefinition.GetControl("datePickerDATUMNABAVKE")).ReadOnly = false;
            ((UltraDateTimeEditor)this.OSController.OSFormDefinition.GetControl("datePickerDATUMUPORABE")).ReadOnly = false;
            ((OSVRSTAComboBox)this.OSController.OSFormDefinition.GetControl("comboIDOSVRSTA")).Enabled = true;
        }
        if (this.OSController.DataSet.OSTEMELJNICA.Rows.Count > 0)
        {
            decimal num4 = 0;
            decimal num6 = 0;
            int num7 = 0;
            int num8 = 0;
            decimal num9 = 0;
            decimal num10 = 0;
            decimal osnovica = 0;
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.OSController.DataSet.OSTEMELJNICA.Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    if (Conversions.ToBoolean(Operators.AndObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(current["idosdokument"], 1, false), Operators.CompareObjectEqual(current["idosdokument"], 4, false)), Operators.CompareObjectEqual(current["idosdokument"], 6, false)), Operators.CompareObjectNotEqual(current["idosdokument"], 2, false))))
                    {
                        num9 = Conversions.ToDecimal(Operators.AddObject(num9, current["OSDUGUJE"]));
                        osnovica = Conversions.ToDecimal(Operators.AddObject(osnovica, current["OSOSNOVICA"]));
                    }
                    else if (Conversions.ToBoolean(Operators.AndObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(current["idosdokument"], 3, false), Operators.CompareObjectEqual(current["idosdokument"], 5, false)), Operators.CompareObjectEqual(current["idosdokument"], 7, false)), Operators.CompareObjectNotEqual(current["idosdokument"], 2, false))))
                    {
                        num10 = Conversions.ToDecimal(Operators.AddObject(num10, current["ospotrazuje"]));
                        num4 = Conversions.ToDecimal(Operators.AddObject(num4, current["OSDUGUJE"]));
                    }
                    else if (Operators.ConditionalCompareObjectEqual(current["idosdokument"], 2, false))
                    {
                        num6 = Conversions.ToDecimal(Operators.AddObject(num6, current["OSPOTRAZUJE"]));
                    }
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(current["idosdokument"], 1, false), Operators.CompareObjectEqual(current["idosdokument"], 6, false))))
                    {
                        num8 = Conversions.ToInteger(Operators.AddObject(num8, current["OSKOLICINA"]));
                    }
                    if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(current["idosdokument"], 3, false), Operators.CompareObjectEqual(current["idosdokument"], 7, false))))
                    {
                        num7 = Conversions.ToInteger(Operators.AddObject(num7, current["OSKOLICINA"]));
                    }
                    if (Operators.ConditionalCompareObjectNotEqual(current["osbrojdokumenta"], 0, false))
                    {
                        flag = true;
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            this.nabavna.Value = decimal.Subtract(osnovica, num10);
            this.ispravak.Value = decimal.Subtract(num6, num4);
            this.sadasnja.Value = Operators.SubtractObject(this.nabavna.Value, this.ispravak.Value);
            this.nmStanje.Value = num8 + num7;
        }
        if (flag)
        {
            this.btnBrisanjePocetnogStanja.Enabled = false;
        }
        else
        {
            this.btnBrisanjePocetnogStanja.Enabled = true;
        }
    }


    public void Spremi()
    {
        BindingSource bindingSource = this.OSController.OSFormDefinition.GetBindingSource("OS");
        try
        {
            bindingSource.EndEdit();
        }
        catch (System.Exception exception1)
        {
            throw exception1;
            
            //Interaction.MsgBox("Greška, podaci nisu uneseni prema pravilima! ", MsgBoxStyle.OkOnly, null);
            //return;
        }
        this.OSController.Update(this.Parent.Parent);
    }

    private Button btnBrisanjePocetnogStanja;

    private Button btnUnosPocetnogStanja;

    private UltraNumericEditor ispravak;

    private Label Label1;

    private Label Label2;

    private Label Label3;

    private Label Label4;

    private UltraNumericEditor nabavna;

    private UltraNumericEditor nmStanje;

    [CreateNew, Browsable(false)]
    public NetAdvantage.Controllers.OSController OSController { get; set; }

    private UltraNumericEditor sadasnja;
}

