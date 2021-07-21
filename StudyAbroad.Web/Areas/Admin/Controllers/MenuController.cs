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
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public ActionResult Index()
        {
            var listMenu = _menuRepository.GetListMenu();
            var listlistMenuModel = Mapper.Map<List<Menu>, List<MenuViewModel>>(listMenu);
            ViewBag.ListMenu = listlistMenuModel;
            if (listMenu.Count() == 0)
            {
                TempData["warning"] = "Không tìm thấy bản ghi nào";
            }
            return View();
        }
        public ActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuViewModel MenuModel)
        {
            if (ModelState.IsValid)
            {
                var newMenu = new Menu();
                newMenu.UpdateMenu(MenuModel);
                newMenu.CreateDate = DateTime.Now;
                _menuRepository.Add(newMenu);
                TempData["success"] = "Thêm mới menu thành công";
                return RedirectToAction("Index");
            }
            else
            {            
                TempData["error"] = "Thêm mới menu thất bại";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = _menuRepository.GetMenuDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Menu không tồn tại";
                return RedirectToAction("Index");
            }       
            var viewModel = Mapper.Map<Menu, MenuViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(MenuViewModel MenuModel)
        {          
            if (ModelState.IsValid)
            {
                var oldMenu = _menuRepository.GetMenuDetail(MenuModel.ID);
                oldMenu.ModifiedDate = DateTime.Now;
                oldMenu.UpdateMenu(MenuModel);
                _menuRepository.Update(oldMenu);
                TempData["success"] = "Cập nhật menu thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var model = _menuRepository.GetMenuDetail(MenuModel.ID);
                var viewModel = Mapper.Map<Menu, MenuViewModel>(model);
                TempData["error"] = "Cập nhật menu thất bại";
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var model = _menuRepository.GetMenuDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Menu không tồn tại";
                return RedirectToAction("Index");
            }
            _menuRepository.Delete(id);
            TempData["success"] = "Xóa menu thành công";
            return RedirectToAction("Index");
        }
    }
}