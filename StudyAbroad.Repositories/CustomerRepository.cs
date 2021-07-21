using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Repositories
{
    public interface ICustomerRepository
    {
        CustomerView GetDetailCustomer(int Id);
        List<Customer> GetListCustomer();
        Customer GetCustomerDetail(int Id);
        Customer Add(Customer orderModel);
        void Update(Customer orderModel);
        Customer Delete(int id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        StudyAbroadEntities db = new StudyAbroadEntities();
        public Customer Add(Customer order)
        {

            db.Customer.Add(order);
            db.SaveChanges();
            return order;
        }

        public Customer Delete(int id)
        {
            var Customer = db.Customer.Find(id);
            db.Customer.Remove(Customer);
            db.SaveChanges();

            return Customer;
        }    

        public CustomerView GetDetailCustomer(int Id)
        {
            var query = from c in db.Customer
                        join cc in db.Order on c.OrderID equals cc.ID
                        select new CustomerView()
                        {
                            ID = c.ID,
                            Name = c.Name,
                            Email = c.Email,
                            OrderName = cc.Name,
                            Address = c.Address,
                            DOB = c.DOB,
                            Phone = c.Phone,
                            Avatar = c.Avatar,
                            Gender = c.Gender,
                            OrderAddress = cc.Address,
                            OrderTestDay=cc.TestDay,
                            OrderImage=cc.Image,
                            OrderPrice=cc.Price,
                            OrderSalary=cc.Salary
                        };
            return query.Where(x => x.ID == Id).FirstOrDefault();
        }

        public List<Customer> GetListCustomer()
        {
            var lst = db.Customer.OrderBy(y => y.CreateDate).ToList();
            return lst;
        }

        public Customer GetCustomerDetail(int Id)
        {
            var lst = db.Customer.SingleOrDefault(x => x.ID == Id);
            return lst;
        }

        public void Update(Customer order)
        {
            db.Customer.Attach(order);
            db.Entry(order).State = EntityState.Modified;
            db.Entry(order).Property(x => x.CreateDate).IsModified = false;
            db.SaveChanges();
        }
    }
}
