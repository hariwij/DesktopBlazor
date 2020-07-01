using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBlazor.Windows
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread thread = new Thread(new ThreadStart(StartServer));
            thread.Start();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();
            //foreach (var prop in form.GetType().GetProperties())
            //{
            //    if (prop.DeclaringType.IsPublic)
            //    {
            //        Debug.WriteLine($"public {prop.PropertyType.Name} {prop.Name} " + "{ get; set; } = " +$"{prop.GetValue(form, null)};");
            //    }
            //}
            Application.Run(form);

        }
        static void StartServer()
        {
            Console.WriteLine(Environment.CurrentDirectory);
            //Blazor.Program.Main(new string[0]);
 
        }
    }
}
