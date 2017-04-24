namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI.Workspaces;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class OdrzavanjeSmartPart : UserControl
    {
        private IContainer components;
        private sp_maticni_kartonDataAdapter da;
        private sp_maticni_kartonDataSet ds;

        public OdrzavanjeSmartPart()
        {
            base.Load += new EventHandler(this.Zap1_Load);
            this.da = new sp_maticni_kartonDataAdapter();
            this.ds = new sp_maticni_kartonDataSet();
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("Baze", -1);
            UltraGridColumn column = new UltraGridColumn("nazivbaze", -1, null, 0, SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.PregledRadnikaDataSet1 = new PregledRadnikaDataSet();
            this.Baze1BindingSource = new BindingSource(this.components);
            this.Baze1 = new Baze();
            this.UltraGrid1 = new UltraGrid();
            this.UltraGroupBox1 = new UltraGroupBox();
            this.UltraButton3 = new UltraButton();
            this.UltraButton2 = new UltraButton();
            this.UltraButton1 = new UltraButton();
            this.UltraGroupBox2 = new UltraGroupBox();
            this.UltraGroupBox3 = new UltraGroupBox();
            this.TextBox1 = new TextBox();
            this.ProgressBar1 = new ProgressBar();
            this.PregledRadnikaDataSet1.BeginInit();
            ((ISupportInitialize) this.Baze1BindingSource).BeginInit();
            this.Baze1.BeginInit();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            ((ISupportInitialize) this.UltraGroupBox1).BeginInit();
            this.UltraGroupBox1.SuspendLayout();
            ((ISupportInitialize) this.UltraGroupBox2).BeginInit();
            this.UltraGroupBox2.SuspendLayout();
            ((ISupportInitialize) this.UltraGroupBox3).BeginInit();
            this.UltraGroupBox3.SuspendLayout();
            this.SuspendLayout();
            this.PregledRadnikaDataSet1.DataSetName = "PregledRadnikaDataSet";
            this.Baze1BindingSource.DataSource = this.Baze1;
            this.Baze1BindingSource.Position = 0;
            this.Baze1.DataSetName = "Baze";
            this.Baze1.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.UltraGrid1.DataMember = "Baze";
            this.UltraGrid1.DataSource = this.Baze1BindingSource;
            appearance.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.Header.Caption = "Naziv baze podataka";
            column.Header.VisiblePosition = 0;
            column.Width = 0x183;
            band.Columns.AddRange(new object[] { column });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance2.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid1.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance4.BorderColor = Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            appearance5.BackColor = Color.LightSteelBlue;
            appearance5.BorderColor = Color.Black;
            appearance5.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid1.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid1.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.UltraGrid1.Dock = DockStyle.Fill;
            this.UltraGrid1.Location = new System.Drawing.Point(3, 0x10);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(0x204, 0xd9);
            this.UltraGrid1.TabIndex = 1;
            this.UltraGroupBox1.Controls.Add(this.UltraButton3);
            this.UltraGroupBox1.Controls.Add(this.UltraButton2);
            this.UltraGroupBox1.Controls.Add(this.UltraButton1);
            this.UltraGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.UltraGroupBox1.Name = "UltraGroupBox1";
            this.UltraGroupBox1.Size = new System.Drawing.Size(0x20a, 0x47);
            this.UltraGroupBox1.TabIndex = 2;
            this.UltraGroupBox1.Text = "Rad sa bazama";
            this.UltraButton3.Location = new System.Drawing.Point(0x138, 0x1c);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(0xc1, 0x17);
            this.UltraButton3.TabIndex = 2;
            this.UltraButton3.Text = "Otvaranje baze iz bak datoteke";
            this.UltraButton2.Location = new System.Drawing.Point(0x9d, 0x1c);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(0x8e, 0x17);
            this.UltraButton2.TabIndex = 1;
            this.UltraButton2.Text = "Postavi bazu kao aktivnu";
            this.UltraButton1.Location = new System.Drawing.Point(9, 0x1c);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(0x8e, 0x17);
            this.UltraButton1.TabIndex = 0;
            this.UltraButton1.Text = "Izradi kopije svih baza";
            this.UltraGroupBox2.Controls.Add(this.UltraGrid1);
            this.UltraGroupBox2.Location = new System.Drawing.Point(3, 80);
            this.UltraGroupBox2.Name = "UltraGroupBox2";
            this.UltraGroupBox2.Size = new System.Drawing.Size(0x20a, 0xec);
            this.UltraGroupBox2.TabIndex = 3;
            this.UltraGroupBox2.Text = "Popis baza na serveru";
            this.UltraGroupBox3.Controls.Add(this.TextBox1);
            this.UltraGroupBox3.Controls.Add(this.ProgressBar1);
            this.UltraGroupBox3.Location = new System.Drawing.Point(6, 0x13f);
            this.UltraGroupBox3.Name = "UltraGroupBox3";
            this.UltraGroupBox3.Size = new System.Drawing.Size(0x207, 0x77);
            this.UltraGroupBox3.TabIndex = 4;
            this.UltraGroupBox3.Text = "Status akcije";
            this.TextBox1.Location = new System.Drawing.Point(6, 0x49);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(0x1f0, 20);
            this.TextBox1.TabIndex = 2;
            this.TextBox1.TextAlign = HorizontalAlignment.Center;
            this.ProgressBar1.Location = new System.Drawing.Point(6, 0x13);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(0x1f0, 0x19);
            this.ProgressBar1.TabIndex = 0;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.UltraGroupBox3);
            this.Controls.Add(this.UltraGroupBox2);
            this.Controls.Add(this.UltraGroupBox1);
            this.Name = "OdrzavanjeSmartPart";
            this.Size = new System.Drawing.Size(0x213, 0x1bf);


            this.UltraGroupBox1.Click += new EventHandler(this.UltraGroupBox1_Click);
            this.UltraButton3.Click += new EventHandler(this.UltraButton3_Click);

            this.UltraButton2.Click += new EventHandler(this.UltraButton2_Click);
            this.UltraButton1.Click += new EventHandler(this.UltraButton1_Click);


            this.PregledRadnikaDataSet1.EndInit();
            ((ISupportInitialize) this.Baze1BindingSource).EndInit();
            this.Baze1.EndInit();
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            ((ISupportInitialize) this.UltraGroupBox1).EndInit();
            this.UltraGroupBox1.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGroupBox2).EndInit();
            this.UltraGroupBox2.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGroupBox3).EndInit();
            this.UltraGroupBox3.ResumeLayout(false);
            this.UltraGroupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        private void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            this.ProgressBar1.Value = e.Percent;
        }

        public void PuniBaze()
        {
            IEnumerator enumerator = null;

            Server server = new Server(Mipsed7.Core.ApplicationDatabaseInformation.ServerName);
            
            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            server.ConnectionContext.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

            try
            {
                enumerator = server.Databases.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Database current = (Database) enumerator.Current;
                    if (!current.IsSystemObject && current.IsAccessible)
                    {
                        DataRow row = this.Baze1.Tables["Baze"].NewRow();
                        row["nazivbaze"] = current.Name;
                        this.Baze1.Tables["Baze"].Rows.Add(row);
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

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            IEnumerator enumerator = null;
            
            Server server = new Server(Mipsed7.Core.ApplicationDatabaseInformation.ServerName);

            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            server.ConnectionContext.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;
            try
            {
                enumerator = server.Databases.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Database current = (Database) enumerator.Current;
                    if (!current.IsSystemObject && current.IsAccessible)
                    {

                        Backup backup = new Backup();
                        this.Cursor = Cursors.WaitCursor;
                        string str3 = Path.Combine(server.Settings.BackupDirectory.ToString(), current.Name + "_" + Conversions.ToString(DateAndTime.Today.Day) + "_" + Conversions.ToString(DateAndTime.Today.Month) + "_" + Conversions.ToString(DateAndTime.Today.Year) + ".bak");
                        backup.Devices.AddDevice(str3, DeviceType.File);
                        backup.Database = current.Name;
                        backup.Action = BackupActionType.Database;
                        backup.Incremental = false;
                        backup.Initialize = true;
                        backup.PercentCompleteNotification = 1;
                        this.TextBox1.Clear();
                        this.TextBox1.AppendText("Trenutna akcija -  backup baze: " + current.Name);
                        backup.PercentComplete += new PercentCompleteEventHandler(this.ProgressEventHandler);
                        backup.SqlBackup(server);
                        backup.PercentComplete -= new PercentCompleteEventHandler(this.ProgressEventHandler);
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
            this.Cursor = Cursors.Default;
            this.TextBox1.Clear();
            this.TextBox1.AppendText("Zadaci uspješno završeni!");
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            CurrencyManager manager = (CurrencyManager)this.BindingContext[this.Baze1BindingSource, "baze"];

            if (manager.Current == null)
                return;

            DataRowView current = (DataRowView) manager.Current;

            Server server = new Server(Mipsed7.Core.ApplicationDatabaseInformation.ServerName);

            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            server.ConnectionContext.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

            Database database = new Database();
            database = (Database) NewLateBinding.LateGet(server.Databases, null, "Item", new object[] { RuntimeHelpers.GetObjectValue(current["nazivbaze"]) }, null, null, null);
            if (database.Tables["radnik"] != null)
            {
                if (database.Tables["radnik"].Columns["TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA"] != null)
                {
                    // Matija Božičević - 21.09.2012.
                    Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName = Conversions.ToString(current["nazivbaze"]);

                    Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject("Baza ", current["nazivbaze"]), " postavljena kao aktivna!"), MsgBoxStyle.OkOnly, null);

                }
                else
                {
                    Interaction.MsgBox("Nije baza podataka programa plaće!", MsgBoxStyle.OkOnly, null);
                }
            }
            else
            {
                Interaction.MsgBox("Nije baza podataka programa plaće!", MsgBoxStyle.OkOnly, null);
            }
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            Server server = new Server(Mipsed7.Core.ApplicationDatabaseInformation.ServerName);

            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            server.ConnectionContext.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;


            OpenFileDialog dialog = new OpenFileDialog {
                Title = "Odredite backup datoteku",
                RestoreDirectory = true,
                Filter = "bak datoteke|*.bak|sve datoteke|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExtendedWindowSmartPartInfo smartPartInfo = new ExtendedWindowSmartPartInfo {
                    StartPosition = FormStartPosition.CenterScreen,
                    Modal = true,
                    ControlBox = true,
                    Title = "Unesite naziv baze podataka!",
                    Icon = ImageResourcesNew.mbs
                };
                UnosNazivaBaze smartPart = this.Controller.WorkItem.Items.AddNew<UnosNazivaBaze>();
                smartPart.Baze = server.Databases;
                this.Controller.WorkItem.RootWorkItem.Workspaces["window"].Show(smartPart, smartPartInfo);
                if ((smartPart.NazivBaze != null) && (Interaction.MsgBox("Odabrali ste: " + smartPart.NazivBaze, MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes))
                {
                    Restore restore = new Restore();
                    restore.Devices.AddDevice(dialog.FileName, DeviceType.File);
                    string nazivBaze = smartPart.NazivBaze;
                    restore.Database = nazivBaze;
                    restore.NoRecovery = false;
                    restore.ReplaceDatabase = true;
                    DataRow[] rowArray = restore.ReadFileList(server).Select(null);
                    string logicalFileName = Conversions.ToString(rowArray[0][0]);
                    string str3 = Conversions.ToString(rowArray[1][0]);
                    restore.RelocateFiles.Add(new RelocateFile(logicalFileName, server.Information.MasterDBPath + @"\" + nazivBaze + ".MDF"));
                    restore.RelocateFiles.Add(new RelocateFile(str3, server.Information.MasterDBPath + @"\" + nazivBaze + ".LDF"));
                    this.TextBox1.Clear();
                    this.TextBox1.AppendText("Trenutna akcija -  restore baze : " + nazivBaze);
                    restore.PercentComplete += new PercentCompleteEventHandler(this.ProgressEventHandler);
                    try
                    {
                        restore.SqlRestore(server);
                        restore.PercentComplete -= new PercentCompleteEventHandler(this.ProgressEventHandler);
                        this.TextBox1.Clear();
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;

                        //restore.PercentComplete -= new PercentCompleteEventHandler(this.ProgressEventHandler);
                    }
                }
            }
            this.Baze1.Clear();
            this.PuniBaze();
        }

        private void UltraGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private void Zap1_Load(object sender, EventArgs e)
        {
            this.PuniBaze();
        }

        internal Baze Baze1;

        internal BindingSource Baze1BindingSource;

        public OdrzavanjeController Controller;

        internal PregledRadnikaDataSet PregledRadnikaDataSet1;

        internal ProgressBar ProgressBar1;

        internal TextBox TextBox1;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraButton UltraButton3;

        private UltraGrid UltraGrid1;

        private UltraGroupBox UltraGroupBox1;

        private UltraGroupBox UltraGroupBox2;

        private UltraGroupBox UltraGroupBox3;
    }
}

