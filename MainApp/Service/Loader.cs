using MainApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Service
{
    public class Loader: IDisposable
    {
        Repository repo;
         

        public Loader()
        {
            repo = new Repository();
        }

        public void Dispose()
        {
            repo.Dispose();
        }


        public void LoadData(IEnumerable<IDbEntry> items) //исправить этот метод
        {
            foreach(var category in items.OfType<Category>())
            {
                repo.AddCategory(category);
                repo.Save();
            }
            int i=0;
            // ConfigureReferences(book);
            foreach (var book in items.OfType<Book>())
            {
                repo.AddBook(book);
                if (++i == 1000)
                {
                    repo.Save();
                    Console.WriteLine("--------------------------------------------------------------");
                    i = 0;
                }
            }
            repo.Save();
        }
    }
}
