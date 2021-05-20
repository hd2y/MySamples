## 对比

程序运行输入如下:

```text
--> Diff between Mono.Cecil.AssemblyDefinition System.Reflection.Assembly 
Properties: Name+ FullName MetadataToken+ Modules MainModule+ EntryPoint HasCustomAttributes+ CustomAttributes HasSecurityDeclarations+ SecurityDeclara
tions+ DefinedTypes- ExportedTypes- CodeBase- ImageRuntimeVersion- IsDynamic- Location- ReflectionOnly- IsCollectible- IsFullyTrusted- EscapedCodeBase-
 ManifestModule- GlobalAssemblyCache- HostContext- SecurityRuleSet- 
Methods: Dispose+ CreateAssembly+ ReadAssembly+ Write+ ToString GetType Equals GetHashCode Load- LoadWithPartialName- GetExecutingAssembly- GetCallingA
ssembly- GetTypes- GetExportedTypes- GetForwardedTypes- GetManifestResourceInfo- GetManifestResourceNames- GetManifestResourceStream- GetName- IsDefine
d- GetCustomAttributesData- GetCustomAttributes- CreateInstance- GetModule- GetModules- GetLoadedModules- GetReferencedAssemblies- GetSatelliteAssembly
- GetFile- GetFiles- GetObjectData- CreateQualifiedName- GetAssembly- GetEntryAssembly- LoadFile- LoadFrom- UnsafeLoadFrom- LoadModule- ReflectionOnlyL
oad- ReflectionOnlyLoadFrom- 
--> Diff between System.Reflection.AssemblyName 
Properties: Hash+ Name Culture+ Version Attributes+ HasPublicKey+ IsSideBySideCompatible+ IsRetargetable+ IsWindowsRuntime+ PublicKey+ PublicKeyToken+
MetadataScopeType+ FullName HashAlgorithm MetadataToken+ CultureInfo- CultureName- CodeBase- EscapedCodeBase- ProcessorArchitecture- ContentType- Flags
- VersionCompatibility- KeyPair- 
Methods: ToString GetType Equals GetHashCode Clone- GetAssemblyName- GetPublicKey- SetPublicKey- GetPublicKeyToken- SetPublicKeyToken- GetObjectData- O
nDeserialization- ReferenceMatchesDefinition- 

--> Diff between Mono.Cecil.ModuleDefinition System.Reflection.Module 
Properties: IsMain+ Kind+ MetadataKind+ Runtime+ RuntimeVersion+ Architecture+ Attributes+ Characteristics+ FullyQualifiedName FileName+ Mvid+ HasSymbo
ls+ SymbolReader+ MetadataScopeType+ Assembly AssemblyResolver+ MetadataResolver+ TypeSystem+ HasAssemblyReferences+ AssemblyReferences+ HasModuleRefer
ences+ ModuleReferences+ HasResources+ Resources+ HasCustomAttributes+ CustomAttributes HasTypes+ Types+ HasExportedTypes+ ExportedTypes+ EntryPoint+ H
asCustomDebugInformations+ CustomDebugInformations+ HasDebugHeader+ Name MetadataToken MDStreamVersion- ModuleVersionId- ScopeName- ModuleHandle- 
Methods: Import+ ImportReference+ LookupToken+ GetDebugHeader+ CreateModule+ ReadSymbols+ ReadModule+ Write+ Dispose+ HasTypeReference+ TryGetTypeRefer
ence+ GetTypeReferences+ GetMemberReferences+ GetCustomAttributes GetType GetTypes ToString Equals GetHashCode GetPEKind- IsResource- IsDefined- GetCus
tomAttributesData- GetMethod- GetMethods- GetField- GetFields- FindTypes- ResolveField- ResolveMember- ResolveMethod- ResolveSignature- ResolveString-
ResolveType- GetObjectData- 

--> Diff between Mono.Cecil.TypeDefinition System.Type 
Properties: Attributes BaseType Name HasLayoutInfo+ PackingSize+ ClassSize+ HasInterfaces+ Interfaces+ HasNestedTypes+ NestedTypes+ HasMethods+ Methods
+ HasFields+ Fields+ HasEvents+ Events+ HasProperties+ Properties+ HasSecurityDeclarations+ SecurityDeclarations+ HasCustomAttributes+ CustomAttributes
 HasGenericParameters+ GenericParameters+ IsNotPublic IsPublic IsNestedPublic IsNestedPrivate IsNestedFamily IsNestedAssembly IsNestedFamilyAndAssembly
+ IsNestedFamilyOrAssembly+ IsAutoLayout IsSequentialLayout+ IsExplicitLayout IsClass IsInterface IsAbstract IsSealed IsSpecialName IsImport IsSerializ
able IsWindowsRuntime+ IsAnsiClass IsUnicodeClass IsAutoClass IsBeforeFieldInit+ IsRuntimeSpecialName+ HasSecurity+ IsEnum IsValueType IsPrimitive Meta
dataType+ IsDefinition+ DeclaringType Namespace Module Scope+ IsNested FullName IsByReference+ IsPointer IsSentinel+ IsArray IsGenericParameter IsGener
icInstance+ IsRequiredModifier+ IsOptionalModifier+ IsPinned+ IsFunctionPointer+ MetadataToken IsWindowsRuntimeProjection+ ContainsGenericParameter+ Me
mberType- AssemblyQualifiedName- Assembly- DeclaringMethod- ReflectedType- UnderlyingSystemType- IsTypeDefinition- IsByRef- IsConstructedGenericType- I
sGenericTypeParameter- IsGenericMethodParameter- IsGenericType- IsGenericTypeDefinition- IsSZArray- IsVariableBoundArray- IsByRefLike- HasElementType-
GenericTypeArguments- GenericParameterPosition- GenericParameterAttributes- IsNestedFamANDAssem- IsNestedFamORAssem- IsLayoutSequential- IsCOMObject- I
sContextful- IsMarshalByRef- IsSignatureType- IsSecurityCritical- IsSecuritySafeCritical- IsSecurityTransparent- StructLayoutAttribute- TypeInitializer
- TypeHandle- GUID- DefaultBinder- ContainsGenericParameters- IsVisible- IsCollectible- 
Methods: Resolve+ GetElementType ToString GetType Equals GetHashCode GetEvents- GetField- GetFields- GetMember- GetMembers- GetMethod- GetMethods- GetN
estedType- GetNestedTypes- GetProperty- GetProperties- GetDefaultMembers- GetTypeHandle- GetTypeArray- GetTypeCode- GetTypeFromCLSID- GetTypeFromProgID
- InvokeMember- GetInterface- GetInterfaces- GetInterfaceMap- IsInstanceOfType- IsEquivalentTo- GetEnumUnderlyingType- GetEnumValues- MakeArrayType- Ma
keByRefType- MakeGenericType- MakePointerType- MakeGenericSignatureType- MakeGenericMethodParameter- ReflectionOnlyGetType- IsEnumDefined- GetEnumName-
 GetEnumNames- FindInterfaces- FindMembers- IsSubclassOf- IsAssignableFrom- GetTypeFromHandle- GetArrayRank- GetGenericTypeDefinition- GetGenericArgume
nts- GetGenericParameterConstraints- IsAssignableTo- GetConstructor- GetConstructors- GetEvent- HasSameMetadataDefinitionAs- IsDefined- GetCustomAttrib
utes- GetCustomAttributesData- 

--> Diff between Mono.Cecil.PropertyDefinition System.Reflection.PropertyInfo 
Properties: Attributes HasThis+ HasCustomAttributes+ CustomAttributes GetMethod SetMethod HasOtherMethods+ OtherMethods+ HasParameters+ Parameters+ Has
Constant+ Constant+ IsSpecialName IsRuntimeSpecialName+ HasDefault+ DeclaringType IsDefinition+ FullName+ PropertyType Name MetadataToken IsWindowsRunt
imeProjection+ Module ContainsGenericParameter+ MemberType- CanRead- CanWrite- ReflectedType- IsCollectible- 
Methods: Resolve+ ToString GetType Equals GetHashCode GetIndexParameters- GetAccessors- GetGetMethod- GetSetMethod- GetOptionalCustomModifiers- GetRequ
iredCustomModifiers- GetValue- GetConstantValue- GetRawConstantValue- SetValue- HasSameMetadataDefinitionAs- IsDefined- GetCustomAttributes- GetCustomA
ttributesData- 

--> Diff between Mono.Cecil.FieldDefinition System.Reflection.FieldInfo 
Properties: HasLayoutInfo+ Offset+ RVA+ InitialValue+ Attributes HasConstant+ Constant+ HasCustomAttributes+ CustomAttributes HasMarshalInfo+ MarshalIn
fo+ IsCompilerControlled+ IsPrivate IsFamilyAndAssembly IsAssembly IsFamily IsFamilyOrAssembly IsPublic IsStatic IsInitOnly IsLiteral IsNotSerialized I
sSpecialName IsPInvokeImpl+ IsRuntimeSpecialName+ HasDefault+ IsDefinition+ DeclaringType FieldType FullName+ ContainsGenericParameter+ Name MetadataTo
ken IsWindowsRuntimeProjection+ Module MemberType- IsPinvokeImpl- IsSecurityCritical- IsSecuritySafeCritical- IsSecurityTransparent- FieldHandle- Refle
ctedType- IsCollectible- 
Methods: Resolve+ ToString GetType Equals GetHashCode GetFieldFromHandle- GetValue- SetValue- SetValueDirect- GetValueDirect- GetRawConstantValue- GetO
ptionalCustomModifiers- GetRequiredCustomModifiers- HasSameMetadataDefinitionAs- IsDefined- GetCustomAttributes- GetCustomAttributesData- 

--> Diff between Mono.Cecil.MethodDefinition System.Reflection.MethodInfo 
Properties: Name Attributes ImplAttributes+ SemanticsAttributes+ HasSecurityDeclarations+ SecurityDeclarations+ HasCustomAttributes+ CustomAttributes R
VA+ HasBody+ Body+ DebugInformation+ HasPInvokeInfo+ PInvokeInfo+ HasOverrides+ Overrides+ HasGenericParameters+ GenericParameters+ HasCustomDebugInfor
mations+ CustomDebugInformations+ IsCompilerControlled+ IsPrivate IsFamilyAndAssembly IsAssembly IsFamily IsFamilyOrAssembly IsPublic IsStatic IsFinal
IsVirtual IsHideBySig IsReuseSlot+ IsNewSlot+ IsCheckAccessOnOverride+ IsAbstract IsSpecialName IsPInvokeImpl+ IsUnmanagedExport+ IsRuntimeSpecialName+
 HasSecurity+ IsIL+ IsNative+ IsRuntime+ IsUnmanaged+ IsManaged+ IsForwardRef+ IsPreserveSig+ IsInternalCall+ IsSynchronized+ NoInlining+ NoOptimizatio
n+ AggressiveInlining+ IsSetter+ IsGetter+ IsOther+ IsAddOn+ IsRemoveOn+ IsFire+ DeclaringType IsConstructor IsDefinition+ HasThis+ ExplicitThis+ Calli
ngConvention HasParameters+ Parameters+ ReturnType MethodReturnType+ FullName+ IsGenericInstance+ ContainsGenericParameter+ MetadataToken IsWindowsRunt
imeProjection+ Module MemberType- ReturnParameter- ReturnTypeCustomAttributes- MethodImplementationFlags- IsConstructedGenericMethod- IsGenericMethod-
IsGenericMethodDefinition- ContainsGenericParameters- MethodHandle- IsSecurityCritical- IsSecuritySafeCritical- IsSecurityTransparent- ReflectedType- I
sCollectible- 
Methods: Resolve+ GetElementMethod+ ToString GetType Equals GetHashCode GetGenericArguments- GetGenericMethodDefinition- MakeGenericMethod- GetBaseDefi
nition- CreateDelegate- GetParameters- GetMethodImplementationFlags- GetMethodBody- Invoke- HasSameMetadataDefinitionAs- IsDefined- GetCustomAttributes
- GetCustomAttributesData- 

--> Diff between Mono.Cecil.ParameterDefinition System.Reflection.ParameterInfo 
Properties: Attributes Method+ Sequence+ HasConstant+ Constant+ HasCustomAttributes+ CustomAttributes HasMarshalInfo+ MarshalInfo+ IsIn IsOut IsLcid Is
ReturnValue+ IsOptional HasDefault+ HasFieldMarshal+ Name Index+ ParameterType MetadataToken Member- Position- IsRetval- DefaultValue- RawDefaultValue-
 HasDefaultValue- 
Methods: Resolve+ ToString GetType Equals GetHashCode IsDefined- GetCustomAttributesData- GetCustomAttributes- GetOptionalCustomModifiers- GetRequiredC
ustomModifiers- GetRealObject- 

--> Diff between Mono.Cecil.EventDefinition System.Reflection.EventInfo 
Properties: Attributes AddMethod InvokeMethod+ RemoveMethod HasOtherMethods+ OtherMethods+ HasCustomAttributes+ CustomAttributes IsSpecialName IsRuntim
eSpecialName+ DeclaringType IsDefinition+ EventType+ FullName+ Name MetadataToken IsWindowsRuntimeProjection+ Module ContainsGenericParameter+ MemberTy
pe- RaiseMethod- IsMulticast- EventHandlerType- ReflectedType- IsCollectible- 
Methods: Resolve+ ToString GetType Equals GetHashCode GetOtherMethods- GetAddMethod- GetRemoveMethod- GetRaiseMethod- AddEventHandler- RemoveEventHandl
er- HasSameMetadataDefinitionAs- IsDefined- GetCustomAttributes- GetCustomAttributesData- 

```