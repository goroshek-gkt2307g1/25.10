using _25._10.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._10.Interfaces
{
    public interface IRepository<T>
    {

        public void Add(Course course);
        public void Update(int id, Course course);
        public void Delete(int id);

        public T? Get(int id);
        public IEnumerable<T> GetAll();
        public T? Find(Predicate<T> predicate);



    }
}
