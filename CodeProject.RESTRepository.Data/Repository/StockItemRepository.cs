using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CodeProject.RESTRepository.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeProject.RESTRepository.Data.Repository
{
    public class StockItemRepository : IStockItemRepository
    {
        internal WWIDataContext _context;
        internal DbSet<StockItems> _dbSet;

        IEnumerable<StockItems> IRepository<StockItems>.Get()
        {
            IQueryable<StockItems> query = this._context.StockItems;
            return query;//.ToList<StockItems>();

            //return _context.\.Take(5).ToList<StockItems>();
        }

        StockItems IRepository<StockItems>.GetByID(object id)
        {
            StockItems stockItem = _context.StockItems.SingleOrDefault(s => s.StockItemId.ToString() == id.ToString());
            // _dbSet.Where<StockItems>(c => c.CustomerId == key);
            return stockItem;
        }

        void IRepository<StockItems>.Insert(StockItems item)
        {
            var newItem = _context.Add<StockItems>(item);
            int newID = newItem.Entity.StockItemId;
            item.StockItemId = newID;
            throw new NotImplementedException();
        }

        void IRepository<StockItems>.Delete(object id)
        {
            StockItems stockItem = _context.StockItems.SingleOrDefault(s => s.StockItemId.ToString() == id.ToString());
            if (stockItem != default(StockItems))
            {
                _context.StockItems.Remove(stockItem);
                _context.SaveChanges();
            }
            else
            {
                ArgumentException ex = new ArgumentException(string.Format("No customer matches Id {0}", id.ToString()));
                throw ex;
            }
        }

        void IRepository<StockItems>.Delete(StockItems item)
        {
            StockItems stockItem = _context.StockItems.SingleOrDefault(
                s => s.StockItemId.ToString() == item.StockItemId.ToString()
                );
            if (stockItem != default(StockItems))
            {
                _context.StockItems.Remove(stockItem);
                _context.SaveChanges();
            }
            else
            {
                ArgumentException ex = new ArgumentException(
                    string.Format("No customer matches Id {0}", item.StockItemId.ToString())
                    );
                throw ex;
            }
        }

        void IRepository<StockItems>.Update(StockItems item)
        {
            StockItems stockItem = default(StockItems);
            try
            {
                _context.StockItems.Single<StockItems>(s => s.StockItemId == item.StockItemId);
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
            // TODO: update for all properties except StockItemId
            stockItem.StockItemName = item.StockItemName;            

            List<string> includedProperties = new List<string>();
            includedProperties.Add("SupplierID");
            includedProperties.Add("ColorID");
            includedProperties.Add("UnitPackageID");
            includedProperties.Add("OuterPackageID");
            includedProperties.Add("Brand");
            includedProperties.Add("Size");
            includedProperties.Add("LeadTimeDays");
            includedProperties.Add("QuantityPerOuter");
            includedProperties.Add("IsChillerStock");
            includedProperties.Add("BarCode");
            includedProperties.Add("TaxRate");
            includedProperties.Add("UnitPrice");
            includedProperties.Add("RecommendedRetailPrice");
            includedProperties.Add("TypicalWeightPerUnit");
            includedProperties.Add("MarketingComments");
            includedProperties.Add("InternalComments");
            includedProperties.Add("Photo");
            includedProperties.Add("CustomFields");
            includedProperties.Add("Tags");
            includedProperties.Add("SearchDetails");
            includedProperties.Add("LastEditedBy");

            Helpers.Utilities.SetProperties(item, stockItem, includedProperties);

            _context.SaveChanges();
        }

        IEnumerable<StockItems> IRepository<StockItems>.GetMany(Func<StockItems, bool> where)
        {
            throw new NotImplementedException();
        }

        IQueryable<StockItems> IRepository<StockItems>.GetManyQueryable(Func<StockItems, bool> where)
        {
            throw new NotImplementedException();
        }

        StockItems IRepository<StockItems>.Get(Func<StockItems, bool> where)
        {
            throw new NotImplementedException();
        }

        void IRepository<StockItems>.Delete(Func<StockItems, bool> where)
        {
            throw new NotImplementedException();
        }

        IEnumerable<StockItems> IRepository<StockItems>.GetAll()
        {
            IQueryable<StockItems> query = this._context.StockItems;
            return query;//.ToList<StockItems>();

            //return _context.\.Take(5).ToList<StockItems>();
        }

        IQueryable<StockItems> IRepository<StockItems>.GetWithInclude(Expression<Func<StockItems, bool>> predicate, params string[] include)
        {
            throw new NotImplementedException();
        }

        bool IRepository<StockItems>.Exists(object primaryKey)
        {
            return _context.StockItems.Any<StockItems>(
                s => s.StockItemId.ToString() == primaryKey.ToString()
                );
        }

        StockItems IRepository<StockItems>.GetSingle(Func<StockItems, bool> predicate)
        {
            throw new NotImplementedException();
        }

        StockItems IRepository<StockItems>.GetFirst(Func<StockItems, bool> predicate)
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

        ~StockItemRepository()
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
