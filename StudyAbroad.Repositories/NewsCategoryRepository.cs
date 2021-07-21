using StudyAbroad.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Repositories
{
    public interface INewsCategoryRepository
    {
        List<NewsCategory> GetListNewsCategory();
        NewsCategory GetNewsCategoryDetail(int Id);
        NewsCategory Add(NewsCategory newsCategoryModel);
        void Update(NewsCategory newsCategoryModel);
        NewsCategory Delete(int id);
    }
    public class NewsCategoryRepository : INewsCategoryRepository
    {
        StudyAbroadEntities db = new StudyAbroadEntities();
        public NewsCategory Add(NewsCategory newsCategory)
        {

            db.NewsCategory.Add(newsCategory);
            db.SaveChanges();
            return newsCategory;
        }

        public NewsCategory Delete(int id)
        {
            var NewsCategory = db.NewsCategory.Find(id);
            db.NewsCategory.Remove(NewsCategory);
            db.SaveChanges();

            return NewsCategory;
        }

        public List<NewsCategory> GetListNewsCategory()
        {
            var lst = db.NewsCategory.OrderBy(y => y.CreateDate).ToList();
            return lst;
        }

        public NewsCategory GetNewsCategoryDetail(int Id)
        {
            var lst = db.NewsCategory.SingleOrDefault(x => x.ID == Id);
            return lst;
        }

        public void Update(NewsCategory newsCategory)
        {
            db.NewsCategory.Attach(newsCategory);
            db.Entry(newsCategory).State = EntityState.Modified;
            db.Entry(newsCategory).Property(x => x.CreateDate).IsModified = false;
            db.SaveChanges();
        }
    }
}
