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

namespace StudyAbroad.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class OrderCategoryController : Controller
    {
        // GET: Admin/OrderCategory
        private readonly IOrderCategoryRepository _orderCategoryRepository;

        public OrderCategoryController(IOrderCategoryRepository OrderCategoryRepository)
        {
            _orderCategoryRepository = OrderCategoryRepository;
        }

        public ActionResult Index()
        {
            var listOrderCategory =_orderCategoryRepository.GetListOrderCategory();
            var listOrderCategoryModel = Mapper.Map<List<OrderCategory>, List<OrderCategoryViewModel>>(listOrderCategory);
            if (listOrderCategoryModel.Count() == 0)
            {
                TempData["warning"] = "Không tìm thấy bản ghi nào";
            }
            ViewBag.ListOrderCategory = listOrderCategoryModel;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderCategoryViewModel OrderCategoryModel)
        {
            if (ModelState.IsValid)
            {
                var newOrderCategory = new OrderCategory();
                newOrderCategory.UpdateOrderCategory(OrderCategoryModel);
                newOrderCategory.CreateDate = DateTime.Now;
               _orderCategoryRepository.Add(newOrderCategory);
                TempData["success"] = "Thêm mới danh mục thành công";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Thêm mới danh mục thất bại";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model =_orderCategoryRepository.GetOrderCategoryDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Danh mục không tồn tại";
                return RedirectToAction("Index");
            }

            var viewModel = Mapper.Map<OrderCategory, OrderCategoryViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(OrderCategoryViewModel OrderCategoryModel)
        {
            if (ModelState.IsValid)
            {
                var oldOrderCategory =_orderCategoryRepository.GetOrderCategoryDetail(OrderCategoryModel.ID);
                oldOrderCategory.ModifiedDate = DateTime.Now;
                oldOrderCategory.UpdateOrderCategory(OrderCategoryModel);
               _orderCategoryRepository.Update(oldOrderCategory);
                TempData["success"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var model =_orderCategoryRepository.GetOrderCategoryDetail(OrderCategoryModel.ID);
                var viewModel = Mapper.Map<OrderCategory, OrderCategoryViewModel>(model);
                TempData["error"] = "Cập nhật danh mục thất bại";
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var model =_orderCategoryRepository.GetOrderCategoryDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Danh mục không tồn tại";
                return RedirectToAction("Index");
            }
           _orderCategoryRepository.Delete(id);
            TempData["success"] = "Xóa danh mục thành công";
            return RedirectToAction("Index");
        }
    }
}