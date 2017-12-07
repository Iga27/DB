using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public int  BookId { get; set; }  //removed "?" because it interrupted cascade deleting

        public virtual Book Book { get; set; }

        public string Url { get; set; }
    }
}
