using System;
using System.Collections.Generic;
using System.Text;
using ClepsydraLite.DAL.Entities;

namespace ClepsydraLite.DAL.Services
{
    public class ShopRepository: IShopRepository
    {
        public IEnumerable<Supplier> GetSuppliers()
        {
            throw new NotImplementedException();
        }

        public Supplier GetSupplier(int supplierId)
        {
            throw new NotImplementedException();
        }

        public bool SupplierExists(int supplierId)
        {
            throw new NotImplementedException();
        }

        public void AddSupplier(int supplierId, Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplier(int supplierId, Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
