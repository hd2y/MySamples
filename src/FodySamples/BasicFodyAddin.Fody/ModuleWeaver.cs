using System;
using System.Collections.Generic;
using System.Linq;
using Fody;
using Mono.Cecil;

namespace BasicFodyAddin.Fody
{
    public class ModuleWeaver : BaseModuleWeaver
    {
        List<TypeDefinition> allTypes;
        MethodReference getMethodFromHandle;

        public override void Execute()
        {
            allTypes = ModuleDefinition.GetTypes().ToList();
            var methodBaseType = FindTypeDefinition("MethodBase");

            getMethodFromHandle = methodBaseType.Methods
                .First(x => x.Name == "GetMethodFromHandle" &&
                            x.Parameters.Count == 1 &&
                            x.Parameters[0].ParameterType.Name == "RuntimeMethodHandle");
            getMethodFromHandle = ModuleDefinition.ImportReference(getMethodFromHandle);
            Instruction
        }

        public override IEnumerable<string> GetAssembliesForScanning()
        {
            yield return "System.Reflection";
        }
    }
}