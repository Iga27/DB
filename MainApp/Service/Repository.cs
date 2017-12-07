using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace MainApp.Service
{
    public class Repository : IDisposable    
    {
        private Context db;

        public Repository()
        {
            db = new Context();
        }

        public Book AddBook(Book book)
        {
            return db.Books.Add(book);
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void ConfigureRepository(bool tracking)
        {
            db.Configuration.AutoDetectChangesEnabled = tracking;
            db.Configuration.ValidateOnSaveEnabled = tracking;
        }

        public void DeleteAllData()
        {
            db.Books.RemoveRange(db.Books.Where(x => x.Id != 0));
            db.Categories.RemoveRange(db.Categories.Where(x => x.Id != 0));
            db.Authors.RemoveRange(db.Authors.Where(x => x.AuthorName != null));
            db.Pictures.RemoveRange(db.Pictures.Where(x => x.Id != 0));
            db.Publishers.RemoveRange(db.Publishers.Where(x => x.PublisherName != null));
            db.Years.RemoveRange(db.Years.Where(x => x.YearName != null));
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
