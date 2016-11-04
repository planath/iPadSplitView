using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using iPadSplitView.Core.ViewModel;
using UIKit;

namespace iPadSplitView.iOS
{
    public partial class DetailViewController : UIViewController
    {
        public object DetailItem { get; set; }

        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public void SetDetailItem(object newDetailItem)
        {
            if (DetailItem != newDetailItem)
            {
                DetailItem = newDetailItem;

                // Update the view
                ConfigureView();
            }
        }

        void ConfigureView()
        {
            Vm.Init();
            // set bindings
            bindings.Add(this.SetBinding(
                () => Vm.Person.FirstName,
                () => FirstNameTextView.Text));

            bindings.Add(this.SetBinding(
                () => Vm.Person.LastName,
                () => LastNameTextView.Text));

            bindings.Add(this.SetBinding(
                () => Vm.Person.Email,
                () => EmailTextView.Text));

            // Update the user interface for the detail item
            if (IsViewLoaded && DetailItem != null)
                detailDescriptionLabel.Text = DetailItem.ToString();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            ConfigureView();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private readonly List<Binding<string,string>> bindings = new List<Binding<string, string>>();
        private DetailViewModel Vm => Application.Locator.Detail;
    }
}


