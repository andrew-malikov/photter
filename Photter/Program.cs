using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Photter {
    class Program {
        static void Main(string[] args) {
            new Startup(new Application(args));
        }
    }
}
