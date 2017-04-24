namespace Deklarit.Practices.CompositeUI.NetAdvantage.UIElements
{
    using Infragistics.Win.UltraWinTree;
    using Microsoft.Practices.CompositeUI.UIElements;
    using Microsoft.Practices.CompositeUI.Utility;
    using System;

    public class TreeNodesCollectionUIAdapter : UIElementAdapter<UltraTreeNode>
    {
        private TreeNodesCollection m_TreeNodesCollection;

        public TreeNodesCollectionUIAdapter(TreeNodesCollection treeNodesCollection)
        {
            Guard.ArgumentNotNull(treeNodesCollection, "treeNodesCollection");
            this.m_TreeNodesCollection = treeNodesCollection;
        }

        protected override UltraTreeNode Add(UltraTreeNode uiElement)
        {
            this.m_TreeNodesCollection.Add(uiElement);
            return uiElement;
        }

        protected override void Remove(UltraTreeNode uiElement)
        {
            this.m_TreeNodesCollection.Remove(uiElement);
        }

        protected TreeNodesCollection Groups
        {
            get
            {
                return this.m_TreeNodesCollection;
            }
        }
    }
}

