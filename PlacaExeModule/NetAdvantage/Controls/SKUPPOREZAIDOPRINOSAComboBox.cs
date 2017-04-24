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
    using System.Reflection;

    public class SKUPPOREZAIDOPRINOSAComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new SKUPPOREZAIDOPRINOSADataSet();
        protected string m_FillMethod = "Fill";

        public SKUPPOREZAIDOPRINOSAComboBox()
        {
            this.Text = "IDSKUPPOREZAIDOPRINOSA";
            DataView defaultView = this.DataSet.Tables["SKUPPOREZAIDOPRINOSA"].DefaultView;
            defaultView.Sort = "NAZIVSKUPPOREZAIDOPRINOSA";
            this.DisplayMember = "NAZIVSKUPPOREZAIDOPRINOSA";
            this.ValueMember = "IDSKUPPOREZAIDOPRINOSA";
            this.DataSource = defaultView;
        }

        public void Fill()
        {
            if (this.m_DataSet != null)
            {
                try
                {
                    this.DataSource = null;
                    this.m_DataSet.Clear();
                    if (this.FillMethod == "Fill")
                    {
                        this.DataAdapter.Fill(this.m_DataSet);
                    }
                    else
                    {
                        MethodInfo method = this.DataAdapter.GetType().GetMethod(this.FillMethod);
                        this.InvokeFillByMethod(this.FillMethod, (IDataAdapter) this.DataAdapter, this.m_DataSet, method);
                    }
                    DataView defaultView = this.DataSet.Tables["SKUPPOREZAIDOPRINOSA"].DefaultView;
                    defaultView.Sort = "NAZIVSKUPPOREZAIDOPRINOSA";
                    this.DisplayMember = "NAZIVSKUPPOREZAIDOPRINOSA";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "SKUPPOREZAIDOPRINOSA", "IDSKUPPOREZAIDOPRINOSA", "NAZIVSKUPPOREZAIDOPRINOSA", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public ISKUPPOREZAIDOPRINOSADataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetSKUPPOREZAIDOPRINOSADataAdapter();
                }
                return null;
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public System.Data.DataSet DataSet
        {
            get
            {
                return this.m_DataSet;
            }
        }

        [DefaultValue("Fill"), Category("Deklarit"), TypeConverter(typeof(DeklaritComboBox.FillMethodsConverter))]
        public virtual string FillMethod
        {
            get
            {
                return this.m_FillMethod;
            }
            set
            {
                this.m_FillMethod = value;
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SKUPPOREZAIDOPRINOSAComboBox
            // 
            this.Name = "SKUPPOREZAIDOPRINOSAComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

