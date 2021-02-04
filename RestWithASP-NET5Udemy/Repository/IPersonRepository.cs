using RestWithASP_NET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5Udemy.Repository

{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(int nId);
        Person FindById(int nId);
        List<Person> FindAll();
        public bool Exists(int nId);

    }
}
