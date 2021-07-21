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
    public class ProgramController : Controller
    {
        private readonly IProgramRepository _programRepository;

        public ProgramController(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        // GET: Program
        public ActionResult Index(int page = 1)
        {
            int pageSize = 9;
            int totalRow = 0;
            var ProgramModel = _programRepository.GetListProgramPaging(page, pageSize, out totalRow);
            var programViewModel = Mapper.Map<IEnumerable<Program>, IEnumerable<ProgramViewModel>>(ProgramModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ProgramViewModel>()
            {
                Items = programViewModel,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        public ActionResult ProgramDetail(int id)
        {
            var data = _programRepository.GetProgramDetail(id);
            return View(data);
        }
    }
}