using System;
using System.Collections.Generic;

namespace _25._10.Interfaces
{
    public interface IRepository<T>
    {
        public void Add(T entity);
        public void Update(int id, T entity);
        public void Delete(int id);

        public T? Get(int id);
        public IEnumerable<T> GetAll();
        public T? Find(Predicate<T> predicate);
    }
}