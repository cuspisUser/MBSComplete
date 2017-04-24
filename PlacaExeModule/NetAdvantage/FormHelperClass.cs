namespace NetAdvantage
{
    using Deklarit.Controls;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using System;
    using System.Collections;
    using System.Data;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class FormHelperClass
    {
        private static ResourceManager myResources = Deklarit.Resources.ResourcesManager.Instance;

        public static void ChangeTablesDefaults(DataTable table)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = table.Columns.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataColumn current = (DataColumn) enumerator.Current;
                    if ((current.DefaultValue.Equals(RuntimeHelpers.GetObjectValue(Convert.DBNull)) && !current.AutoIncrement) && !current.AllowDBNull)
                    {
                        current.DefaultValue = RuntimeHelpers.GetObjectValue(EmptyValue(current.DataType));
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

        public static object ConvertStringToTyped(string myValue, Type dataType)
        {
            if ((myValue.Length == 0) && (((dataType.Equals(typeof(short)) || dataType.Equals(typeof(int))) || (dataType.Equals(typeof(long)) || dataType.Equals(typeof(DateTime)))) || ((dataType.Equals(typeof(double)) || dataType.Equals(typeof(decimal))) || (dataType.Equals(typeof(bool)) || dataType.Equals(typeof(Guid))))))
            {
                return EmptyValue(dataType);
            }
            if (dataType.Equals(typeof(short)))
            {
                return short.Parse(myValue, CultureInfo.CurrentCulture);
            }
            if (dataType.Equals(typeof(int)))
            {
                return int.Parse(myValue, CultureInfo.CurrentCulture);
            }
            if (dataType.Equals(typeof(long)))
            {
                return long.Parse(myValue, CultureInfo.CurrentCulture);
            }
            if (dataType.Equals(typeof(double)))
            {
                return double.Parse(myValue, CultureInfo.CurrentCulture);
            }
            if (dataType.Equals(typeof(decimal)))
            {
                return decimal.Parse(myValue, CultureInfo.CurrentCulture);
            }
            if (dataType.Equals(typeof(DateTime)))
            {
                return DateTime.Parse(myValue, CultureInfo.CurrentCulture);
            }
            if (dataType.Equals(typeof(bool)))
            {
                return bool.Parse(myValue);
            }
            if (dataType.Equals(typeof(Guid)))
            {
                return new Guid(myValue);
            }
            return myValue;
        }

        public static object EmptyValue(Type dataType)
        {
            if (((dataType.Equals(typeof(short)) || dataType.Equals(typeof(int))) || (dataType.Equals(typeof(long)) || dataType.Equals(typeof(double)))) || (dataType.Equals(typeof(decimal)) || dataType.Equals(typeof(float))))
            {
                return 0;
            }
            if (dataType.Equals(typeof(string)))
            {
                return "";
            }
            if (dataType.Equals(typeof(DateTime)))
            {
                return DateTime.Today;
            }
            if (dataType.Equals(typeof(bool)))
            {
                return false;
            }
            if (dataType.Equals(typeof(byte[])))
            {
                return new byte[1];
            }
            if (!dataType.Equals(typeof(Guid)))
            {
                throw new ArgumentException(myResources.GetString("Unrecognizedtype") + " " + dataType.ToString());
            }
            return Guid.Empty;
        }

        public static UltraGridRow GetCurrentRow(UltraGrid dg)
        {
            if (dg.ActiveRow == null)
            {
                return null;
            }
            UltraGridRow activeRow = dg.ActiveRow;
            while ((activeRow.ParentRow != null) && !(activeRow.ParentRow is UltraGridGroupByRow))
            {
                activeRow = activeRow.ParentRow;
            }
            return activeRow;
        }

        public static int GetCurrentRowListIndex(UltraGrid dg)
        {
            UltraGridRow currentRow = GetCurrentRow(dg);
            if (currentRow == null)
            {
                return -1;
            }
            return currentRow.ListIndex;
        }

        public static string GetDescription(DataRow foreignKeys)
        {
            DataColumn current;
            StringBuilder builder = new StringBuilder();
            if (foreignKeys == null)
            {
                goto Label_0263;
            }
            if ((foreignKeys.Table.DataSet != null) && (foreignKeys.Table.DataSet.ExtendedProperties["Deklarit.DescriptionAttribute"] != null))
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = foreignKeys.Table.Columns.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (DataColumn) enumerator.Current;
                        if (foreignKeys.Table.DataSet.ExtendedProperties["Deklarit.DescriptionAttribute"].ToString() == current.ColumnName)
                        {
                            builder.Append(myResources.GetString("For") + " " + foreignKeys[current.ColumnName].ToString() + "  ");
                            goto Label_00DE;
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
        Label_00DE:
            if (builder.Length == 0)
            {
                IEnumerator enumerator2 = null;
                try
                {
                    enumerator2 = foreignKeys.Table.Columns.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        current = (DataColumn) enumerator2.Current;
                        if ((current.ExtendedProperties["Deklarit.IsDescription"] != null) && Convert.ToBoolean(current.ExtendedProperties["Deklarit.IsDescription"].ToString()))
                        {
                            builder.Append(myResources.GetString("For") + " " + foreignKeys[current.ColumnName].ToString() + "  ");
                            goto Label_0192;
                        }
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
            }
        Label_0192:
            if ((builder.Length == 0) && (foreignKeys.Table.PrimaryKey.Length > 0))
            {
                IEnumerator enumerator3 = null;
                builder.Append(myResources.GetString("For") + " ");
                try
                {
                    enumerator3 = foreignKeys.Table.Columns.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                        current = (DataColumn) enumerator3.Current;
                        if ((current.ExtendedProperties["IsKey"] != null) && Convert.ToBoolean(current.ExtendedProperties["IsKey"].ToString()))
                        {
                            builder.Append(foreignKeys[current.ColumnName].ToString() + " ");
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
            }
        Label_0263:
            return builder.ToString();
        }

        public static UltraGridColumn GetGridColumn(UltraGrid dg1, string columnKey)
        {
            BandEnumerator enumerator = dg1.DisplayLayout.Bands.GetEnumerator();
            while (enumerator.MoveNext())
            {
                ColumnEnumerator enumerator2 = enumerator.Current.Columns.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    UltraGridColumn current = enumerator2.Current;
                    if (current.Key == columnKey)
                    {
                        return current;
                    }
                }
            }
            return null;
        }

        public static object GetValueFromRowOrParent(DataRow currentRow, string itemName)
        {
            IEnumerator enumerator = null;
            if (currentRow.Table.Columns.Contains(itemName))
            {
                return currentRow[itemName];
            }
            try
            {
                enumerator = currentRow.Table.ParentRelations.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRelation current = (DataRelation) enumerator.Current;
                    DataRow parentRow = currentRow.GetParentRow(current);
                    if (parentRow != null)
                    {
                        return GetValueFromRowOrParent(parentRow, itemName);
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
            return null;
        }

        public static void SetReadOnly(Control control, bool readOnlyValue)
        {
            if (control is TextBox)
            {
                TextBox box = (TextBox) control;
                box.ReadOnly = readOnlyValue;
            }
            if (control is Label)
            {
                Label label = (Label) control;
                label.Enabled = !readOnlyValue;
            }
            if (control is UltraDateTimeEditor)
            {
                UltraDateTimeEditor editor = (UltraDateTimeEditor) control;
                editor.Enabled = !readOnlyValue;
            }
            if (control is UltraTextEditor)
            {
                UltraTextEditor editor2 = (UltraTextEditor) control;
                editor2.Enabled = !readOnlyValue;
            }
            if (control is UltraNumericEditor)
            {
                UltraNumericEditor editor3 = (UltraNumericEditor) control;
                editor3.Enabled = !readOnlyValue;
            }
            if (control is UltraMaskedEdit)
            {
                UltraMaskedEdit edit = (UltraMaskedEdit) control;
                edit.Enabled = !readOnlyValue;
            }
            if (control is UltraCheckEditor)
            {
                UltraCheckEditor editor4 = (UltraCheckEditor) control;
                editor4.Enabled = !readOnlyValue;
            }
            if (control is CheckBox)
            {
                CheckBox box2 = (CheckBox) control;
                box2.Enabled = !readOnlyValue;
            }
            if (control is ComboBox)
            {
                ComboBox box3 = (ComboBox) control;
                box3.Enabled = !readOnlyValue;
            }
            if (control is Button)
            {
                Button button = (Button) control;
                button.Enabled = !readOnlyValue;
            }
            if (control is LinkUltraLabelPrompt)
            {
                LinkUltraLabelPrompt prompt = (LinkUltraLabelPrompt) control;
                prompt.Enabled = !readOnlyValue;
            }
            if (typeof(DeklaritComboBox).IsAssignableFrom(control.GetType()))
            {
                DeklaritComboBox box4 = (DeklaritComboBox) control;
                box4.Enabled = !readOnlyValue;
            }
            if (typeof(UltraComboEditor).IsAssignableFrom(control.GetType()))
            {
                UltraComboEditor editor5 = (UltraComboEditor) control;
                editor5.Enabled = !readOnlyValue;
            }
        }

        public static void SetSortOrderColumns(UltraGrid dataGrid, string levelName, string orderString)
        {
            foreach (string str in orderString.Split(new char[] { ',' }))
            {
                string[] strArray = str.Trim().Split(new char[] { ' ' });
                string columnKey = strArray[0].Trim();
                string str3 = "";
                if (strArray.Length > 1)
                {
                    str3 = strArray[1].Trim().ToLower();
                }
                else
                {
                    str3 = "ASC";
                }
                bool flag = str3 != "desc";
                UltraGridColumn gridColumn = GetGridColumn(dataGrid, columnKey);
                if (gridColumn != null)
                {
                    if (flag)
                    {
                        gridColumn.SortIndicator = SortIndicator.Ascending;
                    }
                    else
                    {
                        gridColumn.SortIndicator = SortIndicator.Descending;
                    }
                }
            }
        }

        public static void SetValue(Control control, string textValue, Type columnType)
        {
            IEnumerator enumerator = null;
            if (control is TextBox)
            {
                TextBox box = (TextBox) control;
                box.Text = textValue;
            }
            if (control is Label)
            {
                Label label = (Label) control;
                label.Text = textValue;
            }
            if (control is UltraLabel)
            {
                UltraLabel label2 = (UltraLabel) control;
                label2.Text = textValue;
            }
            if (control is UltraDateTimeEditor)
            {
                UltraDateTimeEditor editor = (UltraDateTimeEditor) control;
                editor.Text = textValue;
            }
            if (control is UltraTextEditor)
            {
                UltraTextEditor editor2 = (UltraTextEditor) control;
                editor2.Text = textValue;
            }
            if (control is UltraNumericEditor)
            {
                UltraNumericEditor editor3 = (UltraNumericEditor) control;
                if (editor3.NumericType == NumericType.Double)
                {
                    editor3.Value = double.Parse(textValue, CultureInfo.CurrentCulture);
                }
                else
                {
                    editor3.Value = long.Parse(textValue, CultureInfo.CurrentCulture);
                }
            }
            if (control is UltraMaskedEdit)
            {
                UltraMaskedEdit edit = (UltraMaskedEdit) control;
                edit.Text = textValue;
            }
            if (control is UltraCheckEditor)
            {
                UltraCheckEditor editor4 = (UltraCheckEditor) control;
                if ((textValue == "true") || (textValue == "True"))
                {
                    editor4.Checked = true;
                }
                else
                {
                    editor4.Checked = false;
                }
            }
            if (control is CheckBox)
            {
                CheckBox box2 = (CheckBox) control;
                if ((textValue == "true") || (textValue == "True"))
                {
                    box2.Checked = true;
                }
                else
                {
                    box2.Checked = false;
                }
            }
            if (!(control is ComboBox))
            {
                goto Label_0252;
            }
            ComboBox box3 = (ComboBox) control;
            object objectValue = RuntimeHelpers.GetObjectValue(box3.SelectedValue);
            if (box3.DisplayMember == box3.ValueMember)
            {
                box3.SelectedIndex = box3.FindStringExact(textValue);
                goto Label_0252;
            }
            string valueMember = box3.ValueMember;
            valueMember = valueMember.Substring(valueMember.IndexOf(".") + 1);
            try
            {
                enumerator = box3.Items.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object obj3 = RuntimeHelpers.GetObjectValue(enumerator.Current);
                    DataRowView view = (DataRowView) obj3;
                    if (view.Row[valueMember].ToString().Trim().Equals(textValue.Trim()))
                    {
                        box3.SelectedItem = RuntimeHelpers.GetObjectValue(obj3);
                        goto Label_023F;
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
        Label_023F:
            box3.SelectedValue = RuntimeHelpers.GetObjectValue(ConvertStringToTyped(textValue, columnType));
        Label_0252:
            if (typeof(DeklaritComboBox).IsAssignableFrom(control.GetType()))
            {
                DeklaritComboBox box4 = (DeklaritComboBox) control;
                object obj4 = RuntimeHelpers.GetObjectValue(box4.Value);
                if (box4.DisplayMember == box4.ValueMember)
                {
                    box4.SelectedIndex = box4.FindStringExact(textValue);
                }
                else
                {
                    string str2 = box4.ValueMember;
                    str2 = str2.Substring(str2.IndexOf(".") + 1);
                    ValueListItemEnumerator enumerator2 = box4.Items.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        ValueListItem current = enumerator2.Current;
                        DataRowView listObject = (DataRowView) current.ListObject;
                        if (listObject.Row[str2].ToString().Trim().Equals(textValue.Trim()))
                        {
                            box4.SelectedItem = current;
                            break;
                        }
                    }
                    box4.Value = RuntimeHelpers.GetObjectValue(ConvertStringToTyped(textValue, columnType));
                }
            }
            if (typeof(UltraComboEditor).IsAssignableFrom(control.GetType()))
            {
                UltraComboEditor editor5 = (UltraComboEditor) control;
                object obj5 = RuntimeHelpers.GetObjectValue(editor5.Value);
                if (editor5.DisplayMember == editor5.ValueMember)
                {
                    editor5.SelectedIndex = editor5.FindStringExact(textValue);
                }
                else
                {
                    string str3 = editor5.ValueMember;
                    str3 = str3.Substring(str3.IndexOf(".") + 1);
                    ValueListItemEnumerator enumerator3 = editor5.Items.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                        ValueListItem item2 = enumerator3.Current;
                        DataRowView view3 = (DataRowView) item2.ListObject;
                        if (view3.Row[str3].ToString().Trim().Equals(textValue.Trim()))
                        {
                            editor5.SelectedItem = item2;
                            break;
                        }
                    }
                    editor5.Value = RuntimeHelpers.GetObjectValue(ConvertStringToTyped(textValue, columnType));
                }
            }
        }
    }
}

