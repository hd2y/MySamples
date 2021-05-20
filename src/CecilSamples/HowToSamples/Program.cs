using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using static HowToLib.CommonTool;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable HeapView.BoxingAllocation
namespace HowToSamples
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            ShowDiff(typeof(AssemblyDefinition), typeof(Assembly));
            ShowDiff(typeof(AssemblyNameDefinition), typeof(AssemblyName));
            ShowDiff(typeof(ModuleDefinition), typeof(Module));
            ShowDiff(typeof(TypeDefinition), typeof(Type));
            ShowDiff(typeof(PropertyDefinition), typeof(PropertyInfo));
            ShowDiff(typeof(FieldDefinition), typeof(FieldInfo));
            ShowDiff(typeof(MethodDefinition), typeof(MethodInfo));
            ShowDiff(typeof(ParameterDefinition), typeof(ParameterInfo));
            ShowDiff(typeof(EventDefinition), typeof(EventInfo));
        }
    }
}