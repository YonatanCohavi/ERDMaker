using System.Collections.Generic;
using System.Text;

namespace ERDMaker.Models
{
    public class OptionSet : SchemaDefinition
    {
        public string Name { get; set; }

        public ICollection<string> Values { get; } = new List<string>();

        public override string ToString()
        {
            var enumBuilder = new StringBuilder();

            enumBuilder.AppendLine($"Enum {this.Name}_enum {{");
            foreach (var value in this.Values)
            {
                enumBuilder.AppendLine($"\t\"{value}\"");
            }
            enumBuilder.AppendLine("}");

            return enumBuilder.ToString();
        }
    }
}