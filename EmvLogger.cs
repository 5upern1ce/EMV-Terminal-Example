using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMV
{
    internal class EmvLogger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[EMV] {message}");
        }
    }
}
