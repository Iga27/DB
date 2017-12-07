using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
     
    public class Year
    {
      //  [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string YearName { get; set; }

        public ICollection<Book> Books { get; set; }

        public Year()
        {
            Books = new List<Book>();
        }
    }
}
