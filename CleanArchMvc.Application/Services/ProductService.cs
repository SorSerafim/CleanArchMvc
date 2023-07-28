using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentException(nameof(productRepository));
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _productRepository.GetProductsAsync());
        }
        public async Task<ProductDTO> GetById(int? id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetByIdAsync(id));
        }
        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            return _mapper.Map<ProductDTO>(await _productRepository.GetProductCategoryAsync(id));
        }
        public async Task Add(ProductDTO productDTO)
        {
            await _productRepository.Create(_mapper.Map<Product>(productDTO));
        }
        public async Task Update(ProductDTO productDTO)
        {
            await _productRepository.Update(_mapper.Map<Product>(productDTO));
        }
        public async Task Remove(int? id)
        {
            await _productRepository.Remove(_productRepository.GetByIdAsync(id).Result);
        }
    }
}
