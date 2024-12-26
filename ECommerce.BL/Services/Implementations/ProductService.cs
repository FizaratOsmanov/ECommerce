using AutoMapper;
using ECommerce.BL.DTOs.ProductDTOs;
using ECommerce.BL.Exceptions.CommonExceptions;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.Data.DAL;
using ECommerce.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Services.Implementations
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> CreateAsync(ProductCreateDTO dto)
        {
            Product createdProduct = _mapper.Map<Product>(dto);
            createdProduct.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _productRepository.CreateAsync(createdProduct);
            await _productRepository.Save();
            return createdEntity;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if (!await _productRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var productEntity = await GetByIdAsync(id);
            _productRepository.SoftDelete(productEntity);
            await _productRepository.Save();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, DepartmentAddDTO dto)
        {
            var departmentEntity = await GetByIdAsync(id);
            Department updatedDepartment = _mapper.Map<Department>(dto);
            updatedDepartment.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedDepartment.Id = id;
            _departmentRepository.Update(updatedDepartment);
            await _departmentRepository.Save();
            return true;
        }
    }
}
