using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using GalaSoft.MvvmLight.Helpers;
using iPadSplitView.Core.Model;
using iPadSplitView.Core.ViewModel;
using iPadSplitView.iOS.Helper;

namespace iPadSplitView.iOS
{
    public partial class MasterViewController : UITableViewController
    {
        public ServerDetailTableViewController DetailViewController { get; set; }
        
        public MasterViewController(IntPtr handle) : base(handle)
        {
            PreferredContentSize = new CGSize(320f, 600f);
            ClearsSelectionOnViewWillAppear = false;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Vm.Init();

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add/*, AddNewItem*/);
            addButton.AccessibilityLabel = "addButton";
            NavigationItem.RightBarButtonItem = addButton;

            DetailViewController = (ServerDetailTableViewController)((UINavigationController)SplitViewController.ViewControllers[1]).TopViewController;
            
            var source = Vm.PeopleCollection.GetTableViewSource(
                 CreateTaskCell,
                 BindTaskCell,
                 factory: () => new ServerMainListObservableTableSource());

            TableView.Source = source;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        
        private void BindTaskCell(UITableViewCell cell, Person person, NSIndexPath path)
        {
            cell.TextLabel.Text = person.FirstName + " " + person.LastName;
            cell.DetailTextLabel.Text = person.Email;
            cell.BackgroundColor = person.Color.GetUIColor();
        }

        private UITableViewCell CreateTaskCell(NSString cellIdentifier)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            cell.TextLabel.TextColor = UIColor.FromRGB(55, 63, 255);
            cell.DetailTextLabel.LineBreakMode = UILineBreakMode.TailTruncation;

            return cell;
        }

        private MainViewModel Vm => Application.Locator.Main;
    }
}


