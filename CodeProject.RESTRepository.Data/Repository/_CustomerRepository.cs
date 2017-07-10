using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CodeProject.RESTRepository.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeProject.RESTRepository.Data.Repository
{
    public class _CustomerRepository : IRepository<Customers>
    {
        internal WWIDataContext _context;
        internal DbSet<Customers> _dbSet;
        public _CustomerRepository(WWIDataContext context)
        {
            this._context = context;
            this._dbSet = context.Set<Customers>();
        }
        public virtual void Add(Customers item)
        {
            var newItem = _context.Add<Customers>(item);
            int newID = newItem.Entity.CustomerId;
            item.CustomerId = newID;
        }

        public virtual Customers GetByID(int key)
        {
            Customers customer = _context.Customers.SingleOrDefault(c => c.CustomerId == key);
            // _dbSet.Where<Customers>(c => c.CustomerId == key);
            return customer;
        }

        public virtual IEnumerable<Customers> GetAll()
        {
            IQueryable<Customers> query = _dbSet;
            return query.ToList<Customers>();
        }

        public virtual void Remove(int key)
        {
            Customers customer = _context.Customers.SingleOrDefault(c => c.CustomerId == key);
            if (customer != default(Customers))
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            else
            {
                Exception ex = new ArgumentException(string.Format("No customer matches Id {0}", key.ToString()));
                throw ex;
            }

        }

        public virtual void Update(Customers item)
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

        public IEnumerable<Customers> Get()
        {
            throw new NotImplementedException();
        }

        public Customers GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customers entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customers entityToDelete)
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

        public Customers Get(Func<Customers, bool> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(Func<Customers, bool> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customers> GetWithInclude(Expression<Func<Customers, bool>> predicate, params string[] include)
        {
            throw new NotImplementedException();
        }

        public bool Exists(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public Customers GetSingle(Func<Customers, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Customers GetFirst(Func<Customers, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
