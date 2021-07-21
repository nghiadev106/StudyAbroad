using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Repositories
{
    public interface IOrderCategoryRepository
    {
        List<OrderCategory> GetListOrderCategory();
        OrderCategory GetOrderCategoryDetail(int Id);
        OrderCategory Add(OrderCategory orderCategoryModel);
        void Update(OrderCategory orderCategoryModel);
        OrderCategory Delete(int id);
    }
    public class OrderCategoryRepository : IOrderCategoryRepository
    {
        StudyAbroadEntities db = new StudyAbroadEntities();
        public OrderCategory Add(OrderCategory orderCategory)
        {

            db.OrderCategory.Add(orderCategory);
            db.SaveChanges();
            return orderCategory;
        }

        public OrderCategory Delete(int id)
        {
            var OrderCategory = db.OrderCategory.Find(id);
            db.OrderCategory.Remove(OrderCategory);
            db.SaveChanges();

            return OrderCategory;
        }

        public List<OrderCategory> GetListOrderCategory()
        {
            var lst = db.OrderCategory.OrderBy(y => y.CreateDate).ToList();
            return lst;
        }

        public OrderCategory GetOrderCategoryDetail(int Id)
        {
            var lst = db.OrderCategory.SingleOrDefault(x => x.ID == Id);
            return lst;
        }

        public void Update(OrderCategory orderCategory)
        {
            db.OrderCategory.Attach(orderCategory);
            db.Entry(orderCategory).State = EntityState.Modified;
            db.Entry(orderCategory).Property(x => x.CreateDate).IsModified = false;
            db.SaveChanges();
        }
    }
}
