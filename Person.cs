using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePersonService
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Guid Id { get; set; }
    }
}
