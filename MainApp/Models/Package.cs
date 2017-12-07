using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models
{
    [ComplexType]
    public class Package
    {
        public int Weight { get; set; } //double

        public int Width { get; set; } //double

        public int Height { get; set; } 

        public string Type { get; set; }

        public bool ColorIllustrations { get; set; }
    }
}
