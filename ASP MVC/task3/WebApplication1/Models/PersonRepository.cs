using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PersonRepository
    {
        private List<Person> people = new List<Person>();

        public int NumberOfPeople => people.Count();
        public IEnumerable<Person> GetPeople => people;

        public void AddResponse(Person p)
        {
            people.Add(p);
        }
    }
}