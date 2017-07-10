using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CodeProject.RESTRepository.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeProject.RESTRepository.Data.Repository
{
    public class DeliveryMethodRepository : IDeliveryMethodRepository
    {
        internal WWIDataContext _context;
        internal DbSet<DeliveryMethods> _dbSet;

        public DeliveryMethodRepository(WWIDataContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<DeliveryMethods>();
        }
        public IEnumerable<DeliveryMethods> GetAll()
        {
            IQueryable<DeliveryMethods> query = _dbSet;
            return query.ToList<DeliveryMethods>();
        }

        public DeliveryMethods GetByID(object id)
        {
            DeliveryMethods deliveryMethod = _context.DeliveryMethods.SingleOrDefault(c => c.DeliveryMethodId.ToString() == id.ToString());
            // _dbSet.Where<DeliveryMethods>(c => c.CustomerId == key);
            return deliveryMethod;
        }

        public void Delete(DeliveryMethods item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Func<DeliveryMethods, bool> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            DeliveryMethods deliveryMethod = _context.DeliveryMethods.SingleOrDefault(c => c.DeliveryMethodId.ToString() == id.ToString());
            if (deliveryMethod != default(DeliveryMethods))
            {
                _context.DeliveryMethods.Remove(deliveryMethod);
                _context.SaveChanges();
            }
            else
            {
                ArgumentException ex = new ArgumentException(string.Format("No customer matches Id {0}", id.ToString()));
                throw ex;
            }
        }

        public bool Exists(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DeliveryMethods> Get()
        {
            throw new NotImplementedException();
        }

        public DeliveryMethods Get(Func<DeliveryMethods, bool> where)
        {
            throw new NotImplementedException();
        }
                
        public DeliveryMethods GetFirst(Func<DeliveryMethods, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DeliveryMethods> GetMany(Func<DeliveryMethods, bool> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DeliveryMethods> GetManyQueryable(Func<DeliveryMethods, bool> where)
        {
            throw new NotImplementedException();
        }

        public DeliveryMethods GetSingle(Func<DeliveryMethods, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DeliveryMethods> GetWithInclude(Expression<Func<DeliveryMethods, bool>> predicate, params string[] include)
        {
            throw new NotImplementedException();
        }

        public void Insert(DeliveryMethods item)
        {
            throw new NotImplementedException();
        }

        public void Update(DeliveryMethods item)
        {
            throw new NotImplementedException();
        }
        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }

        ~DeliveryMethodRepository()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
