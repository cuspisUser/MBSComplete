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

    public class KONTOComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new KONTODataSet();
        protected int m_FillByIDAKTIVNOSTIDAKTIVNOST;
        protected string m_FillMethod = "Fill";

        public KONTOComboBox()
        {
            this.Text = "IDKONTO";
            DataView defaultView = this.DataSet.Tables["KONTO"].DefaultView;
            defaultView.Sort = "KONT";
            this.DisplayMember = "KONT";
            this.ValueMember = "IDKONTO";
            this.DataSource = defaultView;
            DeklaritComboBox.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill", "FillByIDAKTIVNOST" });
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
                    DataView defaultView = this.DataSet.Tables["KONTO"].DefaultView;
                    defaultView.Sort = "KONT";
                    this.DisplayMember = "KONT";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "KONTO", "IDKONTO", "KONT", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public IKONTODataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetKONTODataAdapter();
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

        [Category("Deklarit")]
        public virtual int FillByIDAKTIVNOSTIDAKTIVNOST
        {
            get
            {
                return this.m_FillByIDAKTIVNOSTIDAKTIVNOST;
            }
            set
            {
                this.m_FillByIDAKTIVNOSTIDAKTIVNOST = value;
            }
        }

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritComboBox.FillMethodsConverter)), Category("Deklarit")]
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
            // KONTOComboBox
            // 
            this.Name = "KONTOComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

