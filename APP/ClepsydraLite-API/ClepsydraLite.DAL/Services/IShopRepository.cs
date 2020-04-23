using System;
using System.Collections.Generic;
using System.Text;
using ClepsydraLite.DAL.Entities;
using ClepsydraLite.DAL.Entities.Shop;
using ClepsydraLite.DAL.Entities.Supplier;
using ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer;

namespace ClepsydraLite.DAL.Services
{
    public interface IShopRepository
    {
        #region Supplier Core
        IEnumerable<SupplierCore> GetSuppliers();

        SupplierCore GetSupplier(int supplierId);

        bool SupplierExists(int supplierId);

        void AddSupplier(SupplierCore supplier);

        void UpdateSupplier(SupplierCore supplier);

        void DeleteSupplier(SupplierCore supplier);
        #endregion Supplier Core

        #region Supplier Product Category
        IEnumerable<SupplierProductCategory> GetProductCategoriesForSupplier(int supplierId);

        SupplierProductCategory GetProductCategoryForSupplier(int supplierId, int supplierCategoryId);

        void AddProductCategoryToSupplier(int supplierId, SupplierProductCategory productCategoryToSave);

        void UpdateSupplierProductCategory(SupplierProductCategory supplierProductCategory);

        void DeleteProductCategoryForSupplier(SupplierProductCategory supplierProductCategoryEntity);
        #endregion Supplier Product Category

        IEnumerable<SupplierProductOffer> GetProductsFromCategoryForSupplier(int supplierId, int categoryId);
        SupplierProductOffer GetProductFromCategoryForSupplier(int supplierId, int supplierProductCategoryId, int productId);
        void AddProductToCategoryToSupplier(int supplierId, int supplierProductCategoryId, SupplierProductOffer productCategoryToSave);
        void UpdateProductForSupplierProductCategory(SupplierProductOffer supplierProductCategoryFromRepo);
        void DeleteProductFromCategoryForSupplier(SupplierProductOffer supplierProductCategoryEntity);



        #region Shop Core
        IEnumerable<ShopCore> GetShops();

        ShopCore GetShop(int shopId);

        bool ShopExists(int shopId);

        void AddShop(ShopCore shop);

        void UpdateShop(ShopCore shop);

        void DeleteShop(ShopCore shop);
        #endregion Shop Core


        bool Save();
    }
}
