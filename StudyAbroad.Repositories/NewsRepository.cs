using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Repositories
{
    public interface INewsRepository
    {
        List<NewsView> GetListNews();
        List<News> GetListNewsHome();
        News GetNewsDetail(int Id);
        News Add(News NewsModel);
        void Update(News NewsModel);
        News Delete(int id);
        IEnumerable<News> GetListNewsPaging(int page, int pageSize, out int totalRow);
    }
    public class NewsRepository : INewsRepository
    {
        StudyAbroadEntities db = new StudyAbroadEntities();

        public IEnumerable<News> GetListNewsPaging(int page, int pageSize, out int totalRow)
        {
            var query = db.News.Where(x => x.Status == 1).ToList();
            totalRow = query.Count();
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
        public News Add(News News)
        {

            db.News.Add(News);
            db.SaveChanges();
            return News;
        }

        public News Delete(int id)
        {
            var News = db.News.Find(id);
            db.News.Remove(News);
            db.SaveChanges();
            return News;
        }

        public List<NewsView> GetListNews()
        {
            var query = from c in db.News
                       // join cc in db.NewsCategory on c.CategoryID equals cc.ID
                        select new NewsView()
                        {
                            ID = c.ID,
                            Name = c.Name,
                            Content = c.Content,
                            CategoryName = c.NewsCategory.Name,
                            Description = c.Description,
                            Image = c.Image,
                            Status = c.Status
                        };
            return query.OrderBy(x => x.ID).ToList();
        }

        public List<News> GetListNewsHome()
        {
            var lst = db.News.OrderBy(y => y.CreateDate).Where(x => x.Status == 1).Take(8).ToList();
            return lst;
        }

        public News GetNewsDetail(int Id)
        {
            var lst = db.News.SingleOrDefault(x => x.ID == Id);
            return lst;
        }

        public void Update(News News)
        {
            db.News.Attach(News);
            db.Entry(News).State = EntityState.Modified;
            db.Entry(News).Property(x => x.CreateDate).IsModified = false;
            db.SaveChanges();
        }
    }
}
