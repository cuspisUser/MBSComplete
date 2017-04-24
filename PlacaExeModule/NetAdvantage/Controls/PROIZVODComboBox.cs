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

    public class PROIZVODComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new PROIZVODDataSet();
        protected int m_FillByFINPOREZIDPOREZFINPOREZIDPOREZ;
        protected int m_FillByIDJEDINICAMJEREIDJEDINICAMJERE;
        protected string m_FillMethod = "Fill";

        public PROIZVODComboBox()
        {
            this.Text = "IDPROIZVOD";
            DataView defaultView = this.DataSet.Tables["PROIZVOD"].DefaultView;
            defaultView.Sort = "NAZIVPROIZVOD";
            this.DisplayMember = "NAZIVPROIZVOD";
            this.ValueMember = "IDPROIZVOD";
            this.DataSource = defaultView;
            DeklaritComboBox.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill", "FillByFINPOREZIDPOREZ", "FillByIDJEDINICAMJERE" });
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
        public IPROIZVODDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetPROIZVODDataAdapter();
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
        public virtual int FillByFINPOREZIDPOREZFINPOREZIDPOREZ
        {
            get
            {
                return this.m_FillByFINPOREZIDPOREZFINPOREZIDPOREZ;
            }
            set
            {
                this.m_FillByFINPOREZIDPOREZFINPOREZIDPOREZ = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByIDJEDINICAMJEREIDJEDINICAMJERE
        {
            get
            {
                return this.m_FillByIDJEDINICAMJEREIDJEDINICAMJERE;
            }
            set
            {
                this.m_FillByIDJEDINICAMJEREIDJEDINICAMJERE = value;
            }
        }

        [Category("Deklarit"), DefaultValue("Fill"), TypeConverter(typeof(DeklaritComboBox.FillMethodsConverter))]
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
            // PROIZVODComboBox
            // 
            this.Name = "PROIZVODComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

