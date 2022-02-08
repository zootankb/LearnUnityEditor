﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EditorFramework
{

    public static class TypeEx
    {
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly=>assembly.FullName.StartsWith("Assembly"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(self));                
        }

        public static IEnumerable<Type> GetSubTypesWithClassAttributeInAssemblies<TClassAttribute>(this Type self)where TClassAttribute: Attribute
        {
            return GetSubTypesInAssemblies(self).Where(type => type.GetCustomAttribute<TClassAttribute>() != null);
        }
    }
}
