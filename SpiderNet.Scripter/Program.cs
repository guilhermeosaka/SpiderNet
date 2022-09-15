// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using SpiderNet.Scripter;
using SpiderNet.Scripter.Scripts;
using SpiderNet.Utility;

Console.WriteLine("Hello, World!");

var bbScript = File.ReadAllText("/home/guilhermeosaka/projects/SpiderNet/SpiderNet.Scripter/Scripts/BB.cs");

var script = await Compiler.CompileAsync<IRunnable>("BB", bbScript);
try
{
    await script.Run();
} catch (Exception e)
{
    Console.WriteLine(e);
}




// bbScript = RemoveNamespace(bbScript);
// bbScript = bbScript + "\n return typeof(BB);";
//
// var options = ScriptOptions.Default.WithReferences(Assembly.GetExecutingAssembly())
//     .WithImports("System");
// var script = CSharpScript.Create(bbScript, options);
// var type = (Type)script.RunAsync().Result.ReturnValue;
// var runner = (IRunnable)Activator.CreateInstance(type);
// await runner.Run();
// // await CSharpScript.RunAsync(bbFile);
// // var x = await CSharpScript.EvaluateAsync(@"
// //             using System;
// //
// //             public string TestMethod()
// //             {
// //                 return ""UÉ"";
// //             }
// //
// //             return TestMethod();
// //         ");
// // Console.WriteLine(x);
//
// string RemoveNamespace(string code)
// {
//     code = Regex.Replace(Regex.Replace(code, @"namespace\s+[\w\.]+\s*;", "", RegexOptions.Singleline),
//         @"namespace\s+[\w\.]+\s*{(.*)}",
//         "$1", RegexOptions.Singleline);
//     return code;
// }