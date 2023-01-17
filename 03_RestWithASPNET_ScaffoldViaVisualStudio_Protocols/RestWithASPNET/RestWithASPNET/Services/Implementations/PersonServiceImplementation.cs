using RestWithASPNET.Models;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public Person FindById(long id)
        {
            return new Person { 
                Id = IncrementAndGet(),
                FirstName = "First Name",
                LastName = "Last Name",
                Address = "Frankfurt",
                Gender = "Male"
            };
        }

        public List<Person> GetAll()
        {
            List<Person> Persons = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                Persons.Add(person);
            }

            return Persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "First Name"+ i,
                LastName = "Last Name"+ i,
                Address = "Frankfurt" + i,
                Gender = "Male" + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
