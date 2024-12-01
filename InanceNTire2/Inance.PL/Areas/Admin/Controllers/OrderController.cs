using InanceBL.Services.Interfaces;
using InanceModels.DTOs;
using InanceModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inance.PL.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IService<Order> _OrderContext;
        private readonly IService<Service> _serviceContext;
        private readonly IService<Master> _masterContext;

        public OrderController(IService<Order> orderContext,IService<Service> serviceContext, IService<Master> masterContext)
        {
            _OrderContext = orderContext;
            _serviceContext = serviceContext;
            _masterContext = masterContext;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _OrderContext.GetAllAsync();
            return View(orders);
        }

        public async Task<IActionResult> Create() 
        {
            ViewBag.Master = await _masterContext.GetAllAsync();
            ViewBag.Service = await _serviceContext.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto) 
        {
            if (!ModelState.IsValid)
            {
                return View(orderDto);
            }

            var masterId = await _masterContext.GetByMaster(orderDto.ServiceId);

            Order orders = new Order
            {
                ClientName = orderDto.ClientName,
                ClientSurname = orderDto.ClientSurname,
                ClientPhoneNumber = orderDto.ClientPhoneNumber,
                ClientEmail = orderDto.ClientEmail,
                Problem = orderDto.Problem,
                ServiceId = orderDto.ServiceId,
                MasterId = masterId.Id,
                IsActive = true,
                CreatedAt = DateTime.Now,

            };

            await _OrderContext.AddAsync(orders);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
           
            Order? order = await _OrderContext.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();

            }

            ViewBag.Service = await _serviceContext.GetAllAsync();
            ViewBag.Master = await _masterContext.GetAllAsync();

            var orderUpdateDto = new OrderUpdateDto
            {
                ClientName = order.ClientName,
                ClientSurname = order.ClientSurname,
                ClientPhoneNumber = order.ClientPhoneNumber,
                ClientEmail = order.ClientEmail,
                Problem = order.Problem,
                ServiceId = order.ServiceId,
                MasterId = order.MasterId
            };

           
            return View(orderUpdateDto);
        }


        [HttpPost]
        public async Task<IActionResult> Update(OrderUpdateDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return View(orderDto);
            }


            Order orders = new Order
            {
                ClientName = orderDto.ClientName,
                ClientSurname = orderDto.ClientSurname,
                ClientPhoneNumber = orderDto.ClientPhoneNumber,
                ClientEmail = orderDto.ClientEmail,
                Problem = orderDto.Problem,
                ServiceId = orderDto.ServiceId,
                MasterId = 2,
                IsActive = true,
                CreatedAt = DateTime.Now,

            };

            await _OrderContext.UpdateAsync(orders);    

            return RedirectToAction(nameof(Index));
        }
    }
}
