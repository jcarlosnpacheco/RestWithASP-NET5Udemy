using Microsoft.EntityFrameworkCore;
using RestWithASP_NET5Udemy.Model.Base;
using RestWithASP_NET5Udemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5Udemy.Repository.Generic
{
    /// <summary>
    /// classe genérica pra receber entidades parecidas e trabalhar seus respectivos dados em banco
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private SQLServerContext _context;
        private DbSet<T> dataset;

        //iremos usar a variável context para se conectar no BD
        public GenericRepository(SQLServerContext context)
        {
            _context = context;

            //passamos o contexto para o dataset
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(int nId)
        {
            return dataset.SingleOrDefault(p => p.Id == nId);
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
                    

        public T Update(T item)
        {           
            var lRegistroEncontrado = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (lRegistroEncontrado != null)
            {
                try
                {
                    //dataset.Update(lRegistroEncontrado);
                    _context.Entry(lRegistroEncontrado).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }else
            {
                return null;
            }
        }

        public void Delete(int nId)
        {
            var lRegistroEncontrado = dataset.SingleOrDefault(p => p.Id.Equals(nId));

            if (lRegistroEncontrado != null)
            {
                try
                {
                    dataset.Remove(lRegistroEncontrado);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool Exists(int nId)
        {
            return dataset.Persons.Any(p => p.Id.Equals(nId));
        }
    }
}
