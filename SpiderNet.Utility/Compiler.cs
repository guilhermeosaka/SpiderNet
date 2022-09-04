using System.IO.Enumeration;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace SpiderNet.Utility;

public class Compiler
{
    public async Task<T?> CompileAsync<T>(string source)
    {
        return await CSharpScript.EvaluateAsync<T>(source);
    }
}
