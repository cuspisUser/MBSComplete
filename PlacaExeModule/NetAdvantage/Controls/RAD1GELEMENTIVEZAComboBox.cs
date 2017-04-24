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

    public class RAD1GELEMENTIVEZAComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new RAD1GELEMENTIVEZADataSet();
        protected int m_FillByIDELEMENTIDELEMENT;
        protected int m_FillByRAD1GELEMENTIIDRAD1GELEMENTIID;
        protected string m_FillMethod = "Fill";

        public RAD1GELEMENTIVEZAComboBox()
        {
            this.Text = "RAD1GELEMENTIID";
            DataView defaultView = this.DataSet.Tables["RAD1GELEMENTIVEZA"].DefaultView;
            defaultView.Sort = "RAD1GELEMENTIID";
            this.DisplayMember = "RAD1GELEMENTIID";
            this.ValueMember = "RAD1GELEMENTIID";
            this.DataSource = defaultView;
            DeklaritComboBox.myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill", "FillByIDELEMENT", "FillByRAD1GELEMENTIID" });
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
                    DataView defaultView = this.DataSet.Tables["RAD1GELEMENTIVEZA"].DefaultView;
                    defaultView.Sort = "RAD1GELEMENTIID";
                    this.DisplayMember = "RAD1GELEMENTIID";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "RAD1GELEMENTIVEZA", "RAD1GELEMENTIID", "RAD1GELEMENTIID", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Browsable(false), Category("Deklarit")]
        public IRAD1GELEMENTIVEZADataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetRAD1GELEMENTIVEZADataAdapter();
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
        public virtual int FillByIDELEMENTIDELEMENT
        {
            get
            {
                return this.m_FillByIDELEMENTIDELEMENT;
            }
            set
            {
                this.m_FillByIDELEMENTIDELEMENT = value;
            }
        }

        [Category("Deklarit")]
        public virtual int FillByRAD1GELEMENTIIDRAD1GELEMENTIID
        {
            get
            {
                return this.m_FillByRAD1GELEMENTIIDRAD1GELEMENTIID;
            }
            set
            {
                this.m_FillByRAD1GELEMENTIIDRAD1GELEMENTIID = value;
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
            // RAD1GELEMENTIVEZAComboBox
            // 
            this.Name = "RAD1GELEMENTIVEZAComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

