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

    public class trazi_partneraSuggestComboBox : DeklaritComboBox
    {
        private trazi_partneraDataSet dstrazi_partneraDataSet1 = new trazi_partneraDataSet();
        private string m_ParameterNAZIVPARTNER = "";

        public trazi_partneraSuggestComboBox()
        {
            this.Text = "IDPARTNER";
            DataView defaultView = this.DataSet.Tables["PARTNER"].DefaultView;
            defaultView.Sort = "PT";
            this.DisplayMember = "PT";
            this.ValueMember = "IDPARTNER";
            this.DataSource = defaultView;
            this.ComboBox.TextChanged += new EventHandler(this.ComboBox_TextChanged);
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (this.ComboBox.SelectedItem == null)
            {
                this.SuggestFill(this.Text);
                this.ComboBox.DropDown();
                this.ComboBox.Select(this.Text.Length, 0);
            }
        }

        public void Fill()
        {
            if (this.dstrazi_partneraDataSet1 != null)
            {
                try
                {
                    this.DataSource = null;
                    this.dstrazi_partneraDataSet1.Clear();
                    this.DataAdapter.Fill(this.dstrazi_partneraDataSet1, this.m_ParameterNAZIVPARTNER);
                    DataView defaultView = this.DataSet.Tables["PARTNER"].DefaultView;
                    defaultView.Sort = "PT";
                    this.DisplayMember = "PT";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "PARTNER", "IDPARTNER", "PT", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        public void SuggestFill(string text)
        {
            if (this.dstrazi_partneraDataSet1 != null)
            {
                try
                {
                    this.DataSource = null;
                    this.dstrazi_partneraDataSet1.Clear();
                    this.m_ParameterNAZIVPARTNER = text;
                    this.DataAdapter.Fill(this.dstrazi_partneraDataSet1, this.m_ParameterNAZIVPARTNER);
                    DataView defaultView = this.DataSet.Tables["PARTNER"].DefaultView;
                    defaultView.Sort = "PT";
                    this.DisplayMember = "PT";
                    this.DataSource = defaultView;
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
        }

        [Browsable(false), Category("Deklarit")]
        public Itrazi_partneraDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.Gettrazi_partneraDataAdapter();
                }
                return null;
            }
        }

        [Browsable(false), Category("Deklarit")]
        public virtual trazi_partneraDataSet DataSet
        {
            get
            {
                return this.dstrazi_partneraDataSet1;
            }
            set
            {
                this.dstrazi_partneraDataSet1 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterNAZIVPARTNER
        {
            get
            {
                return this.m_ParameterNAZIVPARTNER;
            }
            set
            {
                this.m_ParameterNAZIVPARTNER = value;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trazi_partneraSuggestComboBox
            // 
            this.Name = "trazi_partneraSuggestComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

