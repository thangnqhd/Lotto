// Decompiled with JetBrains decompiler
// Type: Tulpep.NotificationWindow.Properties.Resources
// Assembly: Tulpep.NotificationWindow, Version=1.1.23.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F7EA38A-495D-44BC-8CE0-9C79F35F4AD3
// Assembly location: C:\Program Files (x86)\SINH TAI SINH LOC\Tulpep.NotificationWindow.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Tulpep.NotificationWindow.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Tulpep.NotificationWindow.Properties.Resources.resourceMan, (object) null))
          Tulpep.NotificationWindow.Properties.Resources.resourceMan = new ResourceManager("Tulpep.NotificationWindow.Properties.Resources", typeof (Tulpep.NotificationWindow.Properties.Resources).Assembly);
        return Tulpep.NotificationWindow.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Tulpep.NotificationWindow.Properties.Resources.resourceCulture;
      }
      set
      {
        Tulpep.NotificationWindow.Properties.Resources.resourceCulture = value;
      }
    }

    internal static Bitmap Grip
    {
      get
      {
        return (Bitmap) Tulpep.NotificationWindow.Properties.Resources.ResourceManager.GetObject(nameof (Grip), Tulpep.NotificationWindow.Properties.Resources.resourceCulture);
      }
    }
  }
}
