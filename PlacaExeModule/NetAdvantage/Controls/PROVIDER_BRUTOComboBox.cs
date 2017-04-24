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

    public class PROVIDER_BRUTOComboBox : DeklaritComboBox
    {
        private PROVIDER_BRUTODataSet dsPROVIDER_BRUTODataSet1 = new PROVIDER_BRUTODataSet();

        public PROVIDER_BRUTOComboBox()
        {
            this.Text = "IDELEMENT";
            DataView defaultView = this.DataSet.Tables["ELEMENT"].DefaultView;
            this.DisplayMember = "EL";
            this.ValueMember = "IDELEMENT";
            this.DataSource = defaultView;
        }

        public void Fill()
        {
            if (this.dsPROVIDER_BRUTODataSet1 != null)
            {
                try
                {
                    this.DataSource = null;
                    this.dsPROVIDER_BRUTODataSet1.Clear();
                    this.DataAdapter.Fill(this.dsPROVIDER_BRUTODataSet1);
                    DataView defaultView = this.DataSet.Tables["ELEMENT"].DefaultView;
                    this.DisplayMember = "EL";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "ELEMENT", "IDELEMENT", "EL", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Browsable(false), Category("Deklarit")]
        public IPROVIDER_BRUTODataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetPROVIDER_BRUTODataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public virtual PROVIDER_BRUTODataSet DataSet
        {
            get
            {
                return this.dsPROVIDER_BRUTODataSet1;
            }
            set
            {
                this.dsPROVIDER_BRUTODataSet1 = value;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PROVIDER_BRUTOComboBox
            // 
            this.Name = "PROVIDER_BRUTOComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

