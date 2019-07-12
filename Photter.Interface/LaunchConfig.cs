using System;

namespace Photter.Interface {
    public class LaunchConfig {
        public readonly string[] Args;

        public readonly string WorkDir;

        public LaunchConfig(string[] args) : this(args, Environment.CurrentDirectory) { }

        public LaunchConfig(string[] args, string workDir) {
            Args = args;
            WorkDir = workDir;
        }
    }
}