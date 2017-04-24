using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

internal class ImageResources
{
    private static CultureInfo resourceCulture;
    private static System.Resources.ResourceManager resourceMan;

    internal ImageResources()
    {
    }

    internal static Icon BANKEImageBig
    {
        get
        {
            return (Icon) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("BANKEImageBig", resourceCulture));
        }
    }

    internal static Icon BANKEImageMedium
    {
        get
        {
            return (Icon) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("BANKEImageMedium", resourceCulture));
        }
    }

    internal static Icon BANKEImageSmall
    {
        get
        {
            return (Icon) RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("BANKEImageSmall", resourceCulture));
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

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static System.Resources.ResourceManager ResourceManager
    {
        get
        {
            if (object.ReferenceEquals(resourceMan, null))
            {
                System.Resources.ResourceManager manager2 = new System.Resources.ResourceManager("ImageResources", typeof(ImageResources).Assembly);
                resourceMan = manager2;
            }
            return resourceMan;
        }
    }
}

