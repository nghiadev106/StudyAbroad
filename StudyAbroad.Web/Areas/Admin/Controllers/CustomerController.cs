using AutoMapper;
using StudyAbroad.Data.Models;
using StudyAbroad.Repositories;
using StudyAbroad.Web.Mappings;
using StudyAbroad.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerController(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var listCustomer = _customerRepository.GetListCustomer();
            var listCustomerModel = Mapper.Map<List<Customer>, List<CustomerViewModel>>(listCustomer);
            ViewBag.ListCustomer = listCustomerModel;
            if (listCustomer.Count() == 0)
            {
                TempData["warning"] = "Không tìm thấy bản ghi nào";
            }
            return View();
        }

        public ActionResult Detail(int id)
        {
            var model = _customerRepository.GetDetailCustomer(id);
            if (model == null)
            {
                TempData["warning"] = "Khách hàng không tồn tại";
                return RedirectToAction("Index");
            }
            ViewBag.Detail = model;
            return View();
        }
        public ActionResult Create()
        {
            var categories = _orderRepository.GetListOrderHome();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel CustomerModel)
        {
            if (ModelState.IsValid)
            {
                if (CustomerModel.LogoFile == null || CustomerModel.LogoFile.ContentLength == 0)
                {
                    var categories = _orderRepository.GetListOrderHome();
                    SelectList categoryList = new SelectList(categories, "Id", "Name");
                    ViewBag.categoryList = categoryList;
                    TempData["error"] = "Mời bạn chọn ảnh đại diện";
                    return View();
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(CustomerModel.LogoFile.FileName);
                    string extention = Path.GetExtension(CustomerModel.LogoFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    CustomerModel.Avatar = "/UploadFiles/Avatars/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/UploadFiles/Avatars/"), fileName);
                    CustomerModel.LogoFile.SaveAs(fileName);
                }
                var newCustomer = new Customer();
                newCustomer.UpdateCustomer(CustomerModel);
                newCustomer.CreateDate = DateTime.Now;
                _customerRepository.Add(newCustomer);
                TempData["success"] = "Thêm mới khách hàng thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _orderRepository.GetListOrderHome();
                SelectList categoryList = new SelectList(categories, "Id", "Name");
                ViewBag.categoryList = categoryList;

                TempData["error"] = "Thêm mới khách hàng thất bại";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = _customerRepository.GetCustomerDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Khách hàng không tồn tại";
                return RedirectToAction("Index");
            }
            var categories = _orderRepository.GetListOrderHome();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;

            var viewModel = Mapper.Map<Customer, CustomerViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel CustomerModel)
        {
            var categories = _orderRepository.GetListOrderHome();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;

            if (ModelState.IsValid)
            {
                var oldCustomer = _customerRepository.GetCustomerDetail(CustomerModel.ID);
                if (CustomerModel.LogoFile == null || CustomerModel.LogoFile.ContentLength == 0)
                {
                    CustomerModel.Avatar = oldCustomer.Avatar;
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(CustomerModel.LogoFile.FileName);
                    string extention = Path.GetExtension(CustomerModel.LogoFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    CustomerModel.Avatar = "/UploadFiles/Avatars/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/UploadFiles/Avatars/"), fileName);
                    CustomerModel.LogoFile.SaveAs(fileName);
                }
            
                oldCustomer.ModifiedDate = DateTime.Now;
                oldCustomer.UpdateCustomer(CustomerModel);
                _customerRepository.Update(oldCustomer);
                TempData["success"] = "Cập nhật khách hàng thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var model = _customerRepository.GetCustomerDetail(CustomerModel.ID);
                var viewModel = Mapper.Map<Customer, CustomerViewModel>(model);
                TempData["error"] = "Cập nhật khách hàng thất bại";
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var model = _customerRepository.GetCustomerDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Khách hàng không tồn tại";
                return RedirectToAction("Index");
            }
            _customerRepository.Delete(id);
            TempData["success"] = "Xóa khách hàng thành công";
            return RedirectToAction("Index");
        }
    }
}