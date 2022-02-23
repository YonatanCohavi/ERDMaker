using System;
using System.Collections.Generic;
using System.Linq;

namespace ERDMaker.Services
{
    public static class ExtensionMethods
    {
        public static List<T> FindAll<T>(this IEnumerable<T> enumeration, List<Predicate<T>> predicates)
        {
            return (from item in enumeration where predicates.All(p => p(item)) select item).ToList();
        }
    }
}
