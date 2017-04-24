namespace Chat
{
    partial class uscChat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscChat));
            this.btnPosaljiPoruku = new System.Windows.Forms.Button();
            this.rtbUnosPoruke = new System.Windows.Forms.RichTextBox();
            this.rtbPrikazPoruka = new System.Windows.Forms.RichTextBox();
            this.lstOnlineKorisnici = new System.Windows.Forms.ListView();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.spcUnos = new System.Windows.Forms.SplitContainer();
            this.spcPrikaz = new System.Windows.Forms.SplitContainer();
            this.tmrOkidac = new System.Windows.Forms.Timer(this.components);
            this.imlSlikice = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcUnos)).BeginInit();
            this.spcUnos.Panel1.SuspendLayout();
            this.spcUnos.Panel2.SuspendLayout();
            this.spcUnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcPrikaz)).BeginInit();
            this.spcPrikaz.Panel1.SuspendLayout();
            this.spcPrikaz.Panel2.SuspendLayout();
            this.spcPrikaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPosaljiPoruku
            // 
            this.btnPosaljiPoruku.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPosaljiPoruku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPosaljiPoruku.Location = new System.Drawing.Point(0, 0);
            this.btnPosaljiPoruku.Name = "btnPosaljiPoruku";
            this.btnPosaljiPoruku.Size = new System.Drawing.Size(617, 175);
            this.btnPosaljiPoruku.TabIndex = 14;
            this.btnPosaljiPoruku.Text = "Pošalji";
            this.btnPosaljiPoruku.UseVisualStyleBackColor = true;
            this.btnPosaljiPoruku.Click += new System.EventHandler(this.btnPosaljiPoruku_Click);
            // 
            // rtbUnosPoruke
            // 
            this.rtbUnosPoruke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbUnosPoruke.Location = new System.Drawing.Point(0, 0);
            this.rtbUnosPoruke.Multiline = false;
            this.rtbUnosPoruke.Name = "rtbUnosPoruke";
            this.rtbUnosPoruke.Size = new System.Drawing.Size(174, 175);
            this.rtbUnosPoruke.TabIndex = 13;
            this.rtbUnosPoruke.Text = "";
            this.rtbUnosPoruke.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbUnosPoruke_KeyPress);
            // 
            // rtbPrikazPoruka
            // 
            this.rtbPrikazPoruka.BackColor = System.Drawing.SystemColors.Window;
            this.rtbPrikazPoruka.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtbPrikazPoruka.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPrikazPoruka.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbPrikazPoruka.Location = new System.Drawing.Point(0, 0);
            this.rtbPrikazPoruka.Name = "rtbPrikazPoruka";
            this.rtbPrikazPoruka.ReadOnly = true;
            this.rtbPrikazPoruka.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbPrikazPoruka.Size = new System.Drawing.Size(526, 467);
            this.rtbPrikazPoruka.TabIndex = 12;
            this.rtbPrikazPoruka.Text = "";
            // 
            // lstOnlineKorisnici
            // 
            this.lstOnlineKorisnici.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lstOnlineKorisnici.AutoArrange = false;
            this.lstOnlineKorisnici.BackColor = System.Drawing.Color.FloralWhite;
            this.lstOnlineKorisnici.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lstOnlineKorisnici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOnlineKorisnici.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOnlineKorisnici.FullRowSelect = true;
            this.lstOnlineKorisnici.HoverSelection = true;
            this.lstOnlineKorisnici.LabelWrap = false;
            this.lstOnlineKorisnici.Location = new System.Drawing.Point(0, 0);
            this.lstOnlineKorisnici.MultiSelect = false;
            this.lstOnlineKorisnici.Name = "lstOnlineKorisnici";
            this.lstOnlineKorisnici.ShowGroups = false;
            this.lstOnlineKorisnici.ShowItemToolTips = true;
            this.lstOnlineKorisnici.Size = new System.Drawing.Size(265, 467);
            this.lstOnlineKorisnici.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstOnlineKorisnici.TabIndex = 11;
            this.lstOnlineKorisnici.TileSize = new System.Drawing.Size(191, 23);
            this.lstOnlineKorisnici.UseCompatibleStateImageBehavior = false;
            this.lstOnlineKorisnici.View = System.Windows.Forms.View.Tile;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.spcUnos);
            this.spcMain.Panel1MinSize = 40;
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcPrikaz);
            this.spcMain.Size = new System.Drawing.Size(795, 646);
            this.spcMain.SplitterDistance = 175;
            this.spcMain.TabIndex = 15;
            // 
            // spcUnos
            // 
            this.spcUnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcUnos.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.spcUnos.IsSplitterFixed = true;
            this.spcUnos.Location = new System.Drawing.Point(0, 0);
            this.spcUnos.Name = "spcUnos";
            // 
            // spcUnos.Panel1
            // 
            this.spcUnos.Panel1.Controls.Add(this.btnPosaljiPoruku);
            // 
            // spcUnos.Panel2
            // 
            this.spcUnos.Panel2.Controls.Add(this.rtbUnosPoruke);
            this.spcUnos.Size = new System.Drawing.Size(795, 175);
            this.spcUnos.SplitterDistance = 617;
            this.spcUnos.TabIndex = 0;
            // 
            // spcPrikaz
            // 
            this.spcPrikaz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPrikaz.Location = new System.Drawing.Point(0, 0);
            this.spcPrikaz.Name = "spcPrikaz";
            // 
            // spcPrikaz.Panel1
            // 
            this.spcPrikaz.Panel1.Controls.Add(this.lstOnlineKorisnici);
            // 
            // spcPrikaz.Panel2
            // 
            this.spcPrikaz.Panel2.Controls.Add(this.rtbPrikazPoruka);
            this.spcPrikaz.Size = new System.Drawing.Size(795, 467);
            this.spcPrikaz.SplitterDistance = 265;
            this.spcPrikaz.TabIndex = 0;
            // 
            // tmrOkidac
            // 
            this.tmrOkidac.Interval = 1200;
            this.tmrOkidac.Tick += new System.EventHandler(this.tmrOkidac_Tick);
            // 
            // imlSlikice
            // 
            this.imlSlikice.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSlikice.ImageStream")));
            this.imlSlikice.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSlikice.Images.SetKeyName(0, "user.ico");
            this.imlSlikice.Images.SetKeyName(1, "online.gif");
            // 
            // uscChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spcMain);
            this.Name = "uscChat";
            this.Size = new System.Drawing.Size(795, 646);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcUnos.Panel1.ResumeLayout(false);
            this.spcUnos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcUnos)).EndInit();
            this.spcUnos.ResumeLayout(false);
            this.spcPrikaz.Panel1.ResumeLayout(false);
            this.spcPrikaz.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPrikaz)).EndInit();
            this.spcPrikaz.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPosaljiPoruku;
        private System.Windows.Forms.RichTextBox rtbUnosPoruke;
        private System.Windows.Forms.RichTextBox rtbPrikazPoruka;
        private System.Windows.Forms.ListView lstOnlineKorisnici;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.SplitContainer spcUnos;
        private System.Windows.Forms.SplitContainer spcPrikaz;
        private System.Windows.Forms.Timer tmrOkidac;
        private System.Windows.Forms.ImageList imlSlikice;


    }
}
