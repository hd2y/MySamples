using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable HeapView.BoxingAllocation
namespace HowToSamples
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var execAssembly = CecilHowTo.GetExecutingAssembly();
            Console.WriteLine("========== {0} ==========", nameof(AssemblyDefinition));
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name), execAssembly.Name);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.FullName), execAssembly.FullName);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.HasCustomAttributes), execAssembly.HasCustomAttributes);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.HasSecurityDeclarations),
                execAssembly.HasSecurityDeclarations);

            Console.WriteLine("========== {0} ==========", nameof(AssemblyNameDefinition));
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.Culture), execAssembly.Name.Culture);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.Name), execAssembly.Name.Name);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.Version), execAssembly.Name.Version);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.FullName), execAssembly.Name.FullName);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.IsRetargetable), execAssembly.Name.IsRetargetable);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.HasPublicKey), execAssembly.Name.HasPublicKey);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.IsWindowsRuntime),
                execAssembly.Name.IsWindowsRuntime);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.MetadataScopeType),
                execAssembly.Name.MetadataScopeType);
            Console.WriteLine("{0}: {1}", nameof(execAssembly.Name.IsSideBySideCompatible),
                execAssembly.Name.IsSideBySideCompatible);


            Console.WriteLine("========== {0} ==========", nameof(ModuleDefinition));
            if (!execAssembly.Modules.Any()) Console.WriteLine("无");
            foreach (var module in execAssembly.Modules)
            {
                Console.WriteLine("{0}: {1}", nameof(module.Name), module.Name);
                Console.WriteLine("{0}: {1}", nameof(module.FileName), module.FileName);
                Console.WriteLine("{0}: {1}", nameof(module.Runtime), module.Runtime);
                Console.WriteLine("{0}: {1}", nameof(module.Kind), module.Kind);
                Console.WriteLine("{0}: {1}", nameof(module.MetadataKind), module.MetadataKind);
                Console.WriteLine("{0}: {1}", nameof(module.HasCustomAttributes), module.HasCustomAttributes);
                Console.WriteLine("{0}: {1}", nameof(module.HasResources), module.HasResources);
                Console.WriteLine("{0}: {1}", nameof(module.HasSymbols), module.HasSymbols);
                Console.WriteLine("{0}: {1}", nameof(module.HasAssemblyReferences), module.HasAssemblyReferences);
                Console.WriteLine("{0}: {1}", nameof(module.HasExportedTypes), module.HasExportedTypes);
                Console.WriteLine("{0}: {1}", nameof(module.HasModuleReferences), module.HasModuleReferences);
                Console.WriteLine("{0}: {1}", nameof(module.HasDebugHeader), module.HasDebugHeader);
                Console.WriteLine("{0}: {1}", nameof(module.Mvid), module.Mvid);
                Console.WriteLine("{0}: {1}", nameof(module.IsMain), module.IsMain);
                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("========== {0} ==========", nameof(TypeDefinition));
            if (!execAssembly.Modules.SelectMany(a => a.Types).Any()) Console.WriteLine("无");
            foreach (var module in execAssembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    Console.WriteLine("{0}: {1}", nameof(type.Name), type.Name);
                    Console.WriteLine("{0}: {1}", nameof(type.Namespace), type.Namespace);
                    Console.WriteLine("{0}: {1}", nameof(type.FullName), type.FullName);
                    Console.WriteLine("{0}: {1}", nameof(type.ClassSize), type.ClassSize);
                    Console.WriteLine("{0}: {1}", nameof(type.HasEvents), type.HasEvents);
                    Console.WriteLine("{0}: {1}", nameof(type.HasCustomAttributes), type.HasCustomAttributes);
                    Console.WriteLine("{0}: {1}", nameof(type.HasSecurityDeclarations), type.HasSecurityDeclarations);
                    Console.WriteLine("{0}: {1}", nameof(type.HasFields), type.HasFields);
                    Console.WriteLine("{0}: {1}", nameof(type.HasInterfaces), type.HasInterfaces);
                    Console.WriteLine("{0}: {1}", nameof(type.HasMethods), type.HasMethods);
                    Console.WriteLine("{0}: {1}", nameof(type.HasProperties), type.HasProperties);
                    Console.WriteLine("{0}: {1}", nameof(type.HasSecurity), type.HasSecurity);
                    Console.WriteLine("{0}: {1}", nameof(type.HasGenericParameters), type.HasGenericParameters);
                    Console.WriteLine("{0}: {1}", nameof(type.HasLayoutInfo), type.HasLayoutInfo);
                    Console.WriteLine("{0}: {1}", nameof(type.HasNestedTypes), type.HasNestedTypes);
                    Console.WriteLine("{0}: {1}", nameof(type.IsAbstract), type.IsAbstract);
                    Console.WriteLine("{0}: {1}", nameof(type.IsClass), type.IsClass);
                    Console.WriteLine("{0}: {1}", nameof(type.IsDefinition), type.IsDefinition);
                    Console.WriteLine("{0}: {1}", nameof(type.IsEnum), type.IsEnum);
                    Console.WriteLine("{0}: {1}", nameof(type.IsImport), type.IsImport);
                    Console.WriteLine("{0}: {1}", nameof(type.IsInterface), type.IsInterface);
                    Console.WriteLine("{0}: {1}", nameof(type.IsPrimitive), type.IsPrimitive);
                    Console.WriteLine("{0}: {1}", nameof(type.IsPublic), type.IsPublic);
                    Console.WriteLine("{0}: {1}", nameof(type.IsSealed), type.IsSealed);
                    Console.WriteLine("{0}: {1}", nameof(type.IsSerializable), type.IsSerializable);
                    Console.WriteLine("{0}: {1}", nameof(type.IsAnsiClass), type.IsAnsiClass);
                    Console.WriteLine("{0}: {1}", nameof(type.IsAutoClass), type.IsAutoClass);
                    Console.WriteLine("{0}: {1}", nameof(type.IsAutoLayout), type.IsAutoLayout);
                    Console.WriteLine("{0}: {1}", nameof(type.IsExplicitLayout), type.IsExplicitLayout);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNestedAssembly), type.IsNestedAssembly);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNotPublic), type.IsNotPublic);
                    Console.WriteLine("{0}: {1}", nameof(type.IsSequentialLayout), type.IsSequentialLayout);
                    Console.WriteLine("{0}: {1}", nameof(type.IsSpecialName), type.IsSpecialName);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNestedFamily), type.IsNestedFamily);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNestedPrivate), type.IsNestedPrivate);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNestedPublic), type.IsNestedPublic);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNestedFamilyAndAssembly),
                        type.IsNestedFamilyAndAssembly);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNestedFamilyOrAssembly), type.IsNestedFamilyOrAssembly);
                    Console.WriteLine("{0}: {1}", nameof(type.IsNested), type.IsNested);
                    Console.WriteLine("{0}: {1}", nameof(type.IsUnicodeClass), type.IsUnicodeClass);
                    Console.WriteLine("{0}: {1}", nameof(type.IsValueType), type.IsValueType);
                    Console.WriteLine("{0}: {1}", nameof(type.IsWindowsRuntime), type.IsWindowsRuntime);
                    Console.WriteLine("{0}: {1}", nameof(type.IsBeforeFieldInit), type.IsBeforeFieldInit);
                    Console.WriteLine("{0}: {1}", nameof(type.IsRuntimeSpecialName), type.IsRuntimeSpecialName);
                    Console.WriteLine("{0}: {1}", nameof(type.IsArray), type.IsArray);
                    Console.WriteLine("{0}: {1}", nameof(type.IsPinned), type.IsPinned);
                    Console.WriteLine("{0}: {1}", nameof(type.IsPointer), type.IsPointer);
                    Console.WriteLine("{0}: {1}", nameof(type.IsSentinel), type.IsSentinel);
                    Console.WriteLine("{0}: {1}", nameof(type.IsByReference), type.IsByReference);
                    Console.WriteLine("{0}: {1}", nameof(type.IsFunctionPointer), type.IsFunctionPointer);
                    Console.WriteLine("{0}: {1}", nameof(type.IsGenericInstance), type.IsGenericInstance);
                    Console.WriteLine("{0}: {1}", nameof(type.IsGenericParameter), type.IsGenericParameter);
                    Console.WriteLine("{0}: {1}", nameof(type.IsOptionalModifier), type.IsOptionalModifier);
                    Console.WriteLine("{0}: {1}", nameof(type.IsRequiredModifier), type.IsRequiredModifier);
                    Console.WriteLine("{0}: {1}", nameof(type.IsWindowsRuntimeProjection),
                        type.IsWindowsRuntimeProjection);
                    Console.WriteLine("-------------------------");
                }
            }

            Console.WriteLine("========== {0} ==========", nameof(PropertyDefinition));
            if (!execAssembly.Modules.SelectMany(a => a.Types.SelectMany(b => b.Properties)).Any())
                Console.WriteLine("无");
            foreach (var module in execAssembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    foreach (var property in type.Properties)
                    {
                        Console.WriteLine("{0}: {1}", nameof(property.Name), property.Name);
                        Console.WriteLine("{0}: {1}", nameof(property.FullName), property.FullName);
                        Console.WriteLine("{0}: {1}", nameof(property.IsSpecialName), property.IsSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(property.IsRuntimeSpecialName),
                            property.IsRuntimeSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(property.IsDefinition), property.IsDefinition);
                        Console.WriteLine("{0}: {1}", nameof(property.IsWindowsRuntimeProjection),
                            property.IsWindowsRuntimeProjection);
                        Console.WriteLine("{0}: {1}", nameof(property.HasConstant), property.HasConstant);
                        Console.WriteLine("{0}: {1}", nameof(property.HasCustomAttributes),
                            property.HasCustomAttributes);
                        Console.WriteLine("{0}: {1}", nameof(property.HasDefault), property.HasDefault);
                        Console.WriteLine("{0}: {1}", nameof(property.HasParameters), property.HasParameters);
                        Console.WriteLine("{0}: {1}", nameof(property.HasThis), property.HasThis);
                        Console.WriteLine("{0}: {1}", nameof(property.HasOtherMethods), property.HasOtherMethods);
                        Console.WriteLine("{0}: {1}", nameof(property.ContainsGenericParameter),
                            property.ContainsGenericParameter);
                        Console.WriteLine("-------------------------");
                    }
                }
            }

            Console.WriteLine("========== {0} ==========", nameof(FieldDefinition));
            if (!execAssembly.Modules.SelectMany(a => a.Types.SelectMany(b => b.Fields)).Any())
                Console.WriteLine("无");
            foreach (var module in execAssembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    foreach (var field in type.Fields)
                    {
                        Console.WriteLine("{0}: {1}", nameof(field.Name), field.Name);
                        Console.WriteLine("{0}: {1}", nameof(field.FullName), field.FullName);
                        Console.WriteLine("{0}: {1}", nameof(field.IsSpecialName), field.IsSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(field.IsRuntimeSpecialName), field.IsRuntimeSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(field.IsDefinition), field.IsDefinition);
                        Console.WriteLine("{0}: {1}", nameof(field.IsWindowsRuntimeProjection),
                            field.IsWindowsRuntimeProjection);
                        Console.WriteLine("{0}: {1}", nameof(field.HasConstant), field.HasConstant);
                        Console.WriteLine("{0}: {1}", nameof(field.HasCustomAttributes), field.HasCustomAttributes);
                        Console.WriteLine("{0}: {1}", nameof(field.HasDefault), field.HasDefault);
                        Console.WriteLine("{0}: {1}", nameof(field.ContainsGenericParameter),
                            field.ContainsGenericParameter);
                        Console.WriteLine("{0}: {1}", nameof(field.Offset), field.Offset);
                        Console.WriteLine("{0}: {1}", nameof(field.IsAssembly), field.IsAssembly);
                        Console.WriteLine("{0}: {1}", nameof(field.IsFamily), field.IsFamily);
                        Console.WriteLine("{0}: {1}", nameof(field.IsLiteral), field.IsLiteral);
                        Console.WriteLine("{0}: {1}", nameof(field.IsPrivate), field.IsPrivate);
                        Console.WriteLine("{0}: {1}", nameof(field.IsPublic), field.IsPublic);
                        Console.WriteLine("{0}: {1}", nameof(field.IsStatic), field.IsStatic);
                        Console.WriteLine("{0}: {1}", nameof(field.IsCompilerControlled), field.IsCompilerControlled);
                        Console.WriteLine("{0}: {1}", nameof(field.IsFamilyAndAssembly), field.IsFamilyAndAssembly);
                        Console.WriteLine("{0}: {1}", nameof(field.IsPInvokeImpl), field.IsPInvokeImpl);
                        Console.WriteLine("{0}: {1}", nameof(field.IsInitOnly), field.IsInitOnly);
                        Console.WriteLine("{0}: {1}", nameof(field.IsNotSerialized), field.IsNotSerialized);
                        Console.WriteLine("{0}: {1}", nameof(field.HasLayoutInfo), field.HasLayoutInfo);
                        Console.WriteLine("{0}: {1}", nameof(field.HasMarshalInfo), field.HasMarshalInfo);
                        Console.WriteLine("{0}: {1}", nameof(field.RVA), field.RVA);
                        Console.WriteLine("-------------------------");
                    }
                }
            }

            Console.WriteLine("========== {0} ==========", nameof(MethodDefinition));
            if (!execAssembly.Modules.SelectMany(a => a.Types.SelectMany(b => b.Methods)).Any())
                Console.WriteLine("无");
            foreach (var module in execAssembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    foreach (var method in type.Methods)
                    {
                        Console.WriteLine("{0}: {1}", nameof(method.Name), method.Name);
                        Console.WriteLine("{0}: {1}", nameof(method.FullName), method.FullName);
                        Console.WriteLine("{0}: {1}", nameof(method.IsSpecialName), method.IsSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(method.IsRuntimeSpecialName), method.IsRuntimeSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(method.IsDefinition), method.IsDefinition);
                        Console.WriteLine("{0}: {1}", nameof(method.IsWindowsRuntimeProjection),
                            method.IsWindowsRuntimeProjection);
                        Console.WriteLine("{0}: {1}", nameof(method.HasCustomAttributes), method.HasCustomAttributes);
                        Console.WriteLine("{0}: {1}", nameof(method.HasParameters), method.HasParameters);
                        Console.WriteLine("{0}: {1}", nameof(method.HasThis), method.HasThis);
                        Console.WriteLine("{0}: {1}", nameof(method.ContainsGenericParameter),
                            method.ContainsGenericParameter);
                        Console.WriteLine("{0}: {1}", nameof(method.AggressiveInlining), method.AggressiveInlining);
                        Console.WriteLine("{0}: {1}", nameof(method.HasBody), method.HasBody);
                        Console.WriteLine("{0}: {1}", nameof(method.HasOverrides), method.HasOverrides);
                        Console.WriteLine("{0}: {1}", nameof(method.HasSecurity), method.HasSecurity);
                        Console.WriteLine("{0}: {1}", nameof(method.HasSecurityDeclarations),
                            method.HasSecurityDeclarations);
                        Console.WriteLine("{0}: {1}", nameof(method.HasGenericParameters), method.HasGenericParameters);
                        Console.WriteLine("{0}: {1}", nameof(method.HasCustomDebugInformations),
                            method.HasCustomDebugInformations);
                        Console.WriteLine("{0}: {1}", nameof(method.HasPInvokeInfo), method.HasPInvokeInfo);
                        Console.WriteLine("{0}: {1}", nameof(method.IsAssembly), method.IsAssembly);
                        Console.WriteLine("{0}: {1}", nameof(method.IsStatic), method.IsStatic);
                        Console.WriteLine("{0}: {1}", nameof(method.IsCheckAccessOnOverride),
                            method.IsCheckAccessOnOverride);
                        Console.WriteLine("{0}: {1}", nameof(method.IsPInvokeImpl), method.IsPInvokeImpl);
                        Console.WriteLine("{0}: {1}", nameof(method.IsHideBySig), method.IsHideBySig);
                        Console.WriteLine("{0}: {1}", nameof(method.IsFamilyOrAssembly), method.IsFamilyOrAssembly);
                        Console.WriteLine("{0}: {1}", nameof(method.IsFamilyAndAssembly), method.IsFamilyAndAssembly);
                        Console.WriteLine("{0}: {1}", nameof(method.IsUnmanagedExport), method.IsUnmanagedExport);
                        Console.WriteLine("{0}: {1}", nameof(method.IsReuseSlot), method.IsReuseSlot);
                        Console.WriteLine("{0}: {1}", nameof(method.IsRemoveOn), method.IsRemoveOn);
                        Console.WriteLine("{0}: {1}", nameof(method.IsPreserveSig), method.IsPreserveSig);
                        Console.WriteLine("{0}: {1}", nameof(method.IsNewSlot), method.IsNewSlot);
                        Console.WriteLine("{0}: {1}", nameof(method.IsInternalCall), method.IsInternalCall);
                        Console.WriteLine("{0}: {1}", nameof(method.IsIL), method.IsIL);
                        Console.WriteLine("{0}: {1}", nameof(method.IsForwardRef), method.IsForwardRef);
                        Console.WriteLine("{0}: {1}", nameof(method.IsCompilerControlled), method.IsCompilerControlled);
                        Console.WriteLine("{0}: {1}", nameof(method.IsAddOn), method.IsAddOn);
                        Console.WriteLine("{0}: {1}", nameof(method.IsVirtual), method.IsVirtual);
                        Console.WriteLine("{0}: {1}", nameof(method.IsUnmanaged), method.IsUnmanaged);
                        Console.WriteLine("{0}: {1}", nameof(method.IsSynchronized), method.IsSynchronized);
                        Console.WriteLine("{0}: {1}", nameof(method.IsSetter), method.IsSetter);
                        Console.WriteLine("{0}: {1}", nameof(method.IsRuntime), method.IsRuntime);
                        Console.WriteLine("{0}: {1}", nameof(method.IsPrivate), method.IsPrivate);
                        Console.WriteLine("{0}: {1}", nameof(method.IsOther), method.IsOther);
                        Console.WriteLine("{0}: {1}", nameof(method.IsNative), method.IsNative);
                        Console.WriteLine("{0}: {1}", nameof(method.IsManaged), method.IsManaged);
                        Console.WriteLine("{0}: {1}", nameof(method.IsGetter), method.IsGetter);
                        Console.WriteLine("{0}: {1}", nameof(method.IsFire), method.IsFire);
                        Console.WriteLine("{0}: {1}", nameof(method.IsFinal), method.IsFinal);
                        Console.WriteLine("{0}: {1}", nameof(method.IsFamily), method.IsFamily);
                        Console.WriteLine("{0}: {1}", nameof(method.IsConstructor), method.IsConstructor);
                        Console.WriteLine("{0}: {1}", nameof(method.IsGenericInstance), method.IsGenericInstance);
                        Console.WriteLine("{0}: {1}", nameof(method.ExplicitThis), method.ExplicitThis);
                        Console.WriteLine("{0}: {1}", nameof(method.RVA), method.RVA);
                        Console.WriteLine("{0}: {1}", nameof(method.NoOptimization), method.NoOptimization);
                        Console.WriteLine("{0}: {1}", nameof(method.NoInlining), method.NoInlining);
                        Console.WriteLine("-------------------------");
                    }
                }
            }

            Console.WriteLine("========== {0} ==========", nameof(ParameterDefinition));
            if (!execAssembly.Modules
                .SelectMany(a => a.Types.SelectMany(b => b.Properties.SelectMany(c => c.Parameters))).Any())
                Console.WriteLine("无");
            foreach (var module in execAssembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    foreach (var method in type.Methods)
                    {
                        foreach (var parameter in method.Parameters)
                        {
                            Console.WriteLine("{0}: {1}", nameof(parameter.Name), parameter.Name);
                            Console.WriteLine("{0}: {1}", nameof(parameter.Sequence), parameter.Sequence);
                            Console.WriteLine("{0}: {1}", nameof(parameter.Index), parameter.Index);
                            Console.WriteLine("{0}: {1}", nameof(parameter.IsIn), parameter.IsIn);
                            Console.WriteLine("{0}: {1}", nameof(parameter.IsOut), parameter.IsOut);
                            Console.WriteLine("{0}: {1}", nameof(parameter.IsReturnValue), parameter.IsReturnValue);
                            Console.WriteLine("{0}: {1}", nameof(parameter.HasConstant), parameter.HasConstant);
                            Console.WriteLine("{0}: {1}", nameof(parameter.HasCustomAttributes), parameter.HasCustomAttributes);
                            Console.WriteLine("{0}: {1}", nameof(parameter.HasDefault), parameter.HasDefault);
                            Console.WriteLine("{0}: {1}", nameof(parameter.HasMarshalInfo), parameter.HasMarshalInfo);
                            Console.WriteLine("{0}: {1}", nameof(parameter.HasFieldMarshal), parameter.HasFieldMarshal);
                            Console.WriteLine("{0}: {1}", nameof(parameter.IsLcid), parameter.IsLcid);
                            Console.WriteLine("{0}: {1}", nameof(parameter.IsOptional), parameter.IsOptional);
                            Console.WriteLine("-------------------------");
                        }
                    }
                }
            }

            Console.WriteLine("========== {0} ==========", nameof(EventDefinition));
            if (!execAssembly.Modules.SelectMany(a => a.Types.SelectMany(b => b.Events)).Any())
                Console.WriteLine("无");
            foreach (var module in execAssembly.Modules)
            {
                foreach (var type in module.Types)
                {
                    foreach (var @event in type.Events)
                    {
                        Console.WriteLine("{0}: {1}", nameof(@event.Name), @event.Name);
                        Console.WriteLine("{0}: {1}", nameof(@event.FullName), @event.FullName);
                        Console.WriteLine("{0}: {1}", nameof(@event.IsSpecialName), @event.IsSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(@event.IsRuntimeSpecialName), @event.IsRuntimeSpecialName);
                        Console.WriteLine("{0}: {1}", nameof(@event.IsDefinition), @event.IsDefinition);
                        Console.WriteLine("{0}: {1}", nameof(@event.IsWindowsRuntimeProjection),
                            @event.IsWindowsRuntimeProjection);
                        Console.WriteLine("{0}: {1}", nameof(@event.HasCustomAttributes), @event.HasCustomAttributes);
                        Console.WriteLine("{0}: {1}", nameof(@event.HasOtherMethods), @event.HasOtherMethods);
                        Console.WriteLine("{0}: {1}", nameof(@event.ContainsGenericParameter),
                            @event.ContainsGenericParameter);
                        Console.WriteLine("-------------------------");
                    }
                }
            }
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