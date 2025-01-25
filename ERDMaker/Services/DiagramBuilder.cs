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
            var lines = new List<string>
            {
                $"Table {table.Name} {{"
            };
            foreach (var field in table.Fields)
            {
                var notes = field.References
                    .Select(x => $"ref: > {x}")
                    .Append(field.Decoration)
                    .Where(x => !string.IsNullOrEmpty(x));
                var notesString = notes.Any() ? $"[{string.Join(", ", notes)}]" : string.Empty;
                lines.Add($"\t{field.Name} {field.Type} {notesString}");
            }
            lines.Add("}");
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
