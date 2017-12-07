using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApp.Models;
using System.IO.Compression;
using System.IO;
using System.Xml;
using System.Threading;
using System.Diagnostics;
using MainApp.Service;

namespace MainApp
{
    class Program
    {
        static Dictionary<string, Author> authorDictionary;
        static Dictionary<string, Publisher> publisherDictionary;
        static Dictionary<string, Year> yearDictionary;
        static Dictionary<int, string> bookDictionary;
        static Dictionary<int, string> categoryDictionary;

        static int ParseToInt(string stringToParse)
        {
            return String.IsNullOrEmpty(stringToParse) ? 0 : Int32.Parse(stringToParse);
        }

        public static void ConfigureReferences(Book book)
        {
            if (book.Author == null)
                book.Author = new Author() { AuthorName = "---" };
            if (authorDictionary.ContainsKey(book.Author.AuthorName))
                book.Author = authorDictionary[book.Author.AuthorName];
            else
                authorDictionary.Add(book.Author.AuthorName, book.Author);

            if (book.Publisher == null)
                book.Publisher = new Publisher() { PublisherName = "---" };
            if (publisherDictionary.ContainsKey(book.Publisher.PublisherName))
                book.Publisher = publisherDictionary[book.Publisher.PublisherName];
            else
                publisherDictionary.Add(book.Publisher.PublisherName, book.Publisher);

            if (book.Year == null)
                book.Year = new Year() { YearName = "---" };
            if (yearDictionary.ContainsKey(book.Year.YearName))
                book.Year = yearDictionary[book.Year.YearName];
            else
                yearDictionary.Add(book.Year.YearName, book.Year);
        }


       /* private static List<Picture> GetPictures(XmlReader innerReader) //исправить
        {
            var list = new List<Picture>();
            do
            {
                if (innerReader.ReadToFollowing("picture"))
                {
                    var url = innerReader.ReadElementContentAsString();
                    if (!String.IsNullOrEmpty(url))
                        list.Add(new Picture() { Url = url });
                }
            }
            while (innerReader.Name == "picture");
            return list;
        }*/

        private static Package GetPackage(XmlReader reader) 
        {
            var package = new Package();
            while (reader.Name == "param")
            {
                var param = reader.GetAttribute("name");
                switch (param)
                {
                    case "Вес":
                        reader.Read();
                        package.Weight = ParseToInt(reader.Value); break;
                    case "Ширина упаковки":
                        reader.Read();
                        package.Width = ParseToInt(reader.Value); break;
                    case "Высота упаковки":
                        reader.Read();
                        package.Height = ParseToInt(reader.Value); break;
                    case "Тип обложки (Переплет)":
                        reader.Read();
                        package.Type = reader.Value;  break;
                    case "Цветные иллюстрации":
                        reader.Read();
                        package.ColorIllustrations = reader.Value == "Да" ? true : false;  break;
                }
                reader.ReadToNextSibling("param");
            }
            return package;
        }


        static IEnumerable<Book> Parse(Func<XmlReader, IEnumerable<Book>> action, string path)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.MaxCharactersFromEntities = 1024;

            using (FileStream zipToOpen = new FileStream(path, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read, true))
            using (Stream fs = archive.Entries.FirstOrDefault().Open())
            using (var reader = XmlReader.Create(fs, settings))
            {
                foreach (var i in action(reader))
                    yield return i;
            }
        }

            static IEnumerable<Book> GetBooks(XmlReader reader)
        {
            int i = 0, j = 0;
            while (reader.Read() && i < 50)
            {
                var book = new Book();
                if (reader.Name == "category")
                {
                    var category = new Category();
                    category.Id = ParseToInt(reader.GetAttribute("id"));
                    if (category.Id != 0)
                    {
                        category.ParentId = ParseToInt(reader.GetAttribute("parentId"));
                        reader.Read();
                        category.Name = reader.Value;
                        book.Category = category;
                        i++;
                        yield return book;
                    }
                }
                if (reader.Name == "offer")  //read subtree
                {
                    var innerReader = reader.ReadSubtree();
                    book.Id = ParseToInt(reader.GetAttribute("id"));
                    if (book.Id != 0)
                    {
                        bool available;
                        Boolean.TryParse(reader.GetAttribute("available"), out available);
                        book.Available = available;
                        book.Type = reader.GetAttribute("type");
                        while (innerReader.Read())
                        {
                            #region  
                            switch (innerReader.Name) //refactor(to separate method)
                            {
                                case "url":
                                    book.Url = innerReader.ReadElementContentAsString(); break;
                                case "price":
                                    book.Price = innerReader.ReadElementContentAsDouble(); break;
                                case "currencyId":
                                    book.CurrencyId = innerReader.ReadElementContentAsString(); break;
                                case "categoryId":
                                    book.CategoryId = innerReader.ReadElementContentAsInt(); break;
                                case "picture": ///////
                                    //book.Pictures = GetPictures(innerReader);
                                    break;
                                case "store":
                                    book.Store = innerReader.ReadElementContentAsBoolean(); break;
                                case "pickup":
                                    book.Pickup = innerReader.ReadElementContentAsBoolean(); break;
                                case "delivery":
                                    book.Delivery = innerReader.ReadElementContentAsBoolean(); break;
                                case "local_delivery_cost":
                                    book.LocalDeliveryCost = innerReader.ReadElementContentAsDouble(); break;
                                case "author":
                                    var authorName = innerReader.ReadElementContentAsString();
                                    book.Author = new Author() { AuthorName = authorName }; break;
                                case "name":
                                    book.Name = innerReader.ReadElementContentAsString(); break;
                                case "publisher":
                                    book.Publisher = new Publisher() { PublisherName = innerReader.ReadElementContentAsString() }; break;
                                case "series":
                                    book.Series = reader.ReadElementContentAsString(); break;
                                case "year":
                                    book.Year = new Year() { YearName = innerReader.ReadElementContentAsString() }; break;
                                case "ISBN":
                                    book.ISBN = innerReader.ReadElementContentAsString(); break;
                                case "language":
                                    book.Language = innerReader.ReadElementContentAsString(); break;
                                case "binding":
                                    book.Binding = innerReader.ReadElementContentAsString(); break;
                                case "page_extent":
                                    book.PageExtent = innerReader.ReadElementContentAsInt(); break;
                                case "description":
                                    book.Description = innerReader.ReadElementContentAsString(); break;
                                case "sales_notes":
                                    book.SalesNotes = innerReader.ReadElementContentAsString(); break;
                                case "barcode":
                                    book.Barcode = innerReader.ReadElementContentAsLong(); break;
                                case "dimensions":
                                    book.Dimensions = innerReader.ReadElementContentAsString(); break;
                                case "param":
                                    book.Package = GetPackage(innerReader); break;
                            }
                        }
                        #endregion
                        j++;//////
                        yield return book;

                    }
                }
            }
        }
        static void Main()
        {

            using (var repo = new Repository())
            {
                bookDictionary = new Dictionary<int,string>();
                categoryDictionary = new Dictionary<int, string>();
                authorDictionary = new Dictionary<string,Author>();
                publisherDictionary = new Dictionary<string, Publisher>();
                yearDictionary = new Dictionary<string, Year>();

                var watch = System.Diagnostics.Stopwatch.StartNew();
                int count = 0;
                repo.ConfigureRepository(false);
                                foreach (var book in Parse(GetBooks, @"D:\1132527(2).zip"))
                {           //освобождать контекст в цикле
                    if (book.Id == 0 && !categoryDictionary.ContainsKey(book.Category.Id)) //useless book.Id == 0 было
                    {
                        repo.AddCategory(book.Category);
                        categoryDictionary.Add(book.Category.Id, book.Category.Name);
                        Console.WriteLine("{0} {1}", book.Category.Id, book.Category.Name);
                    }
                    else
                    {

                        ConfigureReferences(book);
                       // repo.AddBook(book);
                        count++;
                          /* if (count == 1000)
                         {
                             repo.Save();
                              Console.WriteLine("--------------------------------------------------------------");
                             count = 0;
                         }        */
                        //  foreach(var pic in book.Pictures)
                       //    Console.WriteLine("{0} {1}", book.Id, book.Name);
                       // Console.WriteLine("----------");
                    }

                }              
                           //     repo.DeleteAllData();
               // repo.Save(); //!!!

                watch.Stop();
                var elapsedMs = watch.Elapsed;
                Console.WriteLine("time {0}",elapsedMs);
            }
        }
    }
}
