using RestWithASP_NET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int nCountIni;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(int nId)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> lPeople = new List<Person>();
            
            for (int nIdx = 1; nIdx < 8; nIdx ++)
            {
                Person lPerson = MockupPerson(nIdx);
                lPeople.Add(lPerson);
            }
            return lPeople;
        }


        public Person FindById(int nId)
        {
            return new Person
            {
                Id = GetNewId(),
                FirstName = "João",
                LastName = "Pacheco",
                Adress = "Alameda dos testes, 151",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }


        private Person MockupPerson(int nIdx)
        {
            return new Person
            {

                Id = GetNewId(),
                FirstName = "João_"+nIdx.ToString(),
                LastName = "Pacheco_" + nIdx.ToString(),
                Adress = "Alameda dos testes, 151_" + nIdx.ToString(),
                Gender = "Male"
            };
        }

        private long GetNewId()
        {
            return Interlocked.Increment(ref nCountIni);
        }
    }
}
