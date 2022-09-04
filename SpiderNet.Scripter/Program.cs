// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using SpiderNet.Scripter;

Console.WriteLine("Hello, World!");

var bbScript = File.ReadAllText("/home/guilhermeosaka/projects/SpiderNet/SpiderNet.Scripter/Scripts/BB.cs");

bbScript = bbScript + "\n return typeof(BB);";

var options = ScriptOptions.Default.WithReferences(Assembly.GetExecutingAssembly());
var script = CSharpScript.Create(bbScript, options);
var type = (Type)script.RunAsync().Result.ReturnValue;
var runner = (IRunner)Activator.CreateInstance(type);
await runner.Run();
// await CSharpScript.RunAsync(bbFile);
// var x = await CSharpScript.EvaluateAsync(@"
//             using System;
//
//             public string TestMethod()
//             {
//                 return ""UÉ"";
//             }
//
//             return TestMethod();
//         ");
// Console.WriteLine(x);