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
    public class ProgramController : Controller
    {
        // GET: Admin/Program
        private readonly IProgramRepository _programRepository;
        private readonly IOrderRepository _orderRepository;

        public ProgramController(IProgramRepository programRepository, IOrderRepository orderRepository)
        {
            _programRepository = programRepository;
            _orderRepository = orderRepository;
        }

        public ActionResult Index()
        {
            var listProgram = _programRepository.GetListProgram();
            var listlistProgramModel = Mapper.Map<List<Program>, List<ProgramViewModel>>(listProgram);
            ViewBag.ListProgram = listlistProgramModel;
            if (listProgram.Count() == 0)
            {
                TempData["warning"] = "Không tìm thấy bản ghi nào";
            }
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
        public ActionResult Create(ProgramViewModel ProgramModel)
        {
            if (ModelState.IsValid)
            {
                var newProgram = new Program();
                newProgram.UpdateProgram(ProgramModel);
                newProgram.CreateDate = DateTime.Now;
                _programRepository.Add(newProgram);
                TempData["success"] = "Thêm mới chương trình - dịch vụ thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var categories = _orderRepository.GetListOrderHome();
                SelectList categoryList = new SelectList(categories, "Id", "Name");
                ViewBag.categoryList = categoryList;

                TempData["error"] = "Thêm mới chương trình - dịch vụ thất bại";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = _programRepository.GetProgramDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Chương trình - Dịch vụ không tồn tại";
                return RedirectToAction("Index");
            }
            var categories = _orderRepository.GetListOrderHome();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;

            var viewModel = Mapper.Map<Program, ProgramViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProgramViewModel ProgramModel)
        {
            var categories = _orderRepository.GetListOrderHome();
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;

            if (ModelState.IsValid)
            {
                var oldProgram = _programRepository.GetProgramDetail(ProgramModel.ID);
                oldProgram.ModifiedDate = DateTime.Now;
                oldProgram.UpdateProgram(ProgramModel);
                _programRepository.Update(oldProgram);
                TempData["success"] = "Cập nhật chương trình - dịch vụ thành công";
                return RedirectToAction("Index");
            }
            else
            {
                var model = _programRepository.GetProgramDetail(ProgramModel.ID);
                var viewModel = Mapper.Map<Program, ProgramViewModel>(model);
                TempData["error"] = "Cập nhật chương trình - dịch vụ thất bại";
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var model = _programRepository.GetProgramDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Chương trình - Dịch vụ không tồn tại";
                return RedirectToAction("Index");
            }
            _programRepository.Delete(id);
            TempData["success"] = "Xóa chương trình - dịch vụ thành công";
            return RedirectToAction("Index");
        }
    }
}