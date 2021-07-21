using AutoMapper;
using StudyAbroad.Data.Models;
using StudyAbroad.Repositories;
using StudyAbroad.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // GET: Order
        public ActionResult Order(int page=1)
        {
            int pageSize = 10;
            int totalRow = 0;
            var OrderModel = _orderRepository.GetListOrderPaging(page, pageSize, out totalRow);
            var orderViewModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(OrderModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<OrderViewModel>()
            {
                Items = orderViewModel,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        public ActionResult StudyBoard()
        {
            return View();
        }

        public ActionResult OrderDetail(int id)
        {
            var data = _orderRepository.GetOrderDetail(id);
            return View(data);
        }
    }
}