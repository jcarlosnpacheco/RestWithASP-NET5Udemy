using RestWithASP_NET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5Udemy.Business
{
    public interface IPersonBusiness

    {
        Person Create(Person person);
        Person Update(Person person);
        void Delete(int nId);
        Person FindById(int nId);
        List<Person> FindAll();

    }
}
