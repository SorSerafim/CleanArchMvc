using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery() ?? throw new Exception($"Entity could not be loaded");
            return _mapper.Map<IEnumerable<ProductDTO>>(await _mediator.Send(productsQuery));
        }
        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value) ?? throw new Exception($"Entity could not be loaded");
            return _mapper.Map<ProductDTO>(await _mediator.Send(productByIdQuery));
        }
        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value) ?? throw new Exception($"Entity could not be loaded");
        //    return _mapper.Map<ProductDTO>(await _mediator.Send(productByIdQuery));
        //}
        public async Task Add(ProductDTO productDTO)
        {
            await _mediator.Send(_mapper.Map<ProductCreateCommand>(productDTO));
        }
        public async Task Update(ProductDTO productDTO)
        {
            await _mediator.Send(_mapper.Map<ProductUpdateCommand>(productDTO));
        }
        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value) ?? throw new Exception($"Entity could not be loaded");
            await _mediator.Send(productRemoveCommand);
        }
    }
}
