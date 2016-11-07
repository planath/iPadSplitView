using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using iPadSplitView.Core.Model;
using iPadSplitView.Core.ViewModel;
using iPadSplitView.iOS.Helper;
using UIKit;

namespace iPadSplitView.iOS
{
    public partial class DetailViewController : UIViewController
    {
        public Person Person { get; set; }

        public DetailViewController(IntPtr handle) : base(handle)
        {
        }

        public void SetDetailItem()
        {
            FirstNameTextView.Text = Person.FirstName;
            LastNameTextView.Text = Person.LastName;
            EmailTextView.Text = Person.Email;
            NavigationController.NavigationBar.BarTintColor = Person.Color.GetUIColor();
        }

        void ConfigureView()
        {
            Vm.Init();
            
            // If use with binding
            _personBinding = this.SetBinding(
                () => Vm.Person,
                () => Person);

            Messenger.Default.Register<PropertyChangedMessage<Person>>(this, (msg) =>
            {
                SetDetailItem();
            });
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
        private Binding<Person, Person> _personBinding;
        private DetailViewModel Vm => Application.Locator.Detail;
    }
}


