using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCombo
{
    class ComboViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _people;
        private Person _person;
        public static String _profileName;
        public static String _selectedName;


        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                if(_people != value)
                {
                    _people = value;
                    NotifyComboPropertyChanged("People");
                }
            }
        }
        public Person Person { get => _person;
            set
            {
                if (_person != value) { 
                    _person = value;
                }
            }
        }

        
        public string ProfileName { get => _profileName; set => _profileName = value; }
        public string SelectedName { get => _selectedName; set => _selectedName = value; }

        public ComboViewModel()
        {
            List<Person> pl = new List<Person>();
            pl.Add(new Person(1, "Emon"));
            pl.Add(new Person(2, "Shuvo"));
            pl.Add(new Person(3, "Mahmud"));
            pl.Add(new Person(4, "Arif"));

            People = new ObservableCollection<Person>(pl);
        }

        
        
        protected void NotifyComboPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
       
    }
}
