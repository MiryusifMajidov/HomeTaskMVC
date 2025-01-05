using FinalApi.BL.CustomExtension;
using FinalApi.BL.Implementations.Interfaces;
using FinalApi.Dal.Interfaces;
using FinalApi.Model.DTOs.Product;
using FinalApi.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalApi.BL.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IRepository<ProductCategory> _repositoryProductCategory;

        public ProductService(IRepository<Product> repository, IRepository<ProductCategory> repositoryProductCategory)
        {
            _repository = repository;
            _repositoryProductCategory = repositoryProductCategory;
        }

        public async Task AddAsync(CreateProductDto entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "CreateProductDto cannot be null.");

            var Image = entity.Image;

            if (Image == null || Image.Length == 0)
                throw new InvalidOperationException("No image provided.");

           
            var ImagePathName = await Image.FileUpload("wwwroot/Images/Product", 5);

            if (string.IsNullOrEmpty(ImagePathName))
                throw new InvalidOperationException("Failed to upload image.");

            var product = new Product()
            {
                Name = entity.Name,
                Description = entity.Description,
                ColorId = entity.ColorId,
                SizeId = entity.SizeId,
                Quantity = entity.Quantity,
                Image = ImagePathName,
                CreatedAt = DateTime.Now,
                IsDeleted = false
            };

            
            await _repository.AddAsync(product);

           
            var productCategory = new ProductCategory()
            {
                CategoryId = entity.CategoryId,
                ProductId = product.Id,
            };
            await _repositoryProductCategory.AddAsync(productCategory);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            
            return await _repository.GetAll();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID.", nameof(id));

            
            var product = await _repository.GetById(id);
            if (product == null)
                throw new InvalidOperationException("Product not found.");

            return product;
        }

        public async Task HardDeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID.", nameof(id));

           
            var product = await _repository.GetById(id);
            if (product == null)
                throw new InvalidOperationException("Product not found.");

            await _repository.HardDelete(id); 
        }

        public async Task SoftDeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID.", nameof(id));

            
            var product = await _repository.GetById(id);
            if (product == null)
                throw new InvalidOperationException("Product not found.");

            product.IsDeleted = true;
            await _repository.Update(product);
        }

        public async Task UpdateAsync(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException( "Product entity cannot be null.");

            if (entity.Id <= 0)
                throw new ArgumentException("Invalid product ID.", nameof(entity.Id));

            
            var product = await _repository.GetById(entity.Id);
            if (product == null)
                throw new InvalidOperationException("Product not found.");

            product.Name = entity.Name;
            product.Description = entity.Description;
            product.ColorId = entity.ColorId;
            product.SizeId = entity.SizeId;
            product.Quantity = entity.Quantity;
            product.Image = entity.Image ?? product.Image; 
            product.CreatedAt = entity.CreatedAt; 
            await _repository.Update(product);
        }
    }
}
