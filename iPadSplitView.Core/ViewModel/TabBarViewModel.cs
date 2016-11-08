using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using iPadSplitView.Core.Message;
using iPadSplitView.Core.Model;
using iPadSplitView.iOS;

namespace iPadSplitView.Core.ViewModel
{
    public class TabBarViewModel : ViewModelBase
    {
        private string[] _tabTitles = new[] { "Aktuell", "History", "Einstellungen" };
        private int?[] _tabsIndex;
        private int _currentTab = 0;
        public TabBarViewModel()
        {
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
                _currentTab = value;
                var msg = new ShowLasSelectedPersonMessage() {SelectedRowWas = TabsIndex[value]};
                Messenger.Default.Send<ShowLasSelectedPersonMessage>(msg);
            }
        }

        public void Init()
        {
        }
    }
}