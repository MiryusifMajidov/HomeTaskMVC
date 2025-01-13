using FinalProjectTest.BL.CustomExtension;
using FinalProjectTest.BL.Implementation.Interfaces;
using FinalProjectTest.DAL.Repositories;
using FinalProjectTest.Model.Dtos.CartDtos;
using FinalProjectTest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace FinalProjectTest.BL.Implementation.Services
{
    public class CartService : ICartService
    {
        private IRepository<Cart> _cartRepository;

        public CartService(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task DeleteAsync(int Id)
        {
            var cart = await _cartRepository.GetByIdAsync(Id);

            if (cart == null) {

                throw new Exception("Silmek istediyiniz cart tapilmadi");
            }
            await _cartRepository.DeleteAsync(Id);
            await _cartRepository.SaveAsync();
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _cartRepository.GetAllAsync();

           
        }

        public async Task<Cart?> GetByIdAsync(int Id)
        {
            return await _cartRepository.GetByIdAsync(Id);
        }

        public async Task InsertAsync(CreateCartDto Entity)
        {

            var ImagePathName = await Entity.Image.FileUpload("wwwroot/Images/Cart", 5);

            Cart cart = new Cart() 
            {
                Tittle = Entity.Tittle,
                Description = Entity.Description,
                Icon = Entity.Icon,
                Image = ImagePathName,
                CreateAt = DateTime.Now,
            
            };
            await _cartRepository.InsertAsync(cart);
            await _cartRepository.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _cartRepository.SaveAsync();
        }

        public async Task UpdateAsync(UpdateCartDto Entity)
        {
           var cart = await _cartRepository.GetByIdAsync(Entity.Id);
            if (cart == null) {

                throw new Exception("Update etmek istediyiniz cart tapilmadi");
            }

           

            Cart cartUpdate = new Cart()
            {
                Id = Entity.Id,
                Tittle = Entity.Tittle,
                Description = Entity.Description,
                Icon = Entity.Icon,


            };


            if (Entity.Image == null)
            {
                cartUpdate.Image = Entity.ImageUrl;

            }
            else
            {
                var ImagePathName = await Entity.Image.FileUpload("wwwroot/Images/Cart", 5);
                cartUpdate.Image = ImagePathName;
            }
            
            await _cartRepository.UpdateAsync(cartUpdate);
            await _cartRepository.SaveAsync();
        }
    }
}
