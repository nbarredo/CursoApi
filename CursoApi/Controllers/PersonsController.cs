using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CursoApi.Controllers
{
    public class PersonsController : ApiController
    {
        // GET: api/Persons
        public IEnumerable<Person> Get()
        {
            var persons = new List<Person>();
            using(var context=new MyDbContext())
            {
                persons = context.People.ToList();
            }
           
            return persons;
        }

        // GET: api/Persons/5
        public Person Get(int id)
        {
            var person = new Person();
            using (var context = new MyDbContext())
            {
                person = context.People.Find(id);
            }

            return person;
        }

        // POST: api/Persons
        public void Post([FromBody]Person value)
        {
            using (var context = new MyDbContext())
            {
                 context.People.Add(value);
                context.SaveChanges();
            }
        }

        // PUT: api/Persons/5
        public void Put(int id, [FromBody]Person value)
        {
            using (var context = new MyDbContext())
            {
                var person = context.People.Find(id); 
                context.Entry(person).CurrentValues.SetValues(value);
                context.SaveChanges();
            }
        }

        // DELETE: api/Persons/5
        public void Delete(int id)
        {
            using (var context = new MyDbContext())
            {
                var person = new Person { Id = id };
                context.People.Attach(person);
                context.People.Remove(person);
                context.SaveChanges();

            }
        }
    }
}
