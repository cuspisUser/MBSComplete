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

    public class AMSKUPINEComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new AMSKUPINEDataSet();
        protected string m_FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO;
        protected string m_FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO;
        protected string m_FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO;
        protected string m_FillMethod = "Fill";

        public AMSKUPINEComboBox()
        {
            this.Text = "IDAMSKUPINE";
            DataView defaultView = this.DataSet.Tables["AMSKUPINE"].DefaultView;
            defaultView.Sort = "AM";
            this.DisplayMember = "AM";
            this.ValueMember = "IDAMSKUPINE";
            this.DataSource = defaultView;
            DeklaritComboBox.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill", "FillByKTOIZVORAIDKONTO", "FillByKTOISPRAVKAIDKONTO", "FillByKTONABAVKEIDKONTO" });
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
                    DataView defaultView = this.DataSet.Tables["AMSKUPINE"].DefaultView;
                    defaultView.Sort = "AM";
                    this.DisplayMember = "AM";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "AMSKUPINE", "IDAMSKUPINE", "AM", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Browsable(false), Category("Deklarit")]
        public IAMSKUPINEDataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetAMSKUPINEDataAdapter();
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
        public virtual string FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO
        {
            get
            {
                return this.m_FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO;
            }
            set
            {
                this.m_FillByKTOISPRAVKAIDKONTOKTOISPRAVKAIDKONTO = value;
            }
        }

        [Category("Deklarit")]
        public virtual string FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO
        {
            get
            {
                return this.m_FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO;
            }
            set
            {
                this.m_FillByKTOIZVORAIDKONTOKTOIZVORAIDKONTO = value;
            }
        }

        [Category("Deklarit")]
        public virtual string FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO
        {
            get
            {
                return this.m_FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO;
            }
            set
            {
                this.m_FillByKTONABAVKEIDKONTOKTONABAVKEIDKONTO = value;
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
            // AMSKUPINEComboBox
            // 
            this.Name = "AMSKUPINEComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

