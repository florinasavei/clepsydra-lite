using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ClepsydraLite.DAL.Entities.Shop;
using ClepsydraLite.DAL.Entities.Supplier;
using ClepsydraLite.DAL.Models.Shop;
using ClepsydraLite.DAL.Models.Supplier;
using ClepsydraLite.DAL.Models.Supplier.Category;
using ClepsydraLite.DAL.Models.Supplier.Category.ProductOffer;

namespace ClepsydraLite.DAL.Mappings
{
    class SupplierMappings: Profile
    {
        public SupplierMappings()
        {
            CreateMap<SupplierCore, SupplierDto>().ReverseMap(); 
            CreateMap<SupplierCore, SupplierForCreationDto>().ReverseMap();

            CreateMap<SupplierProductCategory, SupplierProductCategoryDto>().ReverseMap();
            CreateMap<SupplierProductCategory, SupplierProductCategoryForCreationDto>().ReverseMap();
            CreateMap<SupplierProductCategory, SupplierProductCategoryForUpdateDto>().ReverseMap();

            CreateMap<SupplierProductOffer, SupplierProductOfferDto>().ReverseMap();
            CreateMap<SupplierProductOffer, SupplierProductOfferForCreationDto>().ReverseMap();
            CreateMap<SupplierProductOffer, SupplierProductOfferForUpdateDto>().ReverseMap();

            CreateMap<ShopCore, ShopDto>().ReverseMap();
            CreateMap<ShopCore, ShopForCreationDto>().ReverseMap();
        }
    }
}
