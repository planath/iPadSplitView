using System;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using iPadSplitView.Core.Message;
using iPadSplitView.Core.Model;
using iPadSplitView.Core.ViewModel;
using UIKit;

namespace iPadSplitView.iOS
{
    public class CustomListObservableTableSource : ObservableTableViewSource<Person>
    {
        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source
                    DataSource.RemoveAt(indexPath.Row);
                    // No need to delete the row from the table as the tableview is bound to the data source
                    break;
            }
        }

        public override UITableViewCellEditingStyle EditingStyleForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableViewCellEditingStyle.Delete;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);
            
            Console.WriteLine($"clicked on item at index {indexPath.Row}");
            var msg = new PrepareDetailViewMessage() { SelectedIndexWas = indexPath.Row };
            Messenger.Default.Send<PrepareDetailViewMessage>(msg);
        }
        private MainViewModel Vm => Application.Locator.Main;


        // Handy functions from TEMPLATE
        /*            
            // For TableViewController
            void AddNewItem(object sender, EventArgs args)
            {
                dataSource.Objects.Insert(0, DateTime.Now);

                using (var indexPath = NSIndexPath.FromRowSection(0, 0))
                    TableView.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);
            }
                
            public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
            {
                if (segue.Identifier == "showDetail")
                {
                    var indexPath = TableView.IndexPathForSelectedRow;
                    var item = dataSource.Objects[indexPath.Row];
                    var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
                    controller.SetDetailItem(item);
                    controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
                    controller.NavigationItem.LeftItemsSupplementBackButton = true;
                }
            }

        ///////////////////////////////////////////////////////////////////////////////////////////

            // For TableViewDataSource
            static readonly NSString CellIdentifier = new NSString("Cell");
            readonly List<object> objects = new List<object>();
            readonly MasterViewController controller;

            public DataSource(MasterViewController controller)
            {
                this.controller = controller;
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                // Return false if you do not want the specified item to be editable.
                return true;
            }

            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
            {
                if (editingStyle == UITableViewCellEditingStyle.Delete)
                {
                    // Delete the row from the data source.
                    objects.RemoveAt(indexPath.Row);
                    controller.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
                }
                else if (editingStyle == UITableViewCellEditingStyle.Insert)
                {
                    // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
                }
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    controller.DetailViewController.SetDetailItem(objects[indexPath.Row]);
            }
        */
    }
}
