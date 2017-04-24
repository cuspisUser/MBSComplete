namespace NetAdvantage
{
    using Deklarit.Controls;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class GenericFormClass
    {
        private bool autoNumber;
        private DataColumnCollection columnCollection;
        private ArrayList DataGrids;
        private string firstLevelName;
        private DataSet formDataSet;
        private string frameworkDescription;
        private Control.ControlCollection m_Controls;
        private DeklaritMode m_Mode;
        private ResourceManager myResources = Deklarit.Resources.ResourcesManager.Instance;
        private string objectName;
        private int rowCurrent = -1;

        public GenericFormClass(string frameworkDescriptionValue, string firstLevelNameValue, string objectNameValue, DeklaritMode modeValue, DataSet formDataSetValue, DataColumnCollection columnCollectionValue, Control.ControlCollection controlsValue, ArrayList dataGridsValue, bool autoNumberValue)
        {
            this.frameworkDescription = frameworkDescriptionValue;
            this.firstLevelName = firstLevelNameValue;
            this.objectName = objectNameValue;
            this.m_Mode = modeValue;
            this.formDataSet = formDataSetValue;
            this.columnCollection = columnCollectionValue;
            this.m_Controls = controlsValue;
            this.DataGrids = dataGridsValue;
            this.autoNumber = autoNumberValue;
        }

        public void BooleanFormat(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(CheckState))
            {
                if (e.Value.Equals(DBNull.Value))
                {
                    e.Value = CheckState.Indeterminate;
                }
                else if (e.Value.Equals(true))
                {
                    e.Value = CheckState.Checked;
                }
                else if (e.Value.Equals(false))
                {
                    e.Value = CheckState.Unchecked;
                }
            }
        }

        public void BooleanParse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(bool))
            {
                if (e.Value.Equals(CheckState.Indeterminate))
                {
                    e.Value = DBNull.Value;
                }
                else if (e.Value.Equals(CheckState.Checked))
                {
                    e.Value = true;
                }
                else if (e.Value.Equals(CheckState.Unchecked))
                {
                    e.Value = false;
                }
            }
        }

        public void CellChangedBase(DataSet dataset1, object sender)
        {
            UltraGrid grid = (UltraGrid) sender;
            if ((this.Mode != DeklaritMode.Insert) && (GetCurrentRowIndex(grid) != this.rowCurrent))
            {
                this.rowCurrent = GetCurrentRowIndex(grid);
                if (IsCurrentRowAddRow(grid))
                {
                    this.ChangeDataGridStyle(true);
                }
                else
                {
                    this.ChangeDataGridStyle(false);
                }
            }
        }

        private void ChangeDataGridStyle(bool add)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = this.DataGrids.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    UltraGrid current = (UltraGrid) enumerator.Current;
                    UltraGridBand band = current.DisplayLayout.Bands[0];
                    ColumnEnumerator enumerator2 = band.Columns.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        IEnumerator enumerator3 = null;
                        UltraGridColumn column = enumerator2.Current;
                        string key = column.Key;
                        bool flag = false;
                        try
                        {
                            enumerator3 = new AttributeAllKeysEnumeratorCollection(this.formDataSet.Tables).GetEnumerator();
                            while (enumerator3.MoveNext())
                            {
                                if (Conversions.ToString(enumerator3.Current) == key)
                                {
                                    flag = true;
                                }
                            }
                        }
                        finally
                        {
                            if (enumerator3 is IDisposable)
                            {
                                (enumerator3 as IDisposable).Dispose();
                            }
                        }
                        if (flag)
                        {
                            if (add)
                            {
                                column.CellActivation = Activation.AllowEdit;
                            }
                            else
                            {
                                column.CellActivation = Activation.ActivateOnly;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
        }

        public void ContextMenu1PopupBase(ContextMenu contextMenu1, DataRow currentRow)
        {
            Control sourceControl = contextMenu1.SourceControl;
            DataTable table = currentRow.Table;
            if ((sourceControl.Tag != null) && table.Columns.Contains(Conversions.ToString(sourceControl.Tag)))
            {
                if (table.Columns[Conversions.ToString(sourceControl.Tag)].AllowDBNull)
                {
                    if (currentRow[Conversions.ToString(sourceControl.Tag)].Equals(RuntimeHelpers.GetObjectValue(Convert.DBNull)))
                    {
                        contextMenu1.MenuItems[0].Enabled = false;
                        contextMenu1.MenuItems[0].Checked = true;
                        contextMenu1.MenuItems[0].Text = "DBNull";
                    }
                    else
                    {
                        contextMenu1.MenuItems[0].Enabled = true;
                        contextMenu1.MenuItems[0].Checked = false;
                        contextMenu1.MenuItems[0].Text = this.myResources.GetString("SetDBNull");
                    }
                }
                else
                {
                    contextMenu1.MenuItems[0].Enabled = false;
                    contextMenu1.MenuItems[0].Checked = true;
                    contextMenu1.MenuItems[0].Text = this.myResources.GetString("NotAllowNull");
                }
            }
        }

        private static int CountRows(DataRowCollection coll)
        {
            IEnumerator enumerator = null;
            int num2 = 0;
            try
            {
                enumerator = coll.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    if ((current.RowState != DataRowState.Deleted) && (current.RowState != DataRowState.Detached))
                    {
                        num2++;
                    }
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            return num2;
        }

        public void DataGridKeys(DataSet dataSet1)
        {
        }

        public void DateFormat(object sender, ConvertEventArgs e)
        {
            if ((e.DesiredType == typeof(string)) && (e.Value != null))
            {
                if (e.Value.Equals(DBNull.Value))
                {
                    e.Value = "";
                }
                else if ((DateTime.Compare(Conversions.ToDate(e.Value), new UltraDateTimeEditor().MinDate) < 0) || (DateTime.Compare(Conversions.ToDate(e.Value), new UltraDateTimeEditor().MaxDate) > 0))
                {
                    e.Value = "";
                }
            }
        }

        public void DateParse(object sender, ConvertEventArgs e)
        {
            if ((e.DesiredType == typeof(DateTime)) && (e.Value != null))
            {
                if (e.Value.Equals(DBNull.Value))
                {
                    e.Value = DBNull.Value;
                }
                else if (e.Value.ToString().Length == 0)
                {
                    e.Value = DBNull.Value;
                }
                else if ((DateTime.Compare(Convert.ToDateTime(RuntimeHelpers.GetObjectValue(e.Value), CultureInfo.CurrentCulture), new UltraDateTimeEditor().MinDate) < 0) || (DateTime.Compare(Convert.ToDateTime(RuntimeHelpers.GetObjectValue(e.Value), CultureInfo.CurrentCulture), new UltraDateTimeEditor().MaxDate) > 0))
                {
                    e.Value = DBNull.Value;
                }
                else
                {
                    e.Value = DateTime.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
                }
            }
        }

        public void DateParseEmpty(object sender, ConvertEventArgs e)
        {
            try
            {
                if (e.DesiredType == typeof(DateTime))
                {
                    if (e.Value.Equals(DBNull.Value))
                    {
                        e.Value = DBNull.Value;
                    }
                    else if (e.Value.ToString().Length == 0)
                    {
                        e.Value = DateTime.MinValue;
                    }
                    else if ((DateTime.Compare(Convert.ToDateTime(RuntimeHelpers.GetObjectValue(e.Value), CultureInfo.CurrentCulture), new UltraDateTimeEditor().MinDate) < 0) || (DateTime.Compare(Convert.ToDateTime(RuntimeHelpers.GetObjectValue(e.Value), CultureInfo.CurrentCulture), new UltraDateTimeEditor().MaxDate) > 0))
                    {
                        e.Value = DateTime.MinValue;
                    }
                    else
                    {
                        e.Value = DateTime.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
                    }
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //e.Value = DBNull.Value;
            }
        }

        public void DateParseNotNull(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(DateTime))
            {
                if (e.Value.ToString().Length == 0)
                {
                    e.Value = DateTime.Now;
                }
                else if ((DateTime.Compare(Convert.ToDateTime(RuntimeHelpers.GetObjectValue(e.Value)), new UltraDateTimeEditor().MinDate) < 0) || (DateTime.Compare(Convert.ToDateTime(RuntimeHelpers.GetObjectValue(e.Value)), new UltraDateTimeEditor().MaxDate) > 0))
                {
                    e.Value = DateTime.Now;
                }
                else
                {
                    e.Value = DateTime.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
                }
            }
        }

        public static bool EndEditBindingSource(BindingSource bindingSource, WorkItem workItem, Control host)
        {
            IUIMessageService service = workItem.Services.Get<IUIMessageService>();
            service.Clear();
            try
            {
                bindingSource.EndEdit();
            }
            catch (DataException exception1)
            {
                throw exception1;
                //DataException exception = exception1;
                //service.ShowError(host, exception.Message);
                
                //return false;
            }
            return true;
        }

        public static bool EndEditDataRow(DataRow dataRow, WorkItem workItem, Control host)
        {
            IUIMessageService service = workItem.Services.Get<IUIMessageService>();
            service.Clear();
            try
            {
                dataRow.EndEdit();
            }
            catch (DataException exception1)
            {
                throw exception1;
                //DataException exception = exception1;
                //service.ShowError(host, exception.Message);
                
                //return false;
            }
            return true;
        }

        public Control FindControl(string controlId)
        {
            Control control2 = new Control();
            control2 = this.SearchInChildControl(this.m_Controls, controlId);
            if (control2 == null)
            {
                return null;
            }
            return control2;
        }

        public void FormLoadStyle()
        {
            string str = string.Empty;
            IEnumerator enumerator = null;
            try
            {
                enumerator = new AttributeKeyEnumeratorCollection(this.columnCollection).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    str = Conversions.ToString(enumerator.Current);
                    this.SetReadOnly(str, ((this.Mode == DeklaritMode.Update) || (this.Mode == DeklaritMode.Delete)) || (this.Mode == DeklaritMode.Select));
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            if (this.Mode == DeklaritMode.Insert)
            {
                this.ChangeDataGridStyle(true);
            }
            else
            {
                if ((this.Mode == DeklaritMode.Delete) || (this.Mode == DeklaritMode.Select))
                {
                    IEnumerator enumerator2 = null;
                    IEnumerator enumerator3 = null;
                    try
                    {
                        enumerator2 = new AttributeEnabledEnumeratorCollection(this.columnCollection).GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            str = Conversions.ToString(enumerator2.Current);
                            this.SetReadOnly(str, true);
                        }
                    }
                    finally
                    {
                        if (enumerator2 is IDisposable)
                        {
                            (enumerator2 as IDisposable).Dispose();
                        }
                    }
                    try
                    {
                        enumerator3 = this.DataGrids.GetEnumerator();
                        while (enumerator3.MoveNext())
                        {
                            UltraGrid current = (UltraGrid) enumerator3.Current;
                            current.Enabled = false;
                        }
                    }
                    finally
                    {
                        if (enumerator3 is IDisposable)
                        {
                            (enumerator3 as IDisposable).Dispose();
                        }
                    }
                }
                this.ChangeDataGridStyle(false);
            }
        }

        public Control GetControl(string controlId)
        {
            Control control2 = new Control();
            Control control3 = new Control();
            control2 = this.SearchInChildControl(this.m_Controls, controlId);
            if (control2 == null)
            {
                return control3;
            }
            return control2;
        }

        private static int GetCurrentRowIndex(UltraGrid dataGrid1)
        {
            if (dataGrid1.ActiveRow != null)
            {
                return dataGrid1.ActiveRow.ListIndex;
            }
            return -1;
        }

        public Control GetLabelControl(string controlId)
        {
            Control control2 = new Control();
            Control control3 = new Control();
            control2 = this.SearchInChildControl(this.m_Controls, "label" + controlId);
            if (control2 == null)
            {
                return control3;
            }
            return control2;
        }

        public void GuidParse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(Guid))
            {
                Guid guid = new Guid(Conversions.ToString(e.Value));
                e.Value = guid;
            }
        }

        private static bool IsCurrentRowAddRow(UltraGrid dataGrid1)
        {
            if (dataGrid1.ActiveRow == null)
            {
                return false;
            }
            UltraGridRow activeRow = dataGrid1.ActiveRow;
            DataRowView listObject = null;
            if (activeRow.ListObject is DataRowView)
            {
                listObject = (DataRowView) activeRow.ListObject;
            }
            return (activeRow.IsAddRow || (((listObject != null) && (listObject.Row != null)) && (listObject.Row.RowState == DataRowState.Added)));
        }

        public bool IsDelete()
        {
            return (this.Mode == DeklaritMode.Delete);
        }

        public bool IsInsert()
        {
            return (this.Mode == DeklaritMode.Insert);
        }

        public void IsPasswordFormat(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(string))
            {
                if (e.Value.GetType() == typeof(byte[]))
                {
                    byte[] buffer = (byte[]) e.Value;
                    if ((buffer.Length == 0) || ((buffer.Length == 1) && buffer[0].Equals((byte) 0)))
                    {
                        e.Value = "";
                        return;
                    }
                }
                if (e.Value is DBNull)
                {
                    e.Value = "";
                }
                else
                {
                    e.Value = "**********";
                }
            }
        }

        public void IsPasswordParse(object sender, ConvertEventArgs e)
        {
            if ((e.DesiredType == typeof(byte[])) && ((e.Value is string) && (Conversions.ToString(e.Value) != "**********")))
            {
                e.Value = Encoding.Unicode.GetBytes(Conversions.ToString(e.Value));
            }
        }

        public bool IsSelect()
        {
            return (this.Mode == DeklaritMode.Select);
        }

        public bool IsUpdate()
        {
            return (this.Mode == DeklaritMode.Update);
        }

        public void MouseEnterTextBase(ToolTip toolTip1, DataRow currentRow, object sender)
        {
            Control control = (Control) sender;

            if (currentRow == null)
                return;

            DataTable table = currentRow.Table;
            if (control.Tag != null)
            {
                string name = Conversions.ToString(control.Tag);
                if (table.Columns.Contains(name))
                {
                    if (table.Columns[name].AllowDBNull)
                    {
                        if (currentRow[name].Equals(RuntimeHelpers.GetObjectValue(Convert.DBNull)))
                        {
                            toolTip1.SetToolTip(control, "DBNull");
                        }
                        else
                        {
                            toolTip1.SetToolTip(control, this.myResources.GetString("AllowNull"));
                        }
                    }
                    else
                    {
                        toolTip1.SetToolTip(control, "");
                    }
                }
                else
                {
                    toolTip1.SetToolTip(control, "");
                }
            }
        }

        public void NumericFormat(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(string))
            {
                IEnumerator enumerator = null;
                Binding binding = (Binding) sender;
                string str = Conversions.ToString(binding.Control.Tag);
                int num = 0;
                try
                {
                    enumerator = this.columnCollection.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataColumn current = (DataColumn) enumerator.Current;
                        if (current.ColumnName == str)
                        {
                            num = int.Parse(current.ExtendedProperties["Decimals"].ToString(), CultureInfo.CurrentCulture);
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (num != 0)
                {
                    if (e.Value.GetType().Equals(typeof(short)))
                    {
                        e.Value = Conversions.ToShort(e.Value).ToString("F" + num.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    }
                    if (e.Value.GetType().Equals(typeof(int)))
                    {
                        e.Value = Conversions.ToInteger(e.Value).ToString("F" + num.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    }
                    if (e.Value.GetType().Equals(typeof(long)))
                    {
                        e.Value = Conversions.ToLong(e.Value).ToString("F" + num.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    }
                    if (e.Value.GetType().Equals(typeof(decimal)))
                    {
                        e.Value = Conversions.ToDecimal(e.Value).ToString("F" + num.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    }
                    if (e.Value.GetType().Equals(typeof(double)))
                    {
                        e.Value = Conversions.ToDouble(e.Value).ToString("F" + num.ToString(CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    }
                }
            }
        }

        public void NumericParse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(short))
            {
                e.Value = short.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (e.DesiredType == typeof(int))
            {
                e.Value = int.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (e.DesiredType == typeof(long))
            {
                e.Value = long.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (e.DesiredType == typeof(decimal))
            {
                e.Value = decimal.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (e.DesiredType == typeof(double))
            {
                e.Value = double.Parse(e.Value.ToString(), CultureInfo.CurrentCulture);
            }
        }

        private Control SearchInChildControl(Control.ControlCollection controls, string controlId)
        {
            if (controls != null)
            {
                int num2 = controls.Count - 1;
                for (int i = 0; i <= num2; i++)
                {
                    Control control2 = controls[i];
                    if (((control2.Tag != null) && (control2.Tag is string)) && (controlId == Conversions.ToString(control2.Tag)))
                    {
                        return control2;
                    }
                    Control control3 = this.SearchInChildControl(control2.Controls, controlId);
                    if (control3 != null)
                    {
                        return control3;
                    }
                }
            }
            return null;
        }

        public void SetNullItemClickBase(object sender, DataRow currentRow)
        {
            Control sourceControl = ((ContextMenu) ((MenuItem) sender).Parent).SourceControl;
            string controlId = "";
            if (sourceControl.Tag != null)
            {
                controlId = Conversions.ToString(sourceControl.Tag);
            }
            if (sourceControl is DeklaritComboBox)
            {
                DeklaritComboBox box = (DeklaritComboBox) sourceControl;
                if (box.ComboBox.Tag != null)
                {
                    controlId = Conversions.ToString(box.ComboBox.Tag);
                    box.SelectedIndex = -1;
                }
            }
            if ((controlId.Length == 0) && (sourceControl.Parent != null))
            {
                sourceControl = sourceControl.Parent;
                controlId = Conversions.ToString(sourceControl.Tag);
            }
            this.GetControl(controlId).Focus();
            if (sourceControl is TextBox)
            {
                TextBox box2 = (TextBox) sourceControl;
                box2.Text = "";
            }
            if (sourceControl is UltraDateTimeEditor)
            {
                UltraDateTimeEditor editor = (UltraDateTimeEditor) sourceControl;
                editor.Value = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (sourceControl is UltraTextEditor)
            {
                UltraTextEditor editor2 = (UltraTextEditor) sourceControl;
                editor2.Text = "";
            }
            if (sourceControl is UltraNumericEditor)
            {
                UltraNumericEditor editor3 = (UltraNumericEditor) sourceControl;
                editor3.Value = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            }
            if (sourceControl is UltraMaskedEdit)
            {
                UltraMaskedEdit edit = (UltraMaskedEdit) sourceControl;
                edit.Text = "";
            }
            if (sourceControl is LinkUltraLabelPrompt)
            {
                LinkUltraLabelPrompt prompt = (LinkUltraLabelPrompt) sourceControl;
                prompt.UltraLabel.Text = "";
                prompt.UltraLabel.Focus();
                string descriptionTag = prompt.DescriptionTag;
                if ((descriptionTag != null) && (descriptionTag.Length != 0))
                {
                    currentRow[descriptionTag] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
                }
            }
            currentRow[controlId] = RuntimeHelpers.GetObjectValue(Convert.DBNull);
            DataColumn column = currentRow.Table.Columns[controlId];
            if (((column != null) && (column.ExtendedProperties["TreatEmptyAsNull"] != null)) && (Convert.ToBoolean(column.ExtendedProperties["TreatEmptyAsNull"].ToString()) && !column.DataType.Equals(typeof(DateTime))))
            {
                currentRow[controlId] = RuntimeHelpers.GetObjectValue(FormHelperClass.EmptyValue(column.DataType));
            }
        }

        public void SetReadOnly(string controlId, bool readOnlyValue)
        {
            FormHelperClass.SetReadOnly(this.GetControl(controlId), readOnlyValue);
        }

        public void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.frameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public DeklaritMode Mode
        {
            get
            {
                return this.m_Mode;
            }
            set
            {
                this.m_Mode = value;
            }
        }
    }
}

