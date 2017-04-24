namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    using Infragistics.Win.UltraWinExplorerBar;
    using Infragistics.Win.UltraWinTree;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class ExplorerBarTreeItemCollection
    {
        private List<ExplorerBarTreeItem> m_List = new List<ExplorerBarTreeItem>();
        private object m_Parent;

        public ExplorerBarTreeItemCollection(object parent)
        {
            this.m_Parent = parent;
        }

        public void Add(ExplorerBarTreeItem item)
        {
            object obj2 = null;
            if (this.m_Parent is UltraExplorerBar)
            {
                UltraExplorerBarGroup group = new UltraExplorerBarGroup {
                    Text = item.Text
                };
                ((UltraExplorerBar) this.m_Parent).Groups.Add(group);
                obj2 = group;
            }
            else if (this.m_Parent is UltraExplorerBarGroup)
            {
                UltraExplorerBarGroup parent = this.m_Parent as UltraExplorerBarGroup;
                if (item.IsTreeGroup)
                {
                    UltraExplorerBarContainerControl control = new UltraExplorerBarContainerControl();
                    parent.Container = control;
                    parent.Settings.Style = GroupStyle.ControlContainer;
                    parent.ExplorerBar.Controls.Add(control);
                    UltraTree tree = new UltraTree {
                        Dock = DockStyle.Fill,
                        ImageList = parent.ExplorerBar.ImageListSmall
                    };
                    control.Controls.Add(tree);
                    UltraTreeNode node = new UltraTreeNode {
                        Text = item.Text
                    };
                    tree.Nodes.Add(node);
                    obj2 = node;
                }
                else
                {
                    UltraExplorerBarItem item2 = new UltraExplorerBarItem {
                        Text = item.Text
                    };
                    parent.Items.Add(item2);
                    obj2 = item2;
                }
            }
            else if (this.m_Parent is UltraTree)
            {
                UltraTree tree2 = this.m_Parent as UltraTree;
                UltraTreeNode node2 = new UltraTreeNode {
                    Text = item.Text
                };
                tree2.Nodes.Add(node2);
                obj2 = node2;
            }
            item.Control = obj2;
            this.m_List.Add(item);
        }
    }
}

