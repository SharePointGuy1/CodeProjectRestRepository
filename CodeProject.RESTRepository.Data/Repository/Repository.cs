using CodeProject.RESTRepository.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeProject.RESTRepository.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IDisposable, IEntity
    {
        #region Private member variables...
        internal WWIDataContext _context;
        internal DbSet<T> _dbSet;
        #endregion

        #region Public Constructor...
        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        /// <param name="context"></param>
        public Repository(WWIDataContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        #endregion

        #region Public member methods...

        /// <summary>
        /// generic Get method for Entities
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> Get()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetByID(object id)
        {
            throw new NotImplementedException();
            //return _dbSet.Find(id);
        }

        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            throw new NotImplementedException();
            //T entityToDelete = _dbSet.Find(id);
            //Delete(entityToDelete);
        }

        /// <summary>
        /// Generic Delete method for the entities
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Func<T, bool> where)
        {
            return _dbSet.Where(where).ToList();
        }

        /// <summary>
        /// generic method to get many record on the basis of a condition but query able.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetManyQueryable(Func<T, bool> where)
        {
            return _dbSet.Where(where).AsQueryable();
        }

        /// <summary>
        /// generic get method , fetches data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Get(Func<T, Boolean> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }

        /// <summary>
        /// generic delete method , deletes data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public void Delete(Func<T, Boolean> where)
        {
            IQueryable<T> objects = _dbSet.Where<T>(where).AsQueryable();
            foreach (T obj in objects)
                _dbSet.Remove(obj);
        }

        /// <summary>
        /// generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Inclue multiple
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public IQueryable<T> GetWithInclude(
            System.Linq.Expressions.Expression<Func<T,
            bool>> predicate, params string[] include)
        {
            throw new NotImplementedException();
            //IQueryable<T> query = this._dbSet;
            //query = include.Aggregate(query, (current, inc) => current.Include(inc));
            //return query.Where(predicate);
        }

        /// <summary>
        /// Generic method to check if entity exists
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public bool Exists(object primaryKey)
        {
            throw new NotImplementedException();
            //return _dbSet.Find(primaryKey) != null;
        }

        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public T GetSingle(Func<T, bool> predicate)
        {
            return _dbSet.Single<T>(predicate);
        }

        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public T GetFirst(Func<T, bool> predicate)
        {
            return _dbSet.First<T>(predicate);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
