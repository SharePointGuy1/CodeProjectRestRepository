using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeProject.RESTRepository.Data.Entities;

namespace CodeProject.RESTRepository.Data.Repository
{
    public interface _IRepository<T> where T : IEntity
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T GetByID(int key);
        void Remove(int key);
        void Update(T item);
    }
}
