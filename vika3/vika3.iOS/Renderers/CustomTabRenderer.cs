using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using vika3.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(TabbedPage),typeof(CustomTabRenderer))]
namespace vika3.iOS.Renderers
{
    class CustomTabRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            var tabs = Element as TabbedPage;
            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                {
                    UpdateItem(TabBar.Items[i]);
                }
            }
        }

        private void UpdateItem(UITabBarItem item)
        {
            if (item == null)
            {
                return;
            }
            item = new UITabBarItem(UITabBarSystemItem.Search,0);
        }
        
    }
}
