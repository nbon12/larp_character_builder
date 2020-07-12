﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Core.Helpers
{
    public static class AssemblyHelpers
    {
        public static IEnumerable<Assembly> GetCurrentDomainAssemblies(string searchPattern = "Solution.*.dll")
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var assemblies = Directory.GetFiles(path, searchPattern).Select(x => {
                try
                {
                    return Assembly.LoadFrom(x);
                }
                catch
                {
                    return null;
                }
            }).Where(x => x != null);
            return assemblies;
        }
    }
}