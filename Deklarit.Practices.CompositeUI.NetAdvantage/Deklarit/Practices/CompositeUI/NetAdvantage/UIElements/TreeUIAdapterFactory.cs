namespace Deklarit.Practices.CompositeUI.NetAdvantage.UIElements
{
    using Infragistics.Win.UltraWinTree;
    using Microsoft.Practices.CompositeUI.UIElements;
    using Microsoft.Practices.CompositeUI.Utility;
    using System;

    public class TreeUIAdapterFactory : IUIElementAdapterFactory
    {
        public IUIElementAdapter GetAdapter(object uiElement)
        {
            Guard.ArgumentNotNull(uiElement, "uiElement");
            if (!(uiElement is TreeNodesCollection))
            {
                throw new ArgumentException("Invalid argument : " + uiElement.GetType());
            }
            return new TreeNodesCollectionUIAdapter((TreeNodesCollection) uiElement);
        }

        public bool Supports(object uiElement)
        {
            return ((uiElement is TreeNodesCollection) || (uiElement is UltraTreeNode));
        }
    }
}

