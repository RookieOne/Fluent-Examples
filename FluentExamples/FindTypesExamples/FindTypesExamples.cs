using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentExamples.FindTypesExamples
{
    public class FindTypesExamples
    {
        public void Run()
        {
            Dictionary<Type, object> types;

            types = TypeFinder.FindTypesInAssemblyThatHaveAttribute(typeof (SerializableAttribute),
                                                                    Assembly.GetAssembly(typeof (FindTypesExamples)));

            Dictionary<Type, SerializableAttribute> types2;

            types2 =
                TypeFinder
                    .FindTypesInAssemblyThatHaveAttribute<SerializableAttribute>(
                    Assembly.GetAssembly(typeof (FindTypesExamples)));

            types2 = FindTypes
                .InAssembly(Assembly.GetAssembly(typeof (FindTypesExamples)))
                .ThatHaveAttribute<SerializableAttribute>();

            types2 = FindTypes
                .InAssemblyWithType<FindTypesExamples>()
                .ThatHaveAttribute<SerializableAttribute>();
        }
    }
}