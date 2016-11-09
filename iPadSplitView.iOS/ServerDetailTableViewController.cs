using Foundation;
using System;
using CoreGraphics;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using iPadSplitView.Core.Model;
using iPadSplitView.Core.ViewModel;
using iPadSplitView.iOS.Helper;
using UIKit;

namespace iPadSplitView.iOS
{
    public partial class ServerDetailTableViewController : UITableViewController
    {
        private DetailViewModel Vm => Application.Locator.Detail;
        private DataSource _dataSource;
        private Binding<Person, Person> _personBinding;
        public ServerDetailTableViewController(IntPtr handle) : base(handle)
        {
            PreferredContentSize = new CGSize(320f, 600f);
            ClearsSelectionOnViewWillAppear = false;
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Vm.Init();
            //// If use with binding
            _personBinding = this.SetBinding(
                () => Vm.Person,
                () => ServerStatus);

            TableView.Source = _dataSource = new DataSource(this);

            //binding does not update there for get object from message
            Messenger.Default.Register<PropertyChangedMessage<Person>>(this, (msg) =>
            {
                ServerStatus = msg.NewValue;
                _dataSource.Objects = ServerStatus;
                TableView.ReloadData();
            });
        }

        public Person ServerStatus { get; set; }
        public UIBarButtonItem ConfirmButton { get; private set; }

        private void ConfirmButtonOnClicked(object sender, EventArgs eventArgs)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = ServerStatus.LastName,
                Message = "Status nicht ok"
            };
            alert.AddButton("Bestätigen mit Kommentar");
            alert.AddButton("Bestätigen");
            alert.AddButton("Neustart");
            alert.Show();
            alert.Clicked += AlertOnClicked;
        }

        private void AlertOnClicked(object sender, UIButtonEventArgs uiButtonEventArgs)
        {
            switch (uiButtonEventArgs.ButtonIndex)
            {
                case 0:
                    var alert = new UIAlertView();
                    alert.Title = "Kommentar festhalten";
                    alert.AddButton("Bestätigen");
                    alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
                    alert.AddButton("Abbrechen");
                    alert.Show();
                    break;
                case 1:
                case 2:
                    ServerStatus.Color = Color.Green;
                    NavigationController.NavigationBar.BackgroundColor = ServerStatus.Color.GetUIColor();
                    break;
            }

        }

        class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            readonly ServerDetailTableViewController controller;

            public DataSource(ServerDetailTableViewController controller)
            {
                this.controller = controller;
                Objects = controller.ServerStatus;
            }

            public Person Objects { get; set; }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                int returnVal = Objects != null ? 8 : 1;
                return returnVal;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return 1;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

                if (Objects != null)
                {
                    switch (indexPath.Section)
                    {
                        case 0:
                            cell.TextLabel.Text = Objects.LastName;
                            break;
                        case 1:
                            cell.TextLabel.Text = Objects.FirstName;
                            break;
                        case 2:
                            cell.TextLabel.Text = Objects.Email;
                            break;
                        case 3:
                            cell.TextLabel.Text = Objects.Id.ToString();
                            break;
                        case 4:
                            cell.TextLabel.Text = Objects.Color.ToString();
                            controller.NavigationController
                                .NavigationBar.BackgroundColor = Objects.Color.GetUIColor();
                            break;
                        case 5:
                            cell.TextLabel.Text = Objects.FirstName + " " + Objects.LastName;
                            break;
                        case 6:
                            cell.TextLabel.Text = Objects.GetHashCode().ToString();
                            break;
                        case 7:
                            cell.TextLabel.Text = Objects.LastName + " " + Objects.FirstName + " " + Objects.Color.ToString() + " " + Objects.Id.ToString();
                            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                            // TODO: here use custom table with text dialoge 
                            break;
                    }
                }
                else
                {
                    cell.TextLabel.Text = "Bitte wählen Sie einen Eintrag";
                }

                return cell;
            }

            public override string TitleForHeader(UITableView tableView, nint section)
            {
                if (Objects != null)
                {
                    switch (section)
                    {
                        case 0:
                            return NSBundle.MainBundle.LocalizedString("Regel", "Master");
                        case 1:
                            return NSBundle.MainBundle.LocalizedString("Meldung", "Master");
                        case 2:
                            return NSBundle.MainBundle.LocalizedString("IP/DNS", "Master");
                        case 3:
                            return NSBundle.MainBundle.LocalizedString("Alarmzeit", "Master");
                        case 4:
                            return NSBundle.MainBundle.LocalizedString("Status", "Master");
                        case 5:
                            return NSBundle.MainBundle.LocalizedString("Bestätigung", "Master");
                        case 6:
                            return NSBundle.MainBundle.LocalizedString("Benutzer", "Master");
                        case 7:
                            return NSBundle.MainBundle.LocalizedString("Bemerkung", "Master");
                    }
                }
                return "";
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                Console.WriteLine($"section {indexPath.Section}, row {indexPath.Row}");
            }
        }

    }
}