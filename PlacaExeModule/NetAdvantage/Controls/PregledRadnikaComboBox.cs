namespace NetAdvantage.Controls
{
    using Deklarit;
    using Deklarit.Controls;
    using Deklarit.Resources;
    using Deklarit.WinHelper;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;

    public class PregledRadnikaComboBox : DeklaritComboBox
    {
        private PregledRadnikaDataSet dsPregledRadnikaDataSet1 = new PregledRadnikaDataSet();

        public PregledRadnikaComboBox()
        {
            this.Text = "IDRADNIK";
            DataView defaultView = this.DataSet.Tables["RADNIK"].DefaultView;
            this.DisplayMember = "SPOJENOPREZIME";
            this.ValueMember = "IDRADNIK";
            this.DataSource = defaultView;
        }

        public void Fill()
        {
            if (this.dsPregledRadnikaDataSet1 != null)
            {
                try
                {
                    this.DataSource = null;
                    this.dsPregledRadnikaDataSet1.Clear();
                    this.DataAdapter.Fill(this.dsPregledRadnikaDataSet1);
                    DataView defaultView = this.DataSet.Tables["RADNIK"].DefaultView;
                    this.DisplayMember = "SPOJENOPREZIME";
                    this.DataSource = defaultView;
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
            }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.Fill();
                if (this.AddEmptyValue)
                {
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "RADNIK", "IDRADNIK", "SPOJENOPREZIME", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Browsable(false), Category("Deklarit")]
        public IPregledRadnikaDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetPregledRadnikaDataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public virtual PregledRadnikaDataSet DataSet
        {
            get
            {
                return this.dsPregledRadnikaDataSet1;
            }
            set
            {
                this.dsPregledRadnikaDataSet1 = value;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PregledRadnikaComboBox
            // 
            this.Name = "PregledRadnikaComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

