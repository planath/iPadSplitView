using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iPadSplitView.Core.Model;

namespace iPadSplitView.Core.Repository
{
    public static class PeopleRepository
    {
        public static ObservableCollection<Person> GetAllPeople()
        {
            return new ObservableCollection<Person>(){
                new Person(1, "Andreas", "Plüss", "andi@qlu.ch"),
                new Person(2, "Rudolf", "Rentiel", "rudddi@qlu.ch"),
                new Person(3, "Michi", "Albrecht", "albani@qlu.ch"),
                new Person(4, "André", "Fuller", "purzel@qlu.ch"),
                new Person(5, "Gerome", "Acker", "cheri@qlu.ch")
            };
        }
        public static Person GetPerson(int id)
        {
            return GetAllPeople().FirstOrDefault(p => p.Id == id);
        }
    }
}
