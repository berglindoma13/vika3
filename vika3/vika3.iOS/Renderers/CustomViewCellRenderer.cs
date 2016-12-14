using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using vika3.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace vika3.iOS.Renderers
{
    class CustomViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }
    }
}

