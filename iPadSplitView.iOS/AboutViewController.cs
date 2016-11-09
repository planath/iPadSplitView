using Foundation;
using System;
using CoreGraphics;
using UIKit;

namespace iPadSplitView.iOS
{
    public partial class AboutViewController : UITableViewController
    {
        public AboutViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.SetHidesBackButton(true, false);
            NavigationController.NavigationBar.BackgroundColor = UIColor.White;

            VersionDesc.AttributedText = new NSAttributedString("Copyright 2011-2016 - Siemens Schweiz AG");
        }
    }
}