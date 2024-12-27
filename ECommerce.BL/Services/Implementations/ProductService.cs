using AutoMapper;
using ECommerce.BL.DTOs.ProductDTOs;
using ECommerce.BL.Exceptions.CommonExceptions;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.Data.Repositories.Abstractions;

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
        public async Task<ICollection<Product>> GetAllProductAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        public async Task<Product> CreateProductAsync(ProductCreateDTO dto)
        {
            Product createdProduct = _mapper.Map<Product>(dto);
            createdProduct.CreatedAt = DateTime.UtcNow.AddHours(4);
            var createdEntity = await _productRepository.CreateAsync(createdProduct);
            await _productRepository.Save();
            return createdEntity;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            if (!await _productRepository.IsExistsAsync(id))
            {
                throw new EntityNotFoundException();
            }
            return await _productRepository.GetByIdAsync(id);
        }
        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            _productRepository.SoftDelete(productEntity);
            await _productRepository.Save();
            return true;
        }
        public async Task<bool> UpdateProductAsync(int id, ProductCreateDTO dto)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            Product updatedProduct = _mapper.Map<Product>(dto);
            updatedProduct.UpdatedAt = DateTime.UtcNow.AddHours(4);
            updatedProduct.Id = id;
            _productRepository.Update(updatedProduct);
            await _productRepository.Save();
            return true;
        }
    }
}
