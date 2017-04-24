namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    using Infragistics.Practices.CompositeUI.WinForms.Commands;
    using Infragistics.Win.UltraWinToolbars;
    using Microsoft.Practices.CompositeUI.Commands;
    using System;

    public class DeklaritToolBaseCommandAdapter : ToolBaseCommandAdapter
    {
        protected override void OnCommandChanged(Command command)
        {
            base.OnCommandChanged(command);
            this.SetParentVisibility(base.Invoker);
        }

        protected override void OnInvokerStateChanged()
        {
            base.OnInvokerStateChanged();
            this.SetParentVisibility(base.Invoker);
        }

        private void SetParentVisibility(ToolBase item)
        {
            ToolbarsCollection.ToolbarEnumerator enumerator = item.ToolbarsManager.Toolbars.GetEnumerator();

            while (enumerator.MoveNext())
            {
                foreach (ToolBase base2 in enumerator.Current.Tools)
                {
                    if (!(base2 is PopupMenuTool))
                    {
                        continue;
                    }
                    bool flag = false;
                    ToolEnumerator enumerator3 = ((PopupMenuTool)base2).Tools.GetEnumerator();
                    while (enumerator3.MoveNext())
                    {
                        if (enumerator3.Current.SharedProps.Visible)
                        {
                            flag = true;
                            goto Label_008D;
                        }
                    }

                Label_008D:
                    if (!base2.IsRootTool)
                    {
                        base2.SharedProps.Visible = flag;
                    }
                }
            }
        }
    }
}

