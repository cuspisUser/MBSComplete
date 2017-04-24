namespace Deklarit.Controls
{
    using Deklarit;
    using Deklarit.Resources;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ToolboxBitmap(typeof(DataGrid))]
    public class DeklaritDataGrid : UltraGrid
    {
        private bool m_FillAtStartup = true;
        protected static TypeConverter.StandardValuesCollection myFillMethods = new TypeConverter.StandardValuesCollection(new string[] { "Fill" });

        protected void InvokeFillByMethod(string method, IDataAdapter da, DataSet ds, MethodInfo info)
        {
            try
            {
                object[] parameters = new object[(info.GetParameters().Length - 1) + 1];
                parameters[0] = ds;
                int index = 0;
                foreach (ParameterInfo info2 in info.GetParameters())
                {
                    if (index == 0)
                    {
                        parameters[0] = ds;
                    }
                    else
                    {
                        parameters[index] = RuntimeHelpers.GetObjectValue(this.GetType().GetProperty(method + info2.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(this, null));
                    }
                    index++;
                }
                info.Invoke(da, parameters);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
            }
        }

        protected void InvokeFillByMethod(string method, IDataAdapter da, DataSet ds, MethodInfo info, int start, int size)
        {
            try
            {
                object[] parameters = new object[(info.GetParameters().Length - 1) + 1];
                parameters[0] = ds;
                int index = 0;
                foreach (ParameterInfo info2 in info.GetParameters())
                {
                    if (index == 0)
                    {
                        parameters[0] = ds;
                    }
                    else if (index < (info.GetParameters().Length - 2))
                    {
                        parameters[index] = RuntimeHelpers.GetObjectValue(this.GetType().GetProperty(method + info2.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(this, null));
                    }
                    index++;
                }
                parameters[info.GetParameters().Length - 2] = start;
                parameters[info.GetParameters().Length - 1] = size;
                info.Invoke(da, parameters);
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, Deklarit.Resources.Resources.DeklaritGrid, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true)]
        public bool FillAtStartup
        {
            get
            {
                return this.m_FillAtStartup;
            }
            set
            {
                this.m_FillAtStartup = value;
            }
        }

        public class Constants
        {
            public const string Category = "Deklarit Work With ";
        }

        internal class FillMethodsConverter : StringConverter
        {
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                return DeklaritDataGrid.myFillMethods;
            }

            public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
            {
                return true;
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        }

        internal class NativeMethods
        {
            private NativeMethods()
            {
            }

            [DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
            public static extern IntPtr SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);
        }
    }
}

