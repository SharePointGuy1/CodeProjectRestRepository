using CodeProject.RESTRepository.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CodeProject.RESTRepository.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        internal WWIDataContext _context;
        internal DbSet<Customers> _dbSet;

        public CustomerRepository(WWIDataContext context)
        {
            Console.WriteLine(string.Format(
                "\n\n\nCustomerRepository {0}",
                DateTime.Now.ToLocalTime())
                );
            this._context = context;
            this._dbSet = context.Set<Customers>();
        }

        //public CustomerRepository()
        //{
        //    this._context = new WWIDataContext();
        //    this._dbSet = _context.Set<Customers>();
        //}
        public Customers Get(Func<Customers, bool> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetAll()
        {
            IQueryable<Customers> query = this._context.Customers;
            return query;//.ToList<Customers>();

            //return _context.\.Take(5).ToList<Customers>();
        }

        public Customers GetByID(object id)
        {
            Customers customer = _context.Customers.SingleOrDefault(c => c.CustomerId.ToString() == id.ToString());
            // _dbSet.Where<Customers>(c => c.CustomerId == key);
            return customer;
        }

        public void Delete(Customers entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(Func<Customers, bool> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            Customers customer = _context.Customers.SingleOrDefault(c => c.CustomerId.ToString() == id.ToString());
            if (customer != default(Customers))
            {
                _context.Customers.Remove(customer);
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
            return _context.Customers.Any<Customers>(
                c => c.CustomerId.ToString() == primaryKey.ToString()
                );
        }

        public IEnumerable<Customers> Get()
        {
            IQueryable<Customers> query = this._context.Customers;
            return query;//.ToList<Customers>();

            //return _context.\.Take(5).ToList<Customers>();
        }

        public Customers GetFirst(Func<Customers, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customers> GetMany(Func<Customers, bool> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customers> GetManyQueryable(Func<Customers, bool> where)
        {
            throw new NotImplementedException();
        }

        public Customers GetSingle(Func<Customers, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customers> GetWithInclude(Expression<Func<Customers, bool>> predicate, params string[] include)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customers entity)
        {
            var newItem = _context.Add<Customers>(entity);
            int newID = newItem.Entity.CustomerId;
            entity.CustomerId = newID;
            throw new NotImplementedException();
        }

        public void Update(Customers item)
        {
            Customers customer = default(Customers);
            try
            {
                _context.Customers.Single<Customers>(c => c.CustomerId == item.CustomerId);
            }
            //catch(DbEntityValidationException dbEx)
            //{

            //}
            catch (ArgumentException argEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            // TODO: update for all properties except CustomerId
            customer.CustomerName = item.CustomerName;

            List<string> includedProperties = new List<string>();
            includedProperties.Add("CustomerName");
            includedProperties.Add("AccountOpenedDate");
            includedProperties.Add("DeliveryAddressLine1");
            includedProperties.Add("DeliveryAddressLine2");
            includedProperties.Add("DeliveryCity");
            includedProperties.Add("DeliveryCityId");
            includedProperties.Add("DeliveryPostalCode");
            includedProperties.Add("FaxNumber");
            includedProperties.Add("PhoneNumber");
            includedProperties.Add("PostalAddressLine1");
            includedProperties.Add("PostalAddressLine2");
            includedProperties.Add("PostalCity");
            includedProperties.Add("PostalCityId");
            includedProperties.Add("PostalPostalCode");


            Helpers.Utilities.SetProperties(item, customer, includedProperties);

            _context.SaveChanges();
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

        ~CustomerRepository()
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
