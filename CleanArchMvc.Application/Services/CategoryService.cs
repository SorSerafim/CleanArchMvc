using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()

        {
            return _mapper.Map<List<CategoryDTO>>(await _categoryRepository.GetCategoriesAsync());
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            return _mapper.Map<CategoryDTO>(await _categoryRepository.GetByIdAsync(id));
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            await _categoryRepository.CreateAsync(_mapper.Map<Category>(categoryDTO));
        }
        public async Task Update(CategoryDTO categoryDTO)
        {
            await _categoryRepository.UpdateAsync(_mapper.Map<Category>(categoryDTO));
        }

        public async Task Remove(int? id)
        {
            await _categoryRepository.RemoveAsync(_categoryRepository.GetByIdAsync(id).Result);
        }        
    }
}
