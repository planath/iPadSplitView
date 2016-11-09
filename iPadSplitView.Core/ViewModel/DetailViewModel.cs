using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using iPadSplitView.Core.Message;
using iPadSplitView.Core.Model;
using iPadSplitView.Core.Repository;
using iPadSplitView.iOS;

namespace iPadSplitView.Core.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;
        private int? _indexIs;
        private Person _person;

        /// <summary>
        /// Initializes a new instance of the DetailViewModel class.
        /// </summary>
        public DetailViewModel(INavigationService nav)
        {
            _nav = nav;
            GoToSettings = new RelayCommand(ExecuteGoToSettings);
            Messenger.Default.Register<PrepareDetailViewMessage>(this, (msg) =>
            {
                IndexIs = msg.SelectedIndexWas;
            });
            Messenger.Default.Register<ShowLasSelectedPersonMessage>(this, (msg) =>
            {
                IndexIs = msg.SelectedRowWas;
            });
        }

        public Person Person
        {
            get { return _person; }
            set
            {
                var personBefore = _person;
                _person = value;
                RaisePropertyChanged("Person", personBefore, value, true);
            }
        }

        public int? IndexIs { get { return _indexIs; }
            set
            {
                _indexIs = value;
                if (_indexIs != null)
                {
                    Person = PeopleRepository.GetPerson(_indexIs.Value + 1);
                }
                else
                {
                    Person = null;
                }
            }
        }

        public RelayCommand GoToSettings { get; set; }

        public void Init()
        {
            if (_indexIs != null)
            {
                Person = PeopleRepository.GetPerson(_indexIs.Value);
            }
            else
            {
                Person = null;
            }
        }
        private void ExecuteGoToSettings()
        {
            _nav.NavigateTo("Settings");
        }
    }
}
