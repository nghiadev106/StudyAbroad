using AutoMapper;
using StudyAbroad.Repositories;
using StudyAbroad.Web.Models;
using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public NewsController(INewsRepository newsRepository, INewsCategoryRepository newsCategoryRepository)
        {
            _newsRepository = newsRepository;
            _newsCategoryRepository = newsCategoryRepository;
        }
        // GET: News
        public ActionResult Index(int page = 1)
        {
            int pageSize = 9;
            int totalRow = 0;
            var NewsModel = _newsRepository.GetListNewsPaging(page, pageSize, out totalRow);
            var newsViewModel = Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(NewsModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var paginationSet = new PaginationSet<NewsViewModel>()
            {
                Items = newsViewModel,
                MaxPage = 5,
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }

        public ActionResult NewsDetail(int id)
        {
            var data = _newsRepository.GetNewsDetail(id);
            return View(data);
        }
    }
}