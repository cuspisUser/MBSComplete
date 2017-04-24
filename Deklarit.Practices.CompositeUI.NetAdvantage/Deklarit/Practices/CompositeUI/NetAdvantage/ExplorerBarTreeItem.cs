namespace Deklarit.Practices.CompositeUI.NetAdvantage
{
    using System;

    public class ExplorerBarTreeItem
    {
        public object Control;
        public ExplorerBarTreeItemCollection ExplorerBarTreeTtemCollection;
        public bool IsTreeGroup;
        public ExplorerBarTreeItem Parent;
        public string Text;

        public ExplorerBarTreeItem(object control)
        {
            this.ExplorerBarTreeTtemCollection = new ExplorerBarTreeItemCollection(control);
            this.Control = control;
        }
    }
}

