using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Repositories
{
    public interface IMenuRepository
    {
        List<Menu> GetListMenu();
        List<Menu> GetListMenuHome();
        Menu GetMenuDetail(int Id);
        Menu Add(Menu orderModel);
        void Update(Menu orderModel);
        Menu Delete(int id);
    }
    public class MenuRepository : IMenuRepository
    {
        StudyAbroadEntities db = new StudyAbroadEntities();
        public Menu Add(Menu order)
        {

            db.Menu.Add(order);
            db.SaveChanges();
            return order;
        }

        public Menu Delete(int id)
        {
            var Menu = db.Menu.Find(id);
            db.Menu.Remove(Menu);
            db.SaveChanges();

            return Menu;
        }

        public List<Menu> GetListMenu()
        {
            var lst = db.Menu.OrderBy(y => y.CreateDate).ToList();
            return lst;
        }

        public List<Menu> GetListMenuHome()
        {
            var lst = db.Menu.OrderBy(y => y.Description).Where(x => x.Status == 1).ToList();
            return lst;
        }

        public Menu GetMenuDetail(int Id)
        {
            var lst = db.Menu.SingleOrDefault(x => x.ID == Id);
            return lst;
        }

        public void Update(Menu order)
        {
            db.Menu.Attach(order);
            db.Entry(order).State = EntityState.Modified;
            db.Entry(order).Property(x => x.CreateDate).IsModified = false;
            db.SaveChanges();
        }
    }
}
