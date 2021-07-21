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
    public class OrderController : Controller
    {
        // GET: Admin/Order
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderCategoryRepository _orderCategoryRepository;

        public OrderController(IOrderRepository orderRepository, IOrderCategoryRepository orderCategoryRepository)
        {
            _orderRepository = orderRepository;
            _orderCategoryRepository = orderCategoryRepository;
        }

        public ActionResult Index()
        {
            var listOrder = _orderRepository.GetListOrder();
            //var listlistOrderModel = Mapper.Map<List<Order>, List<OrderViewModel>>(listOrder);
            ViewBag.ListOrder = listOrder;
            if (listOrder.Count() == 0)
            {
                TempData["warning"] = "Không tìm thấy bản ghi nào";
            }
            return View();
        }
        public ActionResult Create()
        {
            var categories = _orderCategoryRepository.GetListOrderCategory();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderViewModel OrderModel)
        {
            if (ModelState.IsValid)
            {
                if (OrderModel.LogoFile == null || OrderModel.LogoFile.ContentLength == 0)
                {
                    var categories = _orderCategoryRepository.GetListOrderCategory();
                    SelectList categoryList = new SelectList(categories, "Id", "Name");
                    ViewBag.categoryList = categoryList;
                    TempData["error"] = "Mời bạn chọn ảnh";
                    return View();
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(OrderModel.LogoFile.FileName);
                    string extention = Path.GetExtension(OrderModel.LogoFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    OrderModel.Image = "/UploadFiles/Orders/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/UploadFiles/Orders/"), fileName);
                    OrderModel.LogoFile.SaveAs(fileName);
                }
                var newOrder = new Order();
                newOrder.UpdateOrder(OrderModel);
                newOrder.CreateDate = DateTime.Now;
                _orderRepository.Add(newOrder);
                TempData["success"] = "Thêm mới đơn hàng thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _orderCategoryRepository.GetListOrderCategory();
                SelectList categoryList = new SelectList(categories, "Id", "Name");
                ViewBag.categoryList = categoryList;

                TempData["error"] = "Thêm mới đơn hàng thất bại";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = _orderRepository.GetOrderDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Đơn hàng không tồn tại";
                return RedirectToAction("Index");
            }
            var categories = _orderCategoryRepository.GetListOrderCategory();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;

            var viewModel = Mapper.Map<Order, OrderViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(OrderViewModel OrderModel)
        {
            var categories = _orderCategoryRepository.GetListOrderCategory();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;

            if (ModelState.IsValid)
            {
                var oldOrder = _orderRepository.GetOrderDetail(OrderModel.ID);
                if (OrderModel.LogoFile == null || OrderModel.LogoFile.ContentLength == 0)
                {
                    OrderModel.Image = oldOrder.Image;
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(OrderModel.LogoFile.FileName);
                    string extention = Path.GetExtension(OrderModel.LogoFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                    OrderModel.Image = "/UploadFiles/Orders/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/UploadFiles/Orders/"), fileName);
                    OrderModel.LogoFile.SaveAs(fileName);
                }
                oldOrder.ModifiedDate = DateTime.Now;
                oldOrder.UpdateOrder(OrderModel);
                _orderRepository.Update(oldOrder);
                TempData["success"] = "Cập nhật đơn hàng thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var model = _orderRepository.GetOrderDetail(OrderModel.ID);
                var viewModel = Mapper.Map<Order, OrderViewModel>(model);
                TempData["error"] = "Cập nhật đơn hàng thất bại";
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var model = _orderRepository.GetOrderDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Đơn hàng không tồn tại";
                return RedirectToAction("Index");
            }
            _orderRepository.Delete(id);
            TempData["success"] = "Xóa đơn hàng thành công";
            return RedirectToAction("Index");
        }
    }
}