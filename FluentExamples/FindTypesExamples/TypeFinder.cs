using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FluentExamples.FindTypesExamples
{
    /// <summary>
    /// Type Finder Helper Class
    /// </summary>
    public static class TypeFinder
    {
        /// <summary>
        /// Finds the types in assembly that have attribute T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public static Dictionary<Type, T> FindTypesInAssemblyThatHaveAttribute<T>(Assembly assembly)
        {
            Dictionary<Type, T> result = new Dictionary<Type, T>();

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                object[] attributes = type.GetCustomAttributes(typeof(T), false);
                if (attributes.Length > 0)
                    result.Add(type, (T)attributes[0]);
            }

            return result;
        }

        public static Dictionary<Type, object> FindTypesInAssemblyThatHaveAttribute(Type attributetype, Assembly assembly)
        {
            Dictionary<Type, object> result = new Dictionary<Type, object>();

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                object[] attributes = type.GetCustomAttributes(attributetype, false);
                if (attributes.Length > 0)
                    result.Add(type, attributes[0]);
            }

            return result;
        }
    }
}
