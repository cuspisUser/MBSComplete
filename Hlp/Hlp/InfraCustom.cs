namespace Hlp
{
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinMaskedEdit;
    using Infragistics.Win.UltraWinTree;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class InfraCustom
    {
        private static void Combo_AfterColPosChanged(object sender, AfterColPosChangedEventArgs e)
        {
            if (e.PosChanged == PosChanged.Sized)
            {
                UltraCombo combo = (UltraCombo) sender;
                if (((UltraCombo)sender).FindForm() != null)
                {
                    Label label = (Label)FindControl(((UltraCombo)sender).FindForm(), "lbldynamic" + ((UltraCombo)sender).FindForm().Name + ((UltraCombo)sender).Name);
                    if (combo.DisplayMember == e.ColumnHeaders[0].Column.Key)
                    {
                        if ((e.ColumnHeaders[0].Column.CellSizeResolved.Width + 0x23) > 420)
                        {
                            combo.Width = 420;
                        }
                        else
                        {
                            combo.Width = e.ColumnHeaders[0].Column.CellSizeResolved.Width + 0x23;
                        }
                        if (label != null)
                        {
                            label.Left = ((combo.Left + combo.Width) + Conversions.ToInteger(Interaction.IIf(((UltraCombo)sender).Tag != null, 0x10, 0))) + 5;
                        }
                    }
                }
            }
        }

        public static void Combo_AfterSortChange(object sender, BandEventArgs e)
        {
            bool flag = false;
            string text = string.Empty;

            if (((UltraCombo)sender).FindForm() == null)
                return;

            Label label = (Label) FindControl(((UltraCombo) sender).FindForm(), "lbldynamic" + ((UltraCombo) sender).FindForm().Name + ((UltraCombo) sender).Name);
            if (((UltraCombo) sender).DisplayMember != e.Band.SortedColumns[0].ToString())
            {
                if ((e.Band.SortedColumns[0].ToString() == ((UltraCombo) sender).DisplayLayout.Bands[0].Columns[((UltraCombo) sender).ValueMemberResolved].Key) | (e.Band.SortedColumns[0].ToString() == ((UltraCombo) sender).DisplayLayout.Bands[0].Columns[1].Key))
                {
                    if (label != null)
                    {
                        text = label.Text;
                    }
                    flag = true;
                }
            }
            else
            {
                text = Conversions.ToString(((UltraCombo) sender).Value);
                flag = true;
            }
            ((UltraCombo) sender).DisplayMember = e.Band.SortedColumns[0].ToString();
            ((UltraCombo) sender).PerformAction(UltraComboAction.FirstRow);
            UltraCombo combo = (UltraCombo) sender;
            if (label != null)
            {
                if (combo.ValueMember == combo.DisplayMember)
                {
                    if ((combo.DisplayLayout.Bands[0].Columns[combo.ValueMemberResolved].CellSizeResolved.Width + 0x23) > 420)
                    {
                        combo.Width = 420;
                    }
                    else
                    {
                        combo.Width = combo.DisplayLayout.Bands[0].Columns[combo.ValueMemberResolved].CellSizeResolved.Width + 0x23;
                    }
                    label.Left = ((combo.Left + combo.Width) + Conversions.ToInteger(Interaction.IIf(((UltraCombo) sender).Tag != null, 0x10, 0))) + 5;
                }
                else
                {
                    if ((combo.DisplayLayout.Bands[0].Columns[1].CellSizeResolved.Width + 0x23) > 420)
                    {
                        combo.Width = 420;
                    }
                    else
                    {
                        combo.Width = combo.DisplayLayout.Bands[0].Columns[1].CellSizeResolved.Width + 0x23;
                    }
                    label.Left = ((combo.Left + combo.Width) + Conversions.ToInteger(Interaction.IIf(((UltraCombo) sender).Tag != null, 0x10, 0))) + 5;
                }
                if (flag)
                {
                    ((UltraCombo) sender).Value = text;
                    ((UltraCombo) sender).PerformAction(UltraComboAction.ToggleDropdown);
                    ((UltraCombo) sender).PerformAction(UltraComboAction.Dropdown);
                }
                if (((UltraCombo) sender).SelectedRow == null)
                {
                    label.Text = "";
                }
                else if (((UltraCombo) sender).ValueMember == ((UltraCombo) sender).DisplayMember)
                {
                    label.Text = Conversions.ToString(((UltraCombo) sender).SelectedRow.Cells[1].Value);
                }
                else
                {
                    label.Text = Conversions.ToString(((UltraCombo) sender).SelectedRow.Cells[((UltraCombo) sender).ValueMemberResolved].Value);
                }
            }
        }

        public static void Combo_ItemNotInList(object sender, ValidationErrorEventArgs e)
        {
            Label label = (Label) FindControl(((UltraCombo) sender).FindForm(), "lbldynamic" + ((UltraCombo) sender).FindForm().Name + ((UltraCombo) sender).Name);
            if (!((UltraCombo) sender).IsItemInList())
            {
                if (label != null)
                {
                    label.Text = "";
                }
                if ((Conversions.ToString(((UltraCombo) sender).Value) == "") & (((UltraCombo) sender).Text == ""))
                {
                    if (((UltraCombo) sender).NullText != "bez odabira")
                    {
                        e.RetainFocus = true;
                        PostaviGresku((UltraCombo) sender, "Polje obvezno");
                    }
                    else
                    {
                        PostaviGresku((UltraCombo) sender, "");
                    }
                }
                else
                {
                    e.RetainFocus = true;
                    PostaviGresku((UltraCombo) sender, "Upisana vrijednost ne postoji u listi");
                }
            }
        }

        private static void Combo_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyCode = e.KeyCode;
            if (((((keyCode != Keys.Return) && (keyCode != Keys.Tab)) && ((keyCode != Keys.Escape) && (keyCode != Keys.F1))) && (((keyCode != Keys.F2) && (keyCode != Keys.F3)) && ((keyCode != Keys.F4) && (keyCode != Keys.F5)))) && ((((keyCode != Keys.F6) && (keyCode != Keys.F7)) && ((keyCode != Keys.F8) && (keyCode != Keys.F9))) && (((keyCode != Keys.F10) && (keyCode != Keys.F11)) && ((keyCode != Keys.F12) && !((UltraCombo) sender).IsDroppedDown))))
            {
                ((UltraCombo) sender).PerformAction(UltraComboAction.Dropdown);
            }
        }

        private static void combo_RowSelected(object sender, RowSelectedEventArgs e)
        {
            Label label = (Label) FindControl(((UltraCombo) sender).FindForm(), "lbldynamic" + ((UltraCombo) sender).FindForm().Name + ((UltraCombo) sender).Name);
            if ((label != null) && (((UltraCombo) sender).SelectedRow != null))
            {
                if (((UltraCombo) sender).ValueMember == ((UltraCombo) sender).DisplayMember)
                {
                    label.Text = Conversions.ToString(((UltraCombo) sender).SelectedRow.Cells[1].Value);
                }
                else
                {
                    label.Text = Conversions.ToString(((UltraCombo) sender).SelectedRow.Cells[((UltraCombo) sender).ValueMemberResolved].Value);
                }
            }
        }

        private static void Combo_Validating(object sender, CancelEventArgs e)
        {
            if (((UltraCombo) sender).IsItemInList())
            {
                PostaviGresku((UltraCombo) sender, "");
            }
        }

        public static Control FindControl(Control ctrlParent, string sFindCtrlName)
        {
            IEnumerator enumerator = null;
            Control control3 = ctrlParent;
            try
            {
                enumerator = control3.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control current = (Control) enumerator.Current;
                    if (current.Name.ToLower() == sFindCtrlName.ToLower())
                    {
                        return current;
                    }
                    if (current.HasChildren)
                    {
                        current = FindControl(current, sFindCtrlName);
                        if (current != null)
                        {
                            return current;
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
            control3 = null;
            return null;
        }

        public static void G_PretvoriEnterUTab_UltraKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{TAB}");
            }
        }

        public static void InicijalizirajCombo(UltraCombo combo, object PocetnaVrijednost = null, bool prikaziLabel = true, bool autoSize = true)
        {
            System.Drawing.Point point = new System.Drawing.Point();
            ErrorProvider provider = new ErrorProvider();
            combo.Tag = provider;
            combo.KeyPress += new KeyPressEventHandler(InfraCustom.PretvoriEnterUTab);
            combo.Validating += new CancelEventHandler(InfraCustom.Combo_Validating);
            combo.AfterSortChange += new BandEventHandler(InfraCustom.Combo_AfterSortChange);
            combo.ItemNotInList += new Infragistics.Win.UltraWinGrid.ItemNotInListEventHandler(InfraCustom.Combo_ItemNotInList);
            combo.KeyDown += new KeyEventHandler(InfraCustom.Combo_KeyDown);
            combo.RowSelected += new RowSelectedEventHandler(InfraCustom.combo_RowSelected);
            combo.AfterColPosChanged += new AfterColPosChangedEventHandler(InfraCustom.Combo_AfterColPosChanged);
            UcitajComboLayout(combo);

            Label label = new Label();

            if (prikaziLabel)
            {
                try
                {
                    label.Name = "lbldynamic" + combo.FindForm().Name + combo.Name;
                }
                catch (Exception)
                {
                    label.Name = "lbldynamic" + combo.Name;
                }
            }

            if (autoSize)
            {
                if (combo.ValueMember == combo.DisplayMember)
                {
                    if ((combo.DisplayLayout.Bands[0].Columns[combo.ValueMemberResolved].CellSizeResolved.Width + 0x23) > 600)
                    {
                        combo.Width = 600;
                    }
                    else
                    {
                        combo.Width = combo.DisplayLayout.Bands[0].Columns[combo.ValueMemberResolved].CellSizeResolved.Width + 0x23;
                    }
                }
                else if ((combo.DisplayLayout.Bands[0].Columns[1].CellSizeResolved.Width + 0x23) > 600)
                {
                    combo.Width = 600;
                }
                else
                {
                    combo.Width = combo.DisplayLayout.Bands[0].Columns[1].CellSizeResolved.Width + 0x23;
                }
            }

            if (PocetnaVrijednost == null)
            {
                if (prikaziLabel)
                {
                    if (combo.SelectedRow != null)
                    {
                        if (combo.ValueMember == combo.DisplayMember)
                        {
                            label.Text = Conversions.ToString(combo.SelectedRow.Cells[1].Value);
                        }
                        else
                        {
                            label.Text = Conversions.ToString(combo.SelectedRow.Cells[combo.ValueMemberResolved].Value);
                        }
                    }
                    else
                    {
                        label.Text = "";
                    }
                }
            }
            else
            {
                combo.SelectedRow = null;
                combo.Value = RuntimeHelpers.GetObjectValue(PocetnaVrijednost);
            }

            if (prikaziLabel)
            {
                label.AutoSize = true;
                point.X = ((combo.Location.X + combo.Width) + Conversions.ToInteger(Interaction.IIf(combo.Tag != null, 0x10, 0))) + 5;
                point.Y = combo.Location.Y + 5;
                label.Location = point;
                combo.Parent.Controls.Add(label);
                label.BackColor = Color.Transparent;
            }
        }

        public static void Kontrola_GotFocus(object sender, EventArgs e)
        {
            if (sender is UltraMaskedEdit)
            {
                ((UltraMaskedEdit) sender).SelectAll();
            }
            if (sender is UltraTextEditor)
            {
                ((UltraTextEditor) sender).SelectAll();
            }
            if (sender is UltraDateTimeEditor)
            {
                ((UltraDateTimeEditor) sender).SelectAll();
            }
            if (sender is UltraNumericEditor)
            {
                ((UltraNumericEditor) sender).SelectAll();
            }
        }

        public static string OznaceneDOK(UltraTree ultratree1)
        {
            StringBuilder builder = new StringBuilder();
            Infragistics.Win.UltraWinTree.NodeEnumerator enumerator = ultratree1.Nodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraTreeNode current = enumerator.Current;
                if (current.Key == "DOK")
                {
                    Infragistics.Win.UltraWinTree.NodeEnumerator enumerator2 = current.Nodes.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        UltraTreeNode node2 = enumerator2.Current;
                        if (node2.CheckedState == CheckState.Checked)
                        {
                            if (builder.Length > 0)
                            {
                                builder.Append(",");
                            }
                            DataRow tag = (DataRow) node2.Tag;
                            builder.Append(RuntimeHelpers.GetObjectValue(tag["IDDOKUMENT"]));
                        }
                    }
                }
            }
            return builder.ToString();
        }

        public static string OznaceneMT(UltraTree ultratree1)
        {
            StringBuilder builder = new StringBuilder();
            Infragistics.Win.UltraWinTree.NodeEnumerator enumerator = ultratree1.Nodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraTreeNode current = enumerator.Current;
                if (current.Key == "MT")
                {
                    Infragistics.Win.UltraWinTree.NodeEnumerator enumerator2 = current.Nodes.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        UltraTreeNode node2 = enumerator2.Current;
                        if (node2.CheckedState == CheckState.Checked)
                        {
                            if (builder.Length > 0)
                            {
                                builder.Append(",");
                            }
                            DataRow tag = (DataRow) node2.Tag;
                            builder.Append(RuntimeHelpers.GetObjectValue(tag["idMJESTOTROSKA"]));
                        }
                    }
                }
            }
            return builder.ToString();
        }

        public static string OznaceneOJ(UltraTree ultratree1)
        {
            StringBuilder builder = new StringBuilder();
            Infragistics.Win.UltraWinTree.NodeEnumerator enumerator = ultratree1.Nodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                UltraTreeNode current = enumerator.Current;
                if (current.Key == "ORGJED")
                {
                    Infragistics.Win.UltraWinTree.NodeEnumerator enumerator2 = current.Nodes.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        UltraTreeNode node2 = enumerator2.Current;
                        if (node2.CheckedState == CheckState.Checked)
                        {
                            if (builder.Length > 0)
                            {
                                builder.Append(",");
                            }
                            DataRow tag = (DataRow) node2.Tag;
                            builder.Append(RuntimeHelpers.GetObjectValue(tag["idorgjed"]));
                        }
                    }
                }
            }
            return builder.ToString();
        }

        public static void PostaviEnterUTabSvimEditKontrolama(Control ctrlParent)
        {
            IEnumerator enumerator = null;
            Control control2 = ctrlParent;
            try
            {
                enumerator = control2.Controls.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Control current = (Control) enumerator.Current;
                    if ((((((current is UltraComboEditor) | (current is UltraTextEditor)) | (current is UltraDateTimeEditor)) | (current is UltraNumericEditor)) | (current is CheckBox)) | (current is TextBox))
                    {
                        current.KeyPress += new KeyPressEventHandler(InfraCustom.PretvoriEnterUTab);
                    }
                    else if (current.HasChildren)
                    {
                        PostaviEnterUTabSvimEditKontrolama(current);
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
            control2 = null;
        }

        public static void PostaviGresku(UltraCombo combo, string opisgreske)
        {
            if (combo.Tag != null)
            {
                ((ErrorProvider) combo.Tag).SetError(combo, opisgreske);
            }
        }

        public static void PostaviSelectAllSvimEditKontrolama(Control ctrlParent)
        {
            IEnumerator enumerator = null;
            Control control2 = ctrlParent;

            if (control2.Controls.Count > 0)
            {
                try
                {
                    enumerator = control2.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        Control current = (Control)enumerator.Current;
                        if ((((current is UltraMaskedEdit) | (current is UltraTextEditor)) | (current is UltraDateTimeEditor)) | (current is UltraNumericEditor))
                        {
                            current.GotFocus += new EventHandler(InfraCustom.Kontrola_GotFocus);
                        }
                        else if (current.HasChildren)
                        {
                            PostaviSelectAllSvimEditKontrolama(current);
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

            control2 = null;
        }

        public static void PretvoriEnterUTab(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{TAB}");
            }
        }

        public static void UcitajComboLayout(UltraCombo combo)
        {
            if (combo.FindForm() != null)
            {
                if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\" + combo.FindForm().Name + combo.Name.ToString() + ".lyt"))
                {
                    FileStream stream = new FileStream(System.Windows.Forms.Application.StartupPath + @"\" + combo.FindForm().Name + combo.Name.ToString() + ".lyt", FileMode.Open);
                    stream.Seek(0L, SeekOrigin.Begin);
                    combo.DisplayLayout.Load(stream);
                    stream.Close();

                    // Matija - ovaj return je dodan pošto je ostatak bio u IF petlji
                    return;
                }
            }

            if (combo.Rows.Count > 0)
            {
                ColumnEnumerator enumerator = combo.DisplayLayout.Bands[0].Columns.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    enumerator.Current.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, true);
                }
            }
            combo.DisplayLayout.Bands[0].Columns[combo.ValueMemberResolved].SortIndicator = SortIndicator.Ascending;
        }
    }
}

