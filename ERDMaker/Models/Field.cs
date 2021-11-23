using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERDMaker.Models
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Decoration { get; set; }
        public ICollection<string> References { get; set; } = new List<string>();
    }
}
