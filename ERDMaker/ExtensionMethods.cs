using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ERDMaker
{
    public static class ExtensionMethods
    {
        public static List<T> FindAll<T>(this IEnumerable<T> enumeration, List<Predicate<T>> predicates)
        {
            return (from item in enumeration where predicates.All(p => p(item)) select item).ToList();
        }
    }
}