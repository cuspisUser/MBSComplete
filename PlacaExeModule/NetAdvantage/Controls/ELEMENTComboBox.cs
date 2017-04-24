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

    public class ELEMENTComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new ELEMENTDataSet();
        protected string m_FillByIDOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA;
        protected short m_FillByIDVRSTAELEMENTAIDVRSTAELEMENTA;
        protected string m_FillMethod = "Fill";

        public ELEMENTComboBox()
        {
            this.Text = "IDELEMENT";
            DataView defaultView = this.DataSet.Tables["ELEMENT"].DefaultView;
            defaultView.Sort = "EL";
            this.DisplayMember = "EL";
            this.ValueMember = "IDELEMENT";
            this.DataSource = defaultView;
            DeklaritComboBox.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill", "FillByIDVRSTAELEMENTA", "FillByIDOSNOVAOSIGURANJA" });
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
                    DataView defaultView = this.DataSet.Tables["ELEMENT"].DefaultView;
                    defaultView.Sort = "EL";
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
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Category("Deklarit"), Browsable(false)]
        public IELEMENTDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetELEMENTDataAdapter();
                }
                return null;
            }
        }

        [Browsable(false), Category("Deklarit")]
        public System.Data.DataSet DataSet
        {
            get
            {
                return this.m_DataSet;
            }
        }

        [Category("Deklarit")]
        public virtual string FillByIDOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA
        {
            get
            {
                return this.m_FillByIDOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA;
            }
            set
            {
                this.m_FillByIDOSNOVAOSIGURANJAIDOSNOVAOSIGURANJA = value;
            }
        }

        [Category("Deklarit")]
        public virtual short FillByIDVRSTAELEMENTAIDVRSTAELEMENTA
        {
            get
            {
                return this.m_FillByIDVRSTAELEMENTAIDVRSTAELEMENTA;
            }
            set
            {
                this.m_FillByIDVRSTAELEMENTAIDVRSTAELEMENTA = value;
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
            // ELEMENTComboBox
            // 
            this.Name = "ELEMENTComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

