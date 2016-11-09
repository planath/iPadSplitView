using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using iPadSplitView.Core.Message;
using iPadSplitView.Core.ViewModel;
using UIKit;

namespace iPadSplitView.iOS
{
    public partial class TabBarController : UITabBarController
    {
        private Binding<int, int> _indexBinding;
        private int _currentTabIndex;
        private TabBarViewModel Vm => Application.Locator.TabBar;

        public int CurrentTabIndex
        {
            get { return _currentTabIndex; }
            set
            {
                var msg = new TabBarChangeMessage() { SelectedTabIs = value };
                Messenger.Default.Send<TabBarChangeMessage>(msg);
                _currentTabIndex = value;
            }
        }

        public TabBarController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Vm.Init();

            // binding
            //_indexBinding = this.SetBinding(() => Vm.CurrentTabIndex, () => CurrentTabIndex, BindingMode.TwoWay);

            // Todo: better way of binding
            TabBar.TintColor = UIColor.Black;
            TabBar.Items[0].Title = Vm.TabTitles[0];
            TabBar.Items[1].Title = Vm.TabTitles[1];
            TabBar.Items[2].Title = Vm.TabTitles[2];
        }

        public override void ItemSelected(UITabBar tabbar, UITabBarItem item)
        {
            CurrentTabIndex = Array.IndexOf(TabBar.Items, item);
        }
    }
}