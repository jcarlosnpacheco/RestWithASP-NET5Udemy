using RestWithASP_NET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5Udemy.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(int nId);
        Person FindById(int nId);
        List<Person> FindAll();

    }
}
