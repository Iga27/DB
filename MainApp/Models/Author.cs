using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class Author
    {
      //  [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }  //AuthorId


       // [Column(TypeName = "NVARCHAR")]
       // [StringLength(300)]
       // [Index]   check on big data   and switch
        public string AuthorName { get; set; }
         
        public ICollection<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}
