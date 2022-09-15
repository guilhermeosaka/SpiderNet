using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace SpiderNet.Utility;

public class Compiler
{
    public static async Task<T> CompileAsync<T>(string scriptName, string sourceCode, params object[] args)
    {
        var buildSource = new StringBuilder();
        
        buildSource.AppendLine(RemoveNamespace(sourceCode));
        buildSource.AppendLine($"return typeof({scriptName});");

        #region Import common namespaces
        var commonImports = new []
        {
            "System",
            "System.Console",
            "System.Collections.Generic",
            "System.Threading.Tasks",
        };
        #endregion

        var assembly = Assembly.GetEntryAssembly();
        var imports = commonImports.Union(GetAssemblyImports(assembly)).Distinct();
        var options = ScriptOptions.Default.WithReferences(assembly).WithImports(imports);
        
        var script = CSharpScript.Create(buildSource.ToString(), options);
        var scriptState = await script.RunAsync();
        var type = (Type)scriptState.ReturnValue;
        return (T)Activator.CreateInstance(type, args);
    }
    
    private static string RemoveNamespace(string code)
    {
        return Regex.Replace(Regex.Replace(code, @"namespace\s+[\w\.]+\s*;", "", RegexOptions.Singleline),
            @"namespace\s+[\w\.]+\s*{(.*)}",
            "$1", RegexOptions.Singleline);
    }

    private static IEnumerable<string> GetAssemblyImports(Assembly assembly) => assembly.GetTypes()
        .Where(_ => !string.IsNullOrEmpty(_.Namespace)).Select(_ => _.Namespace!).Distinct();
}
