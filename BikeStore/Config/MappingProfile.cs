using AutoMapper;
using BikeStore.Data.Models;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandRequestModel, Brands>();
            CreateMap<CategoryRequestModel, Categories>();
            CreateMap<ProductRequestModel, Products>();
            CreateMap<StoreRequestModel, Stores>();
        }
    }
}
