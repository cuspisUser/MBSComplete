namespace Deklarit.Practices.CompositeUI.NetAdvantage.MenuEntryAdapters
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Commands;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Infragistics.Win.UltraWinExplorerBar;
    using Infragistics.Win.UltraWinTree;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;

    public class ToolStripExplorerBarAdapter : IUICommandDefinitionVerticalToolPanelAdapterService, IUICommandDefinitionAdapterService
    {
        private static Microsoft.Practices.CompositeUI.Commands.Command AddCommand(WorkItem workItem, UICommandDefinition entry, Control host)
        {
            if (!workItem.Commands.Contains(entry.Name))
            {
                Microsoft.Practices.CompositeUI.Commands.Command item = new ShortcutCommand(entry.ShortcutKeys, host);
                workItem.Commands.Add(item, entry.Name);
                return item;
            }
            return workItem.Commands[entry.Name];
        }

        public void AddElements(WorkItem workItem, IEnumerable<UICommandDefinition> menuEntryEnumerable, Control host)
        {
            foreach (UICommandDefinition definition in menuEntryEnumerable)
            {
                if (definition.IsCategoryOrFolder)
                {
                    if (!workItem.UIExtensionSites.Contains(definition.Site + "." + definition.Name))
                    {
                        if (definition.Parent != null)
                        {
                            Microsoft.Practices.CompositeUI.Commands.Command command = (workItem is LocalCommandWorkItem) ? AddShortcutCommand((LocalCommandWorkItem)workItem, definition, host) : AddCommand(workItem, definition, host);
                            UltraTreeNode uiElement = this.CreateTreeNode(workItem, definition);
                            workItem.UIExtensionSites[definition.Site].Add<UltraTreeNode>(uiElement);
                            command.AddInvoker(uiElement, "Click");
                            workItem.UIExtensionSites.RegisterSite(definition.Site + "." + definition.Name, uiElement.Nodes);
                        }
                        else if (!definition.HasFolderChild)
                        {
                            UltraExplorerBarGroup group = new UltraExplorerBarGroup
                            {
                                Tag = definition,
                                Text = definition.Text
                            };
                            workItem.UIExtensionSites[definition.Site].Add<UltraExplorerBarGroup>(group);
                            workItem.UIExtensionSites.RegisterSite(definition.Site + "." + definition.Name, group.Items);
                            ((workItem is LocalCommandWorkItem) ? AddShortcutCommand((LocalCommandWorkItem)workItem, definition, host) : AddCommand(workItem, definition, host)).AddInvoker(group, "GroupClick");
                        }
                        else
                        {
                            this.CreateGroupTree(workItem, definition);
                        }
                    }
                }
                else
                {
                    Microsoft.Practices.CompositeUI.Commands.Command command3 = (workItem is LocalCommandWorkItem) ? AddShortcutCommand((LocalCommandWorkItem)workItem, definition, host) : AddCommand(workItem, definition, host);
                    if (!definition.Parent.HasFolderChild)
                    {
                        UltraExplorerBarItem item = new UltraExplorerBarItem
                        {
                            Text = definition.Text,
                            Tag = definition
                        };
                        workItem.UIExtensionSites[definition.Site].Add<UltraExplorerBarItem>(item);
                        item.Settings.AppearancesSmall.Appearance.Image = this.GetImage(definition);
                        command3.AddInvoker(item, "ItemClick");
                    }
                    else
                    {
                        UltraTreeNode node2 = this.CreateTreeNode(workItem, definition);
                        workItem.UIExtensionSites[definition.Site].Add<UltraTreeNode>(node2);
                        command3.AddInvoker(node2, "Click");
                    }
                }
            }
            foreach (UICommandDefinition definition2 in menuEntryEnumerable)
            {
                Microsoft.Practices.CompositeUI.Commands.Command command4 = workItem.Commands[definition2.Name];
                if (!string.IsNullOrEmpty(definition2.PermissionName))
                {
                    if (workItem.Services.Get<IAuthorizationService>().Authorize(Thread.CurrentPrincipal, definition2.PermissionName))
                    {
                        command4.Status = CommandStatus.Enabled;
                    }
                    else
                    {
                        command4.Status = CommandStatus.Unavailable;
                    }
                }
                else
                {
                    command4.Status = CommandStatus.Enabled;
                }
            }
        }

        private static Microsoft.Practices.CompositeUI.Commands.Command AddShortcutCommand(LocalCommandWorkItem workItem, UICommandDefinition entry, Control host)
        {
            ShortcutCommand command;
            if (!workItem.ShortcutCommands.Contains(entry.Name))
            {
                command = new ShortcutCommand(entry.ShortcutKeys, host);
                workItem.ShortcutCommands.Add(command, entry.Name);
                return command;
            }
            command = workItem.ShortcutCommands[entry.Name];
            command.ShortcutKeys = entry.ShortcutKeys;
            command.Host = host;
            return command;
        }

        private void CreateGroupTree(WorkItem workItem, UICommandDefinition entry)
        {
            UltraExplorerBarGroup uiElement = new UltraExplorerBarGroup {
                Text = entry.Text
            };
            uiElement.Settings.Style = GroupStyle.ControlContainer;
            workItem.UIExtensionSites[entry.Site].Add<UltraExplorerBarGroup>(uiElement);
            UltraTree tree = new UltraTree {
                Dock = DockStyle.Fill,
                ImageList = uiElement.ExplorerBar.ImageListSmall
            };
            uiElement.Container.Controls.Add(tree);
            workItem.UIExtensionSites.RegisterSite(entry.Site + "." + entry.Name, tree.Nodes);
        }

        private UltraTreeNode CreateTreeNode(WorkItem workItem, UICommandDefinition menuEntry)
        {
            UltraTreeNode node = new UltraTreeNode(menuEntry.Name) {
                Text = menuEntry.Text
            };
            node.Override.NodeAppearance.Cursor = Cursors.Hand;
            if (menuEntry.IsFolder)
            {
                node.Override.ExpandedNodeAppearance.Image = 7;
                node.Override.NodeAppearance.Image = 14;
                return node;
            }
            if (this.GetImage(menuEntry) != null)
            {
                node.LeftImages.Add(this.GetImage(menuEntry));
            }
            return node;
        }

        private object GetImage(UICommandDefinition entry)
        {
            if (entry.ImageListIndex.HasValue)
            {
                return entry.ImageListIndex.Value;
            }
            if (entry.Image != null)
            {
                return WinFormUtil.GetBitmap(entry.Image);
            }
            return null;
        }
    }
}

