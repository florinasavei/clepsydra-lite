using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClepsydraLite.DAL.Entities;

namespace ClepsydraLite.DAL.Services
{
    public class ShopRepository : IShopRepository
    {
        private readonly ShopDbContext _context;

        public ShopRepository(ShopDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _context.Suppliers.OrderBy(c => c.Name).ToList();
        }

        public Supplier GetSupplier(int supplierId)
        {
            return _context.Suppliers
                ?.Where(c => c.Id == supplierId)
                .FirstOrDefault();
        }

        public bool SupplierExists(int supplierId)
        {
            return _context.Suppliers.Any(c => c.Id == supplierId);
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }

        // just for consistency because other ORMs don't track changes, but EF does
        public void UpdateSupplier(Supplier supplier)
        {
        }

        public void DeleteSupplier(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
