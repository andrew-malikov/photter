using System;

namespace Photter.Configs {
    public class LaunchConfig {
        public readonly string[] Args;

        public readonly string WorkDir;

        public LaunchConfig(string[] args) : this(args, Environment.CurrentDirectory) { }

        private LaunchConfig(string[] args, string workDir) {
            Args = args;
            WorkDir = workDir;
        }
    }
}