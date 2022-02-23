using System.Collections.Generic;

namespace ERDMaker.Models
{
    public class SchemaDefinition { }

    public class Table : SchemaDefinition
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public ICollection<Field> Fields { get; set; } = new List<Field>();
    }
}
