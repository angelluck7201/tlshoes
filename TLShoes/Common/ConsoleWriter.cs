using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLShoes.Common
{
    public class ConsoleWriter
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        private const int ATTACH_PARENT_PROCESS = -1;

        private static StreamWriter _stdOutWriter;

        // this must be called early in the program
        public ConsoleWriter()
        {
          
        }

        public static void WriteLine(string line)
        {
            var stdout = Console.OpenStandardOutput();
            _stdOutWriter = new StreamWriter(stdout);
            _stdOutWriter.AutoFlush = true;

            AttachConsole(ATTACH_PARENT_PROCESS);
            _stdOutWriter.WriteLine(line);
            Console.WriteLine(line);
        }
    }
}
