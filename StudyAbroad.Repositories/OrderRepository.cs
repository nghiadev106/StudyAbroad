using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Repositories
{
    public interface IOrderRepository
    {
        List<OrderView> GetListOrder();
        List<Order> GetListOrderHome();
        Order GetOrderDetail(int Id);
        Order Add(Order orderModel);
        void Update(Order orderModel);
        Order Delete(int id);

        IEnumerable<Order> GetListOrderPaging(int page, int pageSize, out int totalRow);
    }
    public class OrderRepository : IOrderRepository
    {
        StudyAbroadEntities db = new StudyAbroadEntities();

        public IEnumerable<Order> GetListOrderPaging(int page, int pageSize, out int totalRow)
        {
            var query = db.Order.Where(x => x.Status == 1).ToList();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public Order Add(Order order)
        {

            db.Order.Add(order);
            db.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {
            var Order = db.Order.Find(id);
            db.Order.Remove(Order);
            db.SaveChanges();

            return Order;
        }

        public List<OrderView> GetListOrder()
        {
            var query = from c in db.Order
                        join cc in db.OrderCategory on c.CategoryID equals cc.ID
                        select new OrderView()
                        {
                            ID = c.ID,
                            Name = c.Name,
                            Content = c.Content,
                            CategoryName = cc.Name,
                            Description = c.Description,
                            TestDay = c.TestDay,
                            Price=c.Price,
                            Salary=c.Salary,
                            Count=c.Count,
                            Address=c.Address,
                            Status = c.Status,
                            Image=c.Image,
                            CountCustomer=c.Customer.Where(x => x.Status == 1).Count()
                        };
            return query.OrderBy(x => x.ID).ToList();
        }

        public List<Order> GetListOrderHome()
        {
            var lst = db.Order.OrderBy(y => y.CreateDate).Where(x => x.Status == 1).ToList();
            return lst;
        }

        public Order GetOrderDetail(int Id)
        {
            var lst = db.Order.SingleOrDefault(x => x.ID == Id);
            return lst;
        }

        public void Update(Order order)
        {
            db.Order.Attach(order);
            db.Entry(order).State = EntityState.Modified;
            db.Entry(order).Property(x => x.CreateDate).IsModified = false;
            db.SaveChanges();
        }
    }
}
