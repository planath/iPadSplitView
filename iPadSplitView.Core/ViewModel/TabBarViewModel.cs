using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using iPadSplitView.Core.Message;
using iPadSplitView.iOS;

namespace iPadSplitView.Core.ViewModel
{
    public class TabBarViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;
        private string[] _tabTitles = new[] { "Aktuell", "History", "Einstellungen" };
        private int?[] _tabsIndex = new int?[] { null, null, null };
        private int _currentTab = 0;
        public TabBarViewModel(INavigationService nav)
        {
            _nav = nav;

            Messenger.Default.Register<TabBarChangeMessage>(this, (msg) =>
            {
                CurrentTabIndex = msg.SelectedTabIs;
            });

            // remember last clicked row from each table in tab
            Messenger.Default.Register<PrepareDetailViewMessage>(this, (msg) =>
            {
                TabsIndex[CurrentTabIndex] = msg.SelectedIndexWas;
            });
        }

        public string[] TabTitles
        {
            get { return _tabTitles; }
            set { _tabTitles = value; }
        }

        public int?[] TabsIndex
        {
            get { return _tabsIndex; }
            set { _tabsIndex = value; }
        }
        public int CurrentTabIndex
        {
            get { return _currentTab; }
            set
            {
                var oldValue = _currentTab;
                _currentTab = value;
                if (_currentTab == 2)
                {
                    _nav.NavigateTo("Settings");
                }
                else if (oldValue == 2)
                {
                    _nav.GoBack();
                }
                else
                {
                    var msg = new ShowLasSelectedPersonMessage() { SelectedRowWas = TabsIndex[value] };
                    Messenger.Default.Send<ShowLasSelectedPersonMessage>(msg);
                }
            }
        }

        public void Init()
        {
        }
    }
}