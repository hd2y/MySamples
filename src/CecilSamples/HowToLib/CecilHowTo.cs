using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace HowToLib
{
    public static class CecilHowTo
    {
        public static AssemblyDefinition GetAssembly(string fileName)
        {
            return AssemblyDefinition.ReadAssembly(fileName);
        }

        public static AssemblyDefinition GetExecutingAssembly()
        {
            // https://github.com/dotnet/corert/issues/5467
            var assemblyName = Assembly.GetExecutingAssembly().Location;
            if (string.IsNullOrEmpty(assemblyName)) return null;
            Console.WriteLine(assemblyName);
            return GetAssembly(assemblyName);
        }

        public static IList<ModuleDefinition> GetExecutingModule()
        {
            return GetExecutingAssembly()?.Modules;
        }

        public static IList<ModuleDefinition> GetModule(this AssemblyDefinition assemblyDefinition)
        {
            return assemblyDefinition.Modules;
        }

        public static IList<TypeDefinition> GetTypes(ModuleDefinition module)
        {
            return module.Types;
        }
    }
}