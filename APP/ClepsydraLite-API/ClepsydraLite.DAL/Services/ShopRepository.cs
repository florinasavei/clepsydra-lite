using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClepsydraLite.DAL.Entities;
using ClepsydraLite.DAL.Entities.Shop;
using ClepsydraLite.DAL.Entities.Supplier;
using ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer;
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
                .Include(t => t.SupplierProductCategories)
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
            _context.Suppliers_ProductCategories.AddRange(supplier.SupplierProductCategories);
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

        public void UpdateSupplierProductCategory(SupplierProductCategory supplierProductCategory)
        {
            // no code in this implementation
        }

        public void DeleteProductCategoryForSupplier(SupplierProductCategory supplierProductCategoryEntity)
        {
            _context.Suppliers_ProductCategories.Remove(supplierProductCategoryEntity);
        }


        public IEnumerable<SupplierProductOffer> GetProductsFromCategoryForSupplier(int supplierId, int categoryId)
        {
            if (supplierId == 0)
            {
                throw new ArgumentNullException(nameof(supplierId));
            }

            return _context.Suppliers_ProductOffers
                .Where(c => c.SupplierProductCategoryId == categoryId && c.SupplierProductCategory.SupplierCoreId == supplierId)
                .OrderBy(c => c.Name)
                .ToList();
        }

        public SupplierProductOffer GetProductFromCategoryForSupplier(int supplierId, int supplierProductCategoryId, int productId)
        {
            if (supplierId == 0)
            {
                throw new ArgumentNullException(nameof(supplierId));
            }

            if (supplierProductCategoryId == 0)
            {
                throw new ArgumentNullException(nameof(supplierProductCategoryId));
            }

            if (productId == 0)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Suppliers_ProductOffers
                .FirstOrDefault(c => c.Id == productId &&  c.SupplierProductCategoryId == supplierProductCategoryId && c.SupplierProductCategory.SupplierCoreId == supplierId);
        }

        public void AddProductToCategoryToSupplier(int supplierId, int supplierProductCategoryId,
            SupplierProductOffer productOfferToSave)
        {
            if (supplierId == 0)
            {
                throw new ArgumentNullException(nameof(supplierId));
            }

            if (productOfferToSave == null)
            {
                throw new ArgumentNullException(nameof(productOfferToSave));
            }

            // always set the SupplierId to the passed-in supplierId
            productOfferToSave.SupplierProductCategoryId = supplierProductCategoryId;
            _context.Suppliers_ProductOffers.Add(productOfferToSave);
        }

        public void UpdateProductForSupplierProductCategory(SupplierProductOffer supplierProductCategoryFromRepo)
        {
          // nothing to do here
        }

        public void DeleteProductFromCategoryForSupplier(SupplierProductOffer supplierProductCategoryEntity)
        {
            _context.Suppliers_ProductOffers.Remove(supplierProductCategoryEntity);
        }


        public IEnumerable<SupplierProductOfferPrice> GetProductPriceForSupplier(in int supplierId, in int supplierProductCategoryId, in int supplierProductId,
            in int priceId)
        {
            throw new NotImplementedException();
        }

        public SupplierProductOfferPrice GetProductPricesForSupplier(in int supplierId, in int supplierProductCategoryId,
            in int supplierProductId)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<ShopCore> GetShops()
        {
            return _context.Shops_Core
                .OrderBy(c => c.Name)
                .ToList();
        }

        public ShopCore GetShop(int shopId)
        {
            return _context.Shops_Core
                ?.Where(c => c.Id == shopId)
                .FirstOrDefault();
        }

        public bool ShopExists(int shopId)
        {
            return _context.Shops_Core.Any(c => c.Id == shopId);
        }

        public void AddShop(ShopCore shop)
        {
            _context.Shops_Core.Add(shop);
        }

        public void UpdateShop(ShopCore shop)
        {
            // just for consistency because other ORMs don't track changes, but EF does
        }

        public void DeleteShop(ShopCore shop)
        {
            _context.Shops_Core.Remove(shop);
        }


        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
