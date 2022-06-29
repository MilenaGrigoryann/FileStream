using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePersonService
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonService personService = new PersonService();
            List<Person> people = new List<Person>();
            personService.Create(new Person { Age = 40, LastName = "Deph", FirstName = "Jonny" });
            personService.Create(new Person { Age = 18, LastName = "Heard", FirstName = "Amber" });
            personService.Create(new Person { Age = 20, LastName = "Holand", FirstName = "Tom" });
            personService.Create(new Person { Age = 18, LastName = "Prin", FirstName = "Mark" });
            people = personService.ConvertToPerson(personService.Read());
            personService.Print(people);
        }
    }
}
