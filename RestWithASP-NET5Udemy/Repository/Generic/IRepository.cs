using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASP_NET5Udemy.Repository

{
    /// <summary>
    /// Nesta interface, temos um modelo genérico de entidade, ao invés de ser Person, será T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T item);
        T Update(T item);
        void Delete(int nId);
        T FindById(int nId);
        List<T> FindAll();
        public bool Exists(int nId);

    }
}
