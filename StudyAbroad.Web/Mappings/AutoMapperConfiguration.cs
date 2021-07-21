using AutoMapper;
using StudyAbroad.Data.Models;
using StudyAbroad.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyAbroad.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<News, NewsViewModel>();
                cfg.CreateMap<NewsCategory, NewsCategoryViewModel>();
                cfg.CreateMap<Order, OrderViewModel>();
                cfg.CreateMap<OrderCategory, OrderCategoryViewModel>();
                cfg.CreateMap<Customer, CustomerViewModel>();
                cfg.CreateMap<Menu, MenuViewModel>();
                cfg.CreateMap<Program, ProgramViewModel>();
            });
        }
    }
}