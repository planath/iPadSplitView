using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using iPadSplitView.Core.Message;
using iPadSplitView.Core.Model;
using iPadSplitView.Core.Repository;

namespace iPadSplitView.Core.ViewModel
{
    public class DetailViewModel : ViewModelBase
    {
        private int _indexWas;
        private Person _person;

        /// <summary>
        /// Initializes a new instance of the DetailViewModel class.
        /// </summary>
        public DetailViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Messenger.Default.Register<PrepareDetailViewMessage>(this, (msg) =>
            {
                IndexWas = msg.SelectedIndexWas;
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

        public int IndexWas { get { return _indexWas; }
            set
            {
                _indexWas = value;
                Person = PeopleRepository.GetPerson(_indexWas + 1);
            }
        }

        public void Init()
        {
            if (_indexWas != 0)
            {
                Person = PeopleRepository.GetPerson(_indexWas);
            }
            Person = PeopleRepository.GetPerson(1);
        }
    }
}
