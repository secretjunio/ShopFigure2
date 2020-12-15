using AutoMapper;
using ShopMohinh.Models;

namespace ShopMohinh
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() // constructor
        {
            //CreateMap<ProductModel, Product>(); // ProductModel chuyển dữ liệu cho Product
            //CreateMap<Product, ProductModel>(); // Product chuyển dữ liệu cho ProductModel
            CreateMap<CustomerInfo, CustomerInfoModel>();
            CreateMap<CustomerInfoModel, CustomerInfo>();
        }
    }
}