namespace Deklarit.Practices.CompositeUI.NetAdvantage.MenuEntryAdapters
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.Commands;
    using Deklarit.Practices.CompositeUI.WorkItems;
    using Infragistics.Win.UltraWinToolbars;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.Commands;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    internal static class NetAdvantageUIElementFactory
    {
        private static Microsoft.Practices.CompositeUI.Commands.Command AddCommand(WorkItem workItem, Control host, UICommandDefinition entry)
        {
            Microsoft.Practices.CompositeUI.Commands.Command command;
            if (!workItem.Commands.Contains(entry.Name))
            {
                command = new ShortcutCommand(entry.ShortcutKeys, host);
                workItem.Commands.Add(command, entry.Name);
                return command;
            }
            command = workItem.Commands[entry.Name];
            if (command is ShortcutCommand)
            {
                ShortcutCommand command2 = (ShortcutCommand) command;
                if (!command2.ShortcutKeys.HasValue && (command2.Host == null))
                {
                    command2.Host = host;
                    command2.ShortcutKeys = entry.ShortcutKeys;
                    return command;
                }
                if (command2.Host != host)
                {
                    command = new ShortcutCommand(entry.ShortcutKeys, host);
                    workItem.Commands.Add(command, entry.Name);
                }
            }
            return command;
        }

        private static Microsoft.Practices.CompositeUI.Commands.Command AddShortcutCommand(LocalCommandWorkItem workItem, Control host, UICommandDefinition entry)
        {
            ShortcutCommand command;
            if (!workItem.ShortcutCommands.Contains(entry.Name))
            {
                command = new ShortcutCommand(entry.ShortcutKeys, host);
                workItem.ShortcutCommands.Add(command, entry.Name);
                return command;
            }
            command = workItem.ShortcutCommands[entry.Name];
            command.Host = host;
            command.ShortcutKeys = entry.ShortcutKeys;
            return command;
        }

        public static void AddToolStripElements(WorkItem workItem, IEnumerable<UICommandDefinition> menuEntryEnumerable, UICommandPlacement toolStripMode, Control host)
        {
            foreach (UICommandDefinition definition in menuEntryEnumerable)
            {
                if ((toolStripMode != UICommandPlacement.VerticalToolPanel) && !definition.IsCategory)
                {
                    ToolBase toolStripItem = GetToolStripItem(toolStripMode, definition);
                    toolStripItem.Tag = definition;
                    toolStripItem.Key = definition.ContextName + definition.Name;
                    if ((definition.Parent != null) && definition.Parent.IsCategory)
                    {
                        toolStripItem = workItem.UIExtensionSites[definition.Parent.Site].Add<ToolBase>(toolStripItem);
                    }
                    else
                    {
                        toolStripItem = workItem.UIExtensionSites[definition.Site].Add<ToolBase>(toolStripItem);
                    }
                    if (definition.IsFolder || definition.IsCategory)
                    {
                        if (toolStripItem is PopupMenuTool)
                        {
                            workItem.UIExtensionSites.RegisterSite(definition.Site + "." + definition.Name, ((PopupMenuTool) toolStripItem).Tools);
                        }
                        else
                        {
                            workItem.UIExtensionSites.RegisterSite(definition.Site + "." + definition.Name, toolStripItem);
                        }
                    }
                    if (!definition.IsFolder && !definition.IsCategory)
                    {
                        ((workItem is LocalCommandWorkItem) ? AddShortcutCommand((LocalCommandWorkItem) workItem, host, definition) : AddCommand(workItem, host, definition)).AddInvoker(toolStripItem, "ToolClick");
                    }
                }
            }
        }

        public static ToolBase CreateButton(UICommandDefinition menuEntry)
        {
            ButtonTool toolBase = new ButtonTool(menuEntry.Name);
            SetStandardProperties(menuEntry, toolBase);
            return toolBase;
        }

        public static ToolBase CreateMenuItem(UICommandDefinition menuEntry, bool isMenu)
        {
            PopupMenuTool toolBase = new PopupMenuTool(menuEntry.Name);
            if (isMenu)
            {
                toolBase.DropDownArrowStyle = DropDownArrowStyle.None;
            }
            SetStandardProperties(menuEntry, toolBase);
            return toolBase;
        }

        private static ToolBase GetToolStripItem(UICommandPlacement toolStripMode, UICommandDefinition entry)
        {
            if (entry.IsCategoryOrFolder)
            {
                return CreateMenuItem(entry, toolStripMode == UICommandPlacement.Menu);
            }
            return CreateButton(entry);
        }

        private static void SetStandardProperties(UICommandDefinition menuEntry, ToolBase toolBase)
        {
            toolBase.SharedProps.Caption = menuEntry.Text;
            toolBase.SharedProps.DisplayStyle = ToolDisplayStyle.ImageAndText;
            if (menuEntry.ImageListIndex.HasValue)
            {
                toolBase.SharedProps.AppearancesSmall.Appearance.Image = menuEntry.ImageListIndex.Value;
            }
            else if (menuEntry.Image != null)
            {
                toolBase.SharedProps.AppearancesSmall.Appearance.Image = WinFormUtil.GetBitmap(menuEntry.Image);
            }
            if (menuEntry.ShortcutKeys.HasValue)
            {
                toolBase.SharedProps.Shortcut = (System.Windows.Forms.Shortcut)menuEntry.ShortcutKeys.Value;
            }
        }
    }
}

