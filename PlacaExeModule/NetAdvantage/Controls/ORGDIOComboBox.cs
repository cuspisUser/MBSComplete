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

    public class ORGDIOComboBox : DeklaritComboBox
    {
        private System.Data.DataSet m_DataSet = new ORGDIODataSet();
        protected string m_FillMethod = "Fill";

        public ORGDIOComboBox()
        {
            this.Text = "IDORGDIO";
            DataView defaultView = this.DataSet.Tables["ORGDIO"].DefaultView;
            defaultView.Sort = "ORGANIZACIJSKIDIO";
            this.DisplayMember = "ORGANIZACIJSKIDIO";
            this.ValueMember = "IDORGDIO";
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
                    DataView defaultView = this.DataSet.Tables["ORGDIO"].DefaultView;
                    defaultView.Sort = "ORGANIZACIJSKIDIO";
                    this.DisplayMember = "ORGANIZACIJSKIDIO";
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
                    DataView view = ComboHelper.GetComboValues(this.DataSet, "ORGDIO", "IDORGDIO", "ORGANIZACIJSKIDIO", true, "<" + Deklarit.Resources.Resources.Empty + ">");
                    this.DataSource = null;
                    view.Sort = "Name";
                    this.DisplayMember = "Name";
                    this.ValueMember = "Id";
                    this.DataSource = view;
                }
            }
        }

        [Browsable(false), Category("Deklarit")]
        public IORGDIODataAdapter DataAdapter
        {
            get
            {
                if (DataAdapterFactory.Provider == null)
                {
                    DataAdapterFactory.Provider = new SimpleDataAdapterFactory();
                }
                if (DataAdapterFactory.Provider != null)
                {
                    return DataAdapterFactory.GetORGDIODataAdapter();
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

        [TypeConverter(typeof(DeklaritComboBox.FillMethodsConverter)), DefaultValue("Fill"), Category("Deklarit")]
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
            // ORGDIOComboBox
            // 
            this.Name = "ORGDIOComboBox";
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

