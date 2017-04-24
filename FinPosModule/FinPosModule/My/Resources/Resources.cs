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

namespace My.Resources
{

    public class Resources
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        public static Bitmap brisi
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("brisi", resourceCulture));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static CultureInfo Culture
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

        public static Bitmap deoznaci
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("deoznaci", resourceCulture));
            }
        }

        public static Bitmap dodaj
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("dodaj", resourceCulture));
            }
        }

        public static Bitmap izmjeni
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("izmjeni", resourceCulture));
            }
        }

        public static Bitmap oznaci
        {
            get
            {
                return (Bitmap) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("oznaci", resourceCulture));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager2 = new System.Resources.ResourceManager("FinPosModule.Resources", typeof(My.Resources.Resources).Assembly);
                    resourceMan = manager2;
                }
                return resourceMan;
            }
        }
    }
}

