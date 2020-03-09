using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ClepsydraLite.DAL.Mappings
{
    class SupplierMappings: Profile
    {
        public SupplierMappings()
        {
            CreateMap<Entities.Supplier, Models.SupplierDto>().ReverseMap();
        }
    }
}
