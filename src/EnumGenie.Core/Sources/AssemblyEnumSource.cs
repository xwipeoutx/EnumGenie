using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnumGenie.Sources
{
    public class AssemblyEnumSource : IEnumSource
    {
        private readonly Assembly _assembly;

        public AssemblyEnumSource(Assembly assembly)
        {
            _assembly = assembly;
        }

        public IEnumerable<Type> EnumTypes => _assembly.ExportedTypes.Where(t => t.IsEnum);
    }
}