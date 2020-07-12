﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace Core.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }
    }

    public static class GenericCollectionExtensions
    {
        public static bool IsAny<T>(this T item, params T[] items)
        {
            return items.Any(x => x.Equals(item));
        }

        public static IEnumerable ForEach<T>(this IEnumerable list, Action<T> action)
        {
            foreach (T item in list) action(item);
            return list;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list) action(item);
            return list;
        }

        /// <summary>
        /// Select every nth item in the list
        /// </summary>
        public static IEnumerable<T> SelectEvery<T>(this IEnumerable<T> list, int nth)
        {
            return list.Where((x, i) => ((i + 1) % nth) == 0);
        }

        /// <summary>
        /// Group every n number of rows
        /// </summary>
        public static IEnumerable<IGrouping<int, T>> GroupEvery<T>(this IEnumerable<T> list, int n)
        {
            return list.Select((item, index) => new {item, index})
                .GroupBy(x => x.index / n, x => x.item);
        }

        public static bool IsDefault<T>(this T value) where T : struct
        {
            bool isDefault = value.Equals(default(T));

            return isDefault;
        }


        public static IEnumerable<T> Add<T>(this IEnumerable<T> enumerable, T value)
        {
            foreach (var current in enumerable)
            {
                yield return current;
            }

            yield return value;
        }

        /// <summary>
        /// Converts an object to a dictionary where keys are property names and values are
        /// property values.
        /// See https://stackoverflow.com/a/23225770
        /// </summary>
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }

        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null)
                ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
                AddPropertyToDictionary<T>(property, source, dictionary);
            return dictionary;
        }

        private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source,
            Dictionary<string, T> dictionary)
        {
            object value = property.GetValue(source);
            if (IsOfType<T>(value))
                dictionary.Add(property.Name, (T) value);
        }

        private static bool IsOfType<T>(object value)
        {
            return value is T;
        }

        private static void ThrowExceptionWhenSourceArgumentIsNull()
        {
            throw new ArgumentNullException("source",
                "Unable to convert object to a dictionary. The source object is null.");
        }
    }
}