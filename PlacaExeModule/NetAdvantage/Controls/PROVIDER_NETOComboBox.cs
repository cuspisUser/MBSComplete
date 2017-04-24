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

    public class PROVIDER_NETOComboBox : DeklaritComboBox
    {
        private PROVIDER_NETODataSet dsPROVIDER_NETODataSet1 = new PROVIDER_NETODataSet();

        public PROVIDER_NETOComboBox()
        {
            this.Text = "IDELEMENT";
            DataView defaultView = this.DataSet.Tables["ELEMENT"].DefaultView;
            this.DisplayMember = "EL";
            this.ValueMember = "IDELEMENT";
            this.DataSource = defaultView;
        }

        public void Fill()
        {
            if (this.dsPROVIDER_NETODataSet1 != null)
            {
                try
                {
                    this.DataSource = null;
                    this.dsPROVIDER_NETODataSet1.Clear();
                    this.DataAdapter.Fill(this.dsPROVIDER_NETODataSet1);
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

        [Category("Deklarit"), Browsable(false)]
        public IPROVIDER_NETODataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetPROVIDER_NETODataAdapter();
                }
                return null;
            }
        }

        [Browsable(false), Category("Deklarit")]
        public virtual PROVIDER_NETODataSet DataSet
        {
            get
            {
                return this.dsPROVIDER_NETODataSet1;
            }
            set
            {
                this.dsPROVIDER_NETODataSet1 = value;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PROVIDER_NETOComboBox
            // 
            this.Name = "PROVIDER_NETOComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

