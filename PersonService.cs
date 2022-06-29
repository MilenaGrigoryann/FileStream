using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePersonService
{
    public class PersonService
    {

        private readonly string path = @"People";
        public PersonService()
        {
            path = Path.Combine(path, ".txt");
        }
        public void Create(Person person)
        {

            using (FileStream fstream = new FileStream(path, FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(person.Id.ToString()
                    + "\n" + person.Age.ToString()
                    + "\n" + person.LastName
                    + "\n" + person.FirstName + "\n");
                fstream.Write(buffer, 0, buffer.Length);
            }
        }
        public List<Person> ConvertToPerson(string[] persons)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < persons.Length; i = i + 4)
            {
                people.Add(new Person()
                {
                    Id = Guid.Parse(persons[i]),
                    Age = Convert.ToInt16(persons[i + 1]),
                    LastName = persons[i + 2],
                    FirstName = persons[i + 3]
                });
            }
            return people;
        }
        public string[] Read()
        {
            string[] persons;
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string text = Encoding.Default.GetString(buffer);
                persons = text.Split('\n');
            }
            return persons;
        }
        public void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Id},{person.Age},{person.FirstName},{person.LastName}");
            }
        }
    }
}
