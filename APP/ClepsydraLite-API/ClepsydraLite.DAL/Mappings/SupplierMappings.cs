using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ClepsydraLite.DAL.Models.Supplier;

namespace ClepsydraLite.DAL.Mappings
{
    class SupplierMappings: Profile
    {
        public SupplierMappings()
        {
            CreateMap<Entities.Supplier, SupplierDto>().ReverseMap();
            CreateMap<Entities.Supplier, SupplierForCreationDto>().ReverseMap();
        }
    }
}
