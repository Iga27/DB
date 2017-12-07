using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
    public class Book : IDbEntry
    {
         [Key]
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public bool Available { get; set; }

        public string Type { get; set; }

        public string CurrencyId { get; set; }

        public bool Store { get; set; }

        public bool Pickup { get; set; }

        public string Series { get; set; }

        public string ISBN { get; set; }

        public string Dimensions { get; set; }

        public string Url { get; set; }

        public double Price { get; set; }

       // public string[] Pictures { get; set; }

        public bool Delivery { get; set; }

        public double LocalDeliveryCost { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }

        public string Binding { get; set; } 

        public int PageExtent { get; set; }

        public string Description { get; set; }

        public string SalesNotes { get; set; }

        public long Barcode { get; set; }

        public Package Package { get; set; } //????????[ComplexType]

        public ICollection<Picture> Pictures { get; set; }

        public Book()
        {
            Pictures = new List<Picture>();

        }

        public int ?  CategoryId { get; set; }  

        public Category Category { get; set; }


        public int  ? AuthorId { get; set; }  

        public Author Author { get; set; }

        public int  ? PublisherId { get; set; }  

        public Publisher Publisher { get; set; }

        public int ? YearId { get; set; }   

        public Year Year { get; set; }
    }
}
