using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
     public class Publisher
    {
       // [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } //PublisherId renamed primary key (you should reorder migration file)

        public string PublisherName { get; set; }

        public ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
