using StudyAbroad.Data.Models;
using StudyAbroad.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyAbroad.Web.Mappings
{
    public static class EntityExtensions
    {
        public static void UpdateNewsCategory(this NewsCategory NewCategory, NewsCategoryViewModel NewCategoryVm)
        {
            NewCategory.ID = NewCategoryVm.ID;
            NewCategory.Name = NewCategoryVm.Name;
            NewCategory.Description = NewCategoryVm.Description;
            NewCategory.Status = NewCategoryVm.Status;
        }

        public static void UpdateNews(this News news, NewsViewModel newsVm)
        {
            news.ID = newsVm.ID;
            news.Name = newsVm.Name;
            news.Description = newsVm.Description;
            news.Content = newsVm.Content;
            news.CategoryID = newsVm.CategoryID;
            news.Image = newsVm.Image;
            news.Status = newsVm.Status;
        }

        public static void UpdateOrderCategory(this OrderCategory orderCategory, OrderCategoryViewModel orderCategoryVm)
        {
            orderCategory.ID = orderCategoryVm.ID;
            orderCategory.Name = orderCategoryVm.Name;
            orderCategory.Description = orderCategoryVm.Description;
            orderCategory.Status = orderCategoryVm.Status;
        }

        public static void UpdateOrder(this Order order, OrderViewModel orderVm)
        {
            order.ID = orderVm.ID;
            order.Name = orderVm.Name;
            order.Description = orderVm.Description;
            order.Content = orderVm.Content;
            order.CategoryID = orderVm.CategoryID;
            order.TestDay = orderVm.TestDay;
            order.Salary = orderVm.Salary;
            order.Price = orderVm.Price;
            order.Address = orderVm.Address;
            order.Count = orderVm.Count;
            order.Status = orderVm.Status;
            order.Image = orderVm.Image;
        }

        public static void UpdateMenu(this Menu menu, MenuViewModel menuVm)
        {
            menu.ID = menuVm.ID;
            menu.Name = menuVm.Name;
            menu.Description = menuVm.Description;
            menu.URL = menuVm.URL;
            menu.Icon = menuVm.Icon;
            menu.Status = menuVm.Status;
        }

        public static void UpdateProgram(this Program program, ProgramViewModel programVm)
        {
            program.ID = programVm.ID;
            program.Name = programVm.Name;
            program.Description = programVm.Description;
            program.Detail = programVm.Detail;
            program.DateWorkStart = programVm.DateWorkStart;
            program.DateWorkEnd = programVm.DateWorkEnd;
            program.Note = programVm.Note;
            program.Status = programVm.Status;
        }

        public static void UpdateCustomer(this Customer customer, CustomerViewModel customerVm)
        {
            customer.ID = customerVm.ID;
            customer.Name = customerVm.Name;
            customer.Phone = customerVm.Phone;
            customer.Email = customerVm.Email;
            customer.Address = customerVm.Address;
            customer.DOB = customerVm.DOB;
            customer.Avatar = customerVm.Avatar;
            customer.Gender = customerVm.Gender;
            customer.Status = customerVm.Status;
            customer.OrderID = customerVm.OrderID;
        }

        public static void RegisterCustomer(this Customer customer, CustomerRegisterViewModel customerVm)
        {
            customer.Name = customerVm.Name;
            customer.Phone = customerVm.Phone;
            customer.Email = customerVm.Email;
            customer.Address = customerVm.Address;    
        }
    }
}