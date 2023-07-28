﻿using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile 
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            //CreateMap<CategoryDTO, Category>();
            CreateMap<Product, ProductDTO>().ReverseMap();
            //CreateMap<ProductDTO, Product>();
        }
    }
}
