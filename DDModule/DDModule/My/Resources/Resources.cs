namespace DDModule.My.Resources
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [StandardModule, HideModuleName, CompilerGenerated, DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    internal sealed class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal static Bitmap brisi
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("brisi", resourceCulture));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static Bitmap deoznaci
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("deoznaci", resourceCulture));
            }
        }

        internal static Bitmap dodaj
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("dodaj", resourceCulture));
            }
        }

        internal static Bitmap izmjeni
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("izmjeni", resourceCulture));
            }
        }

        internal static Bitmap oznaci
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("oznaci", resourceCulture));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager2 = new System.Resources.ResourceManager("DDModule.Resources", typeof(My.Resources.Resources).Assembly);
                    resourceMan = manager2;
                }
                return resourceMan;
            }
        }
    }
}

