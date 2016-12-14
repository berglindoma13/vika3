using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using vika3.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace XFHelloWorld.Droid.Renderers
{
    using Xamarin.Forms.Platform.Android;

    using Resource = vika3.Droid.Resource;

    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                var nativeEditText = (EditText)this.Control;
                nativeEditText.SetBackgroundResource(Resource.Layout.Box);
            }
        }
    }
}