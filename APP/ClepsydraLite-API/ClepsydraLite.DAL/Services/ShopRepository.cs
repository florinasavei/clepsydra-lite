using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClepsydraLite.DAL.Entities;
using ClepsydraLite.DAL.Entities.Supplier;
using Microsoft.EntityFrameworkCore;

namespace ClepsydraLite.DAL.Services
{
    public class ShopRepository : IShopRepository
    {
        private readonly ShopDbContext _context;

        public ShopRepository(ShopDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<SupplierCore> GetSuppliers()
        {
            return _context.Suppliers_Core
                .Include(t=> t.SupplierProductCategories)
                .OrderBy(c => c.Name)
                .ToList();
        }

        public SupplierCore GetSupplier(int supplierId)
        {
            return _context.Suppliers_Core
                ?.Where(c => c.Id == supplierId)
                .FirstOrDefault();
        }

        public bool SupplierExists(int supplierId)
        {
            return _context.Suppliers_Core.Any(c => c.Id == supplierId);
        }

        public void AddSupplier(SupplierCore supplier)
        {
            _context.Suppliers_Core.Add(supplier);
        }

        // just for consistency because other ORMs don't track changes, but EF does
        public void UpdateSupplier(SupplierCore supplier)
        {
        }

        public void DeleteSupplier(SupplierCore supplier)
        {
            _context.Suppliers_Core.Remove(supplier);
        }

        public IEnumerable<SupplierProductCategory> GetProductCategoriesForSupplier(int supplierId)
        {
            if (supplierId == 0)
            {
                throw new ArgumentNullException(nameof(supplierId));
            }

            return _context.Suppliers_ProductCategories
                .Where(c => c.SupplierCoreId == supplierId)
                .OrderBy(c => c.Name)
                .ToList();
        }

        public SupplierProductCategory GetProductCategoryForSupplier(int supplierId, int supplierCategoryId)
        {
            if (supplierId == 0)
            {
                throw new ArgumentNullException(nameof(supplierId));
            }

            if (supplierCategoryId == 0)
            {
                throw new ArgumentNullException(nameof(supplierCategoryId));
            }

            return _context.Suppliers_ProductCategories
                .FirstOrDefault(c => c.SupplierCoreId == supplierId && c.Id == supplierCategoryId);
        }

        public void AddProductCategoryToSupplier(int supplierId, SupplierProductCategory productCategoryToSave)
        {
            if (supplierId == 0)
            {
                throw new ArgumentNullException(nameof(supplierId));
            }

            if (productCategoryToSave == null)
            {
                throw new ArgumentNullException(nameof(productCategoryToSave));
            }

            // always set the SupplierId to the passed-in supplierId
            productCategoryToSave.SupplierCoreId = supplierId;
            _context.Suppliers_ProductCategories.Add(productCategoryToSave); 
        }

        public void UpdateSupplierProductCategory(SupplierProductCategory courseForAuthorFromRepo)
        {
            // no code in this implementation
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
