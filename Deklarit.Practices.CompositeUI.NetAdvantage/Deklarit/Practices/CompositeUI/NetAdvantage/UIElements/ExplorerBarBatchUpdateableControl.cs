namespace Deklarit.Practices.CompositeUI.NetAdvantage.UIElements
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Services;
    using Infragistics.Win.UltraWinExplorerBar;
    using System;

    public class ExplorerBarBatchUpdateableControl : IBatchUpdateableControl
    {
        private UltraExplorerBar m_ExplorerBar;
        private ScrollbarStyle m_ScrollbarStyle;

        public ExplorerBarBatchUpdateableControl(UltraExplorerBar explorerBar)
        {
            this.m_ExplorerBar = explorerBar;
        }

        public void BeginUpdate()
        {
            ReflectionUtil.SetProperty(ReflectionUtil.GetProperty(this.m_ExplorerBar, "VisibleGroupsManager"), "SuspendVisibleGroupVerification", true);
            this.m_ScrollbarStyle = this.m_ExplorerBar.Scrollbars;
            this.m_ExplorerBar.Scrollbars = ScrollbarStyle.Never;
        }

        public void EndUpdate()
        {
            this.HideEmptyGroups();
            object property = ReflectionUtil.GetProperty(this.m_ExplorerBar, "VisibleGroupsManager");
            ReflectionUtil.SetProperty(property, "SuspendVisibleGroupVerification", false);
            ReflectionUtil.SetProperty(property, "VisibleGroupsDirty", true);
            ReflectionUtil.SetProperty(property, "GroupPositionsDirty", true);
            ReflectionUtil.InvokeMethod(property, "VerifyVisibleGroups");
            this.m_ExplorerBar.Scrollbars = this.m_ScrollbarStyle;
        }

        private void HideEmptyGroups()
        {
            UltraExplorerBarGroup group = null;
            foreach (UltraExplorerBarGroup group2 in this.m_ExplorerBar.Groups)
            {
                if (group2.Settings.Style == GroupStyle.ControlContainer)
                {
                    continue;
                }
                bool flag = false;

                UltraExplorerBarItemsCollection.UltraExplorerBarItemEnumerator enumerator2 = group2.Items.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    if (enumerator2.Current.Visible)
                    {
                        flag = true;
                        goto Label_0071;
                    }
                }

            Label_0071:
                group2.Visible = flag;
                if (flag)
                {
                    group = group2;
                }
            }
            if (group != null)
            {
                this.m_ExplorerBar.ActiveGroup = group;
            }
        }
    }
}

