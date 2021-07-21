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
    public class NewsCategoryController : Controller
    {
        // GET: Admin/NewsCategory
        private readonly INewsCategoryRepository _NewsCategoryRepository;

        public NewsCategoryController(INewsCategoryRepository NewsCategoryRepository)
        {
            _NewsCategoryRepository = NewsCategoryRepository;
        }

        public ActionResult Index()
        {
            var listNewsCategory = _NewsCategoryRepository.GetListNewsCategory();
            var listNewsCategoryModel = Mapper.Map<List<NewsCategory>, List<NewsCategoryViewModel>>(listNewsCategory);           
            if (listNewsCategoryModel.Count() == 0)
            {
                TempData["warning"] = "Không tìm thấy bản ghi nào";
            }
            ViewBag.ListNewsCategory = listNewsCategoryModel;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsCategoryViewModel NewsCategoryModel)
        {
            if (ModelState.IsValid)
            {
                var newNewsCategory = new NewsCategory();
                newNewsCategory.UpdateNewsCategory(NewsCategoryModel);
                newNewsCategory.CreateDate = DateTime.Now;
                _NewsCategoryRepository.Add(newNewsCategory);
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
            var model = _NewsCategoryRepository.GetNewsCategoryDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Danh mục không tồn tại";
                return RedirectToAction("Index");
            }

            var viewModel = Mapper.Map<NewsCategory, NewsCategoryViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(NewsCategoryViewModel NewsCategoryModel)
        {
            if (ModelState.IsValid)
            {
                var oldNewsCategory = _NewsCategoryRepository.GetNewsCategoryDetail(NewsCategoryModel.ID);
                oldNewsCategory.ModifiedDate = DateTime.Now;
                oldNewsCategory.UpdateNewsCategory(NewsCategoryModel);
                _NewsCategoryRepository.Update(oldNewsCategory);
                TempData["success"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var model = _NewsCategoryRepository.GetNewsCategoryDetail(NewsCategoryModel.ID);
                var viewModel = Mapper.Map<NewsCategory, NewsCategoryViewModel>(model);
                TempData["error"] = "Cập nhật danh mục thất bại";
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var model = _NewsCategoryRepository.GetNewsCategoryDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Danh mục không tồn tại";
                return RedirectToAction("Index");
            }
            _NewsCategoryRepository.Delete(id);
            TempData["success"] = "Xóa danh mục thành công";
            return RedirectToAction("Index");
        }
    }
}
