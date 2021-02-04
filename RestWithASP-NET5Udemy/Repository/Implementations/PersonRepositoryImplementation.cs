using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Repository.Implementations
{
    /// <summary>
    /// Esta classe é responsável apenas pela persistência dos dados em Banco.
    /// </summary>
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private SQLServerContext _context;

        //iremos usar a variável context para se conectar no BD
        public PersonRepositoryImplementation(SQLServerContext context)
        {
            _context = context;
        }

        //busca todos os registros linkados com a variável context
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }


        //o ID está vindo zerado sempre..
        public Person FindById(int nId)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == nId);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        //não está funcionando corretamente
        public Person Update(Person person)
        {
            //se não existe, cria-se o novo Person
            if (!Exists(person.Id)) return new Person();

            var lRegistroEncontrado = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (lRegistroEncontrado != null)
            {
                try
                {
                    //_context.Persons.Update(person); estava dando erro de update The instance of entity type 'Item' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked 
                    //_context.SaveChanges();
                                       
                    _context.Entry(lRegistroEncontrado).CurrentValues.SetValues(person);
                    _context.SaveChanges();                                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return person;
        }

        public void Delete(int nId)
        {
           var lResult = _context.Persons.SingleOrDefault(p => p.Id.Equals(nId));

           if (lResult != null)
            {
                _context.Persons.Remove(lResult);
                _context.SaveChanges();
            }
        }

        public bool Exists(int nId)
        {
            return _context.Persons.Any(p => p.Id.Equals(nId));
        }

    }
}
