using System;
using System.Collections.Generic;
using System.Text;
using ClepsydraLite.DAL.Entities;

namespace ClepsydraLite.DAL.Services
{
    public interface IShopRepository
    {

        IEnumerable<Supplier> GetSuppliers();

        Supplier GetSupplier(int supplierId);

        bool SupplierExists(int supplierId);

        void AddSupplier(int supplierId, Supplier supplier);

        void UpdateSupplier(int supplierId, Supplier supplier);

        void DeleteSupplier(Supplier supplier);

        bool Save();

    }
}
