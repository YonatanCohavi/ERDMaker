using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERDMaker.Models
{
    public class Table
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public ICollection<Field> Fields { get; set; } = new List<Field>();
    }
}
