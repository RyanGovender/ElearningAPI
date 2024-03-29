﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ElearningProjectRepository.Implementation.Global
{
    public class Variance
    {
        public string Property { get; set; }
        public object CurrentObject { get; set; }
        public object NewObject { get; set; }

    }

    public static class ObjectCompare
    {
        private static StringBuilder _stringBuilder;

        static ObjectCompare()
        {
            _stringBuilder = new StringBuilder();
        }
        public static StringBuilder CompareObjects<T>(T currentObject, T newObject) where T : class
        {
            _stringBuilder.Clear();
            var fieldInfo = GetAllFields(currentObject.GetType());
            foreach (var item in fieldInfo)
            {
                var v = new Variance();
                v.Property = item.Name;
                v.CurrentObject = item.GetValue(currentObject);
                v.NewObject = item.GetValue(newObject);
                if (!v.CurrentObject.Equals(v.NewObject))
                {
                    _stringBuilder.AppendLine($"{GetPropertyName(v.Property)} - {v.CurrentObject} >>>> {v.NewObject} \n");
                }
            }

            return _stringBuilder;
        }

        private static IEnumerable<FieldInfo> GetAllFields(Type t)
        {
            if (t == null)
                return Enumerable.Empty<FieldInfo>();

            BindingFlags flags = BindingFlags.Public | 
                                 BindingFlags.NonPublic |
                                 BindingFlags.Static | 
                                 BindingFlags.Instance |
                                 BindingFlags.DeclaredOnly;
            return t.GetFields(flags).Concat(GetAllFields(t.BaseType));
        }

        private static string GetPropertyName(string fullPropertyName)
        {
            return fullPropertyName != null && fullPropertyName.Contains('>') ? fullPropertyName.Split('>')[0].Substring(1) : "";
        }
    }
}
