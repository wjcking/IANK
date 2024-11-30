using Microsoft.CSharp;
using System; 
using System.Text;
using System.CodeDom.Compiler;
public struct ccskie
{

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
        //   options.ReferencedAssemblies.Add("System.IO.Directory");
        //是否生成可执行文件，否则就是内存中
        options.GenerateExecutable = true;
        // CompilerOptions 参考地址:https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/compiler-options/addmodule-compiler-option
        //    options.CompilerOptions = "-t:winexe";              //非控制台应用程序
        //    options.CompilerOptions += " -win32icon:index.ico"; //设置图标
        options.OutputAssembly = "main.exe";          //输出exe的名称
        options.MainClass = "main";          //主运行类

        //循环加入资源文件,貌似不支持文件夹,因此多个文件可以自己压缩为zip再加入
        //foreach (var file in this.listBox1.Items)
        //{
        //    options.EmbeddedResources.Add(file.ToString());
        //}

        // 开始编译
        string[] files = new string[]
        {
                    Environment.CurrentDirectory+"\\utc.cs",
                    Environment.CurrentDirectory+"\\wnd.cs ",
                    Environment.CurrentDirectory+"\\main.cs ",

        };
        CompilerResults cr = p.CompileAssemblyFromFile(options, files);
        var error = new StringBuilder();
        // 显示编译信息
        if (cr.Errors.Count == 0)
        {
            error.AppendFormat("{0} compiled ok!", cr.CompiledAssembly.Location);
            error.AppendLine("成功");
        }
        else
        {
            error.AppendLine("Complie Error:");
            foreach (CompilerError e in cr.Errors)
                error.AppendLine(e.ErrorText);
            error.AppendLine("失败");
        }


        return error.ToString();
    }
}
