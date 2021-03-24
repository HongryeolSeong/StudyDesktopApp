using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
    public class PersonList : ObservableCollection<Person> // List<Person> 해도 됨
    {
        public PersonList()
        {
            this.Add(new Person("willa", "Cather"));
            this.Add(new Person("Isak", "Dinesen"));
            this.Add(new Person("Victor", "Hugo"));
        }
    }
}
