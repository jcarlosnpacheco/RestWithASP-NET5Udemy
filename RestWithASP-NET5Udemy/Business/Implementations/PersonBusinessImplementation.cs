using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Model.Context;
using RestWithASP_NET5Udemy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Business.Implementations
{
    /// <summary>
    /// Essa classe é responsável por trabalhar as regras e negócio do projeto
    /// </summary>
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;

        //iremos usar a variável context para se conectar no BD
        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        //busca todos os registros linkados com a variável context
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }
                
        public Person FindById(int nId)
        {
            return _repository.FindById(nId);
        }

        public Person Create(Person person)
        {
            //aqui faríamos as validações antes de dar o create!
           return _repository.Create(person);
        }
                
        public Person Update(Person person)
        {
            //aqui faríamos as validações antes de dar o update!
            return _repository.Update(person);
        }

        public void Delete(int nId)
        {
            //aqui faríamos as validações antes de dar o delete!
            _repository.Delete(nId);
        }
      
    }
}
