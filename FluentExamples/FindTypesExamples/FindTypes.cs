using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentExamples.FindTypesExamples
{
    /// <summary>
    /// Finds Types in an Assembly
    /// </summary>
    public class FindTypes
    {
        private readonly Assembly _assembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindTypes"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        private FindTypes(Assembly assembly)
        {
            _assembly = assembly;
        }

        /// <summary>
        /// Creates a FindTypes instance passing in the given assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public static FindTypes InAssembly(Assembly assembly)
        {
            return new FindTypes(assembly);
        }

        /// <summary>
        /// Creates a FindTypes instance passing in the assembly with the type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static FindTypes InAssemblyWithType<T>()
        {
            return new FindTypes(Assembly.GetAssembly(typeof (T)));
        }

        /// <summary>
        /// Finds types in the assembly that have the passed in custom attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Dictionary<Type, T> ThatHaveAttribute<T>()
        {
            Dictionary<Type, T> result = new Dictionary<Type, T>();

            Type[] types = _assembly.GetTypes();

            foreach (Type type in types)
            {
                object[] attributes = type.GetCustomAttributes(typeof (T), false);
                if (attributes.Length > 0)
                    result.Add(type, (T) attributes[0]);
            }

            return result;
        }
    }
}