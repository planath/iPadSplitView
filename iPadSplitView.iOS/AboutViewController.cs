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

            VersionDesc.AttributedText = new NSAttributedString("Copyright 2011-2016\\nSiemens Schweiz AG");
            
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 40f;
            TableView.ReloadData();
        }

        public override nfloat EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableView.AutomaticDimension;
        }
    }
}