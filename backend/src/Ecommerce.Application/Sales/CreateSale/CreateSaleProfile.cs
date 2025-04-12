﻿using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.ValueObjects;
using AutoMapper;
using SaleEntity = Ecommerce.Domain.Entities.Sale;

namespace Ecommerce.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<ProductSale, ProductResponseDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product != null ? src.Product.Description : string.Empty))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(dest => dest.Product != null ? dest.Product.Price : 0))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
            .ForMember(dest => dest.TotalAmout, opt => opt.MapFrom(src => src.TotalAmout));

        CreateMap<SaleEntity, CreateSaleResult>()
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
            .ForMember(dest => dest.TotalValue, opt => opt.MapFrom(src => src.TotalValue))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductSales));
    }
}
