using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

namespace HowToSamples
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public static class CecilHowTo
    {
        public static AssemblyDefinition GetAssembly(string fileName)
        {
            return AssemblyDefinition.ReadAssembly(fileName);
        }
        
        public static AssemblyDefinition GetExecutingAssembly()
        {
            var assemblyName = Assembly.GetExecutingAssembly().Location;
            return GetAssembly(assemblyName);
        }

        public static IList<ModuleDefinition> GetExecutingModule()
        {
            return GetExecutingAssembly().Modules;
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