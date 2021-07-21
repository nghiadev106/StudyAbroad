using AutoMapper;
using StudyAbroad.Data.Models;
using StudyAbroad.Repositories;
using StudyAbroad.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly INewsRepository _newsRepository;
        private readonly IProgramRepository _programRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IOrderRepository orderRepository,
            INewsRepository newsRepository,
            IProgramRepository programRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _newsRepository = newsRepository;
            _programRepository = programRepository;
            _customerRepository = customerRepository;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            var lstCustomerRegister = _customerRepository.GetListCustomer().Where(x => x.Status == 3).ToList();
            var listCustomerModel = Mapper.Map<List<Customer>, List<CustomerViewModel>>(lstCustomerRegister);
            ViewBag.listCustomerModel = listCustomerModel;
            
            ViewBag.CustomerCount = _customerRepository.GetListCustomer().Where(x => x.Status == 1).Count();
            ViewBag.CustomerRegisterCount = _customerRepository.GetListCustomer().Where(x => x.Status == 3).Count();
            ViewBag.OrderCount = _orderRepository.GetListOrderHome().Count();
            ViewBag.ProgramCount = _programRepository.GetListProgram().Where(x => x.Status == 1).Count();
            ViewBag.NewsCount = _newsRepository.GetListNews().Where(x => x.Status == 1).Count();
            return View();
        }
    }
}