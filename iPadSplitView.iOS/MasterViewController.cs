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
        private MainViewModel Vm => Application.Locator.Main;
        public MasterViewController(IntPtr handle) : base(handle)
        {
            PreferredContentSize = new CGSize(320f, 600f);
            ClearsSelectionOnViewWillAppear = false;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Vm.Init();

            var source = Vm.PeopleCollection.GetTableViewSource(
                 CreateTaskCell,
                 BindTaskCell,
                 factory: () => new ServerMainListObservableTableSource());

            TableView.Source = source;
        }


        #region Cell binding and creation helper functions
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
        #endregion

    }
}


