using Microsoft.CSharp;//sak.ide
using System; 
using System.Text;
using System.CodeDom.Compiler;//lua

public class ide
{
    string[] files = new string[]
    {
        Environment.CurrentDirectory+"\\utc.cs",
        Environment.CurrentDirectory+"\\wnd.cs ",
        Environment.CurrentDirectory+"\\main.cs ",
    };
   
    public static string make()
    {
        CSharpCodeProvider p = new CSharpCodeProvider();

        // 设置编译参数
        CompilerParameters options = new CompilerParameters();

        //加入引用的程序集
        options.ReferencedAssemblies.Add(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + "mscorlib.dll");
        options.ReferencedAssemblies.Add("System.dll"); 
        options.ReferencedAssemblies.Add("System.Windows.Forms.dll");
        options.ReferencedAssemblies.Add("System.Drawing.dll");
    
        options.GenerateExecutable = true;
        options.OutputAssembly = "main.exe";
        options.MainClass = "main";
        
        CompilerResults crt = p.CompileAssemblyFromFile(options, files);
        var error = new StringBuilder();

        if (crt.Errors.Count == 0)
        {
            error.AppendFormat("{0} compiled ok!", crt.CompiledAssembly.Location);
            error.AppendLine();
        }
        else
        {
            error.AppendLine("Complie Error:");
            foreach (CompilerError e in crt.Errors)
                error.AppendLine(e.ErrorText);
            error.AppendLine();
        }
        return error.ToString();
    }
}
