using ERDMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERDMaker.Services
{
    public class DiagramBuilder
    {
        public static string StringifyTable(Table table)
        {
            var references = new List<string>();

            var lines = new List<string>
            {
                $"Table {table.Name} {{"
            };
            foreach (var field in table.Fields)
            {
                lines.Add($"\t{field.Name} {field.Type} {field.Decoration}");
                foreach (var reference in field.References)
                {
                    references.Add($"Ref: {table.Name}.{field.Name} > {reference}");
                }
            }
            lines.Add("}");
            lines.AddRange(references);
            lines.Add(Environment.NewLine);
            return string.Join(Environment.NewLine, lines);
        }

        internal static string StringifyTables(IEnumerable<Table> tables)
        {
            var tablesStrings = tables.Select(StringifyTable);
            return string.Join("", tablesStrings);
        }
    }
}
