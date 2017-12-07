using MainApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MainApp.Service
{
    public class Parser : IDisposable
    {
        XmlReader reader;
        XmlReaderSettings settings;

        Dictionary<string, Author> authorDictionary=new Dictionary<string, Author>();
        Dictionary<string, Publisher> publisherDictionary= new Dictionary<string, Publisher>();
        Dictionary<string, Year> yearDictionary= new Dictionary<string, Year>();


        public Parser()
        {
            settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.MaxCharactersFromEntities = 1024;
        }


        static int ParseToInt(string stringToParse)
        {
            return String.IsNullOrEmpty(stringToParse) ? 0 : Int32.Parse(stringToParse);
        }


        IEnumerable<IDbEntry> Parse(Func<XmlReader,IEnumerable<Category>> getCategories, Func<XmlReader,
                                                                  IEnumerable<Book>> getBooks, string path)
        {
            using (FileStream zipToOpen = new FileStream(path, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read, true))
            using (Stream fs = archive.Entries.FirstOrDefault().Open())
            using (reader = XmlReader.Create(fs, settings))  //that's why I cannot devide by 2: Parse books and Parse categories
            {
                foreach (var i in getCategories(reader))
                    yield return i;
                foreach (var i in getBooks(reader))
                    yield return i;
            }
        }



        #region MyRegion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        static IEnumerable<Category> GetCategories(XmlReader reader) //вроде работает
        {
            reader.ReadToFollowing("category");
            while (reader.Name != "offer")
            {
                var category = new Category();
                category.Id = ParseToInt(reader.GetAttribute("id"));
                if (category.Id != 0)
                {
                    category.ParentId = ParseToInt(reader.GetAttribute("parentId"));
                    reader.Read();
                    category.Name = reader.Value;
                    yield return category;
                }
                reader.Read();
            }
        } 
        #endregion

        static IEnumerable<Book> GetBooks(XmlReader reader)
        {
            int j = 0;
            reader.ReadToFollowing("offer");
            do
            {
                var book = new Book();
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
                        switch (innerReader.Name) //в отдельный метод
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
                           /* case "param":
                                book.Package = GetPackage(innerReader); break;*/
                        }
                    }
                    #endregion
                    j++;//////
                    yield return book;

                }

            } while (reader.ReadToFollowing("offer") && j < 50);
        }



        Package GetPackage(XmlReader reader)  
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
                        package.Type = reader.Value; break;
                    case "Цветные иллюстрации":
                        reader.Read();
                        package.ColorIllustrations = reader.Value == "Да" ? true : false; break;
                }
                reader.ReadToNextSibling("param");
            }
            return package;
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}
