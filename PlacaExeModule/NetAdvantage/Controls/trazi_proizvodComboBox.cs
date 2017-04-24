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

    public class trazi_proizvodComboBox : DeklaritComboBox
    {
        private trazi_proizvodDataSet dstrazi_proizvodDataSet1 = new trazi_proizvodDataSet();
        private string m_Parameternazivproizvod = "";

        public trazi_proizvodComboBox()
        {
            this.Text = "IDPROIZVOD";
            DataView defaultView = this.DataSet.Tables["PROIZVOD"].DefaultView;
            defaultView.Sort = "NAZIVPROIZVOD";
            this.DisplayMember = "NAZIVPROIZVOD";
            this.ValueMember = "IDPROIZVOD";
            this.DataSource = defaultView;
        }

        public void Fill()
        {
            if (this.dstrazi_proizvodDataSet1 != null)
            {
                try
                {
                    this.DataSource = null;
                    this.dstrazi_proizvodDataSet1.Clear();
                    this.DataAdapter.Fill(this.dstrazi_proizvodDataSet1, this.m_Parameternazivproizvod);
                    DataView defaultView = this.DataSet.Tables["PROIZVOD"].DefaultView;
                    defaultView.Sort = "NAZIVPROIZVOD";
                    this.DisplayMember = "NAZIVPROIZVOD";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "PROIZVOD", "IDPROIZVOD", "NAZIVPROIZVOD", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Browsable(false), Category("Deklarit")]
        public Itrazi_proizvodDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.Gettrazi_proizvodDataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public virtual trazi_proizvodDataSet DataSet
        {
            get
            {
                return this.dstrazi_proizvodDataSet1;
            }
            set
            {
                this.dstrazi_proizvodDataSet1 = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parameternazivproizvod
        {
            get
            {
                return this.m_Parameternazivproizvod;
            }
            set
            {
                this.m_Parameternazivproizvod = value;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trazi_proizvodComboBox
            // 
            this.Name = "trazi_proizvodComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

