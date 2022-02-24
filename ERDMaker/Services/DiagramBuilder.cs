using ERDMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERDMaker.Services
{
    public static class DiagramBuilder
    {
        internal static string StringifySchema(IEnumerable<SchemaDefinition> definitions)
        {
            var definitionStrings = definitions.Select(StringifyElement);
            return string.Join(Environment.NewLine, definitionStrings);
        }

        private static string StringifyElement(SchemaDefinition definition)
        {
            switch (definition)
            {
                case OptionSet p:
                    return StringifyOptionSet(p);
                case Table t:
                    return StringifyTable(t);
            }

            throw new ArgumentOutOfRangeException(definition.GetType().Name);
        }

        private static string StringifyOptionSet(OptionSet optionSet)
        {
            var optionSetBuilder = new StringBuilder();

            optionSetBuilder.AppendLine($"Enum {optionSet.Name}_enum {{");
            foreach (var value in optionSet.Values)
            {
                optionSetBuilder.AppendLine($"\t\"{value}\"");
            }
            optionSetBuilder.AppendLine("}");

            return optionSetBuilder.ToString();
        }

        private static string StringifyTable(Table table)
        {
            var tableBuilder = new StringBuilder();

            tableBuilder.AppendLine($"Table {table.Name} {{");
            foreach (var field in table.Fields)
            {
                tableBuilder.AppendLine($"\t{field.Name} {field.Type} {field.Decoration}".TrimEnd());
            }
            tableBuilder.AppendLine("}");

            return tableBuilder.ToString();
        }
    }
}
