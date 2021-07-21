using AutoMapper;
using StudyAbroad.Data.Models;
using StudyAbroad.Repositories;
using StudyAbroad.Web.Mappings;
using StudyAbroad.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly INewsRepository _newsRepository;
        private readonly IOrderCategoryRepository _orderCategoryRepository;
        private readonly IProgramRepository _programRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMenuRepository _menuRepository;


        public HomeController(IOrderRepository orderRepository, 
            IOrderCategoryRepository orderCategoryRepository,
            INewsRepository newsRepository,
            IProgramRepository programRepository,
            ICustomerRepository customerRepository,
            IMenuRepository menuRepository)
        {
            _orderRepository = orderRepository;
            _orderCategoryRepository = orderCategoryRepository;
            _newsRepository = newsRepository;
            _programRepository = programRepository;
            _customerRepository = customerRepository;
            _menuRepository = menuRepository;
        }

        public ActionResult Index()
        {
            var orderHot = _orderRepository.GetListOrderHome().Take(4).ToList();
            var orderHotModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orderHot);
            ViewBag.orderHotModel = orderHotModel;

            var lstOrder = _orderRepository.GetListOrderHome().Take(6).ToList();
            var lstOrderModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(lstOrder);
            ViewBag.lstOrderModel = lstOrderModel;

            var News = _newsRepository.GetListNewsHome().Take(4).ToList();
            var NewsModel = Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(News);
            ViewBag.NewsModel = NewsModel;

            var program = _programRepository.GetListProgramHome().OrderBy(x=>x.CreateDate).Take(4).ToList();
            var ProgramModel = Mapper.Map<IEnumerable<Program>, IEnumerable<ProgramViewModel>>(program);
            ViewBag.ProgramModel = ProgramModel;
            return View();
        }


        public ActionResult CustomerRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerRegister(CustomerRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCustomer = new Customer();
                newCustomer.RegisterCustomer(model);
                newCustomer.CreateDate = DateTime.Now;
                newCustomer.Status = 3;
                _customerRepository.Add(newCustomer);
                ViewBag.Success = "Đăng ký thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Đăng ký không thành công";
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var model = _menuRepository.GetListMenuHome();
            var listMenuViewModel = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModel>>(model);
            ViewBag.listMenuViewModel = listMenuViewModel;
            return PartialView();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult WhyChooseUs()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Procedure()
        {
            return View();
        }
    }
}