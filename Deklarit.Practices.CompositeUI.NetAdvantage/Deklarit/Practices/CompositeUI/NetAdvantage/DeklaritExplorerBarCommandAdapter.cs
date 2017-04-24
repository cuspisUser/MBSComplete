namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    using Infragistics.Practices.CompositeUI.WinForms.Commands;
    using Microsoft.Practices.CompositeUI.Commands;
    using System;

    public class DeklaritExplorerBarCommandAdapter : ExplorerBarCommandAdapter
    {
        protected override void OnCommandChanged(Command command)
        {
            base.OnCommandChanged(command);
        }

        protected override void OnInvokerStateChanged()
        {
            base.OnInvokerStateChanged();
        }
    }
}

