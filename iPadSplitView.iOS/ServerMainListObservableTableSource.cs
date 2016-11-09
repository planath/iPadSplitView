using Foundation;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using iPadSplitView.Core.Message;
using iPadSplitView.Core.Model;
using iPadSplitView.Core.ViewModel;
using UIKit;

namespace iPadSplitView.iOS
{
    public class ServerMainListObservableTableSource : ObservableTableViewSource<Person>
    {
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);
            var msg = new PrepareDetailViewMessage() { SelectedIndexWas = indexPath.Row};
            Messenger.Default.Send<PrepareDetailViewMessage>(msg);
        }
    }
}
