using System;
using System.IO;

using Newtonsoft.Json;

namespace Photter.Configs {
    public class JsonProjectProvider : IProjectProvider {
        private readonly string _pathToConfig;

        public JsonProjectProvider(LaunchConfig config) : this(
            config.WorkDir,
            "photter.config.json"
        ) { }

        private JsonProjectProvider(string workDir, string configFileName) {
            if (String.IsNullOrEmpty(workDir))
                throw new ArgumentException($"wrong the path to work directory: {workDir}");

            _pathToConfig = Path.Combine(workDir, configFileName);

            if (String.IsNullOrWhiteSpace(_pathToConfig))
                throw new ArgumentException($"wrong the path to config file: {_pathToConfig}");
        }

        public ProjectConfig Provide() {
            var serializedProject = "";

            if (!File.Exists(_pathToConfig))
                throw new FileNotFoundException($"can't find the project config: {_pathToConfig}");

            try {
                serializedProject = File.ReadAllText(_pathToConfig);
            }
            catch (IOException) {
                throw new IOException($"Can't open the config file: {_pathToConfig}");
            }

            return JsonConvert.DeserializeObject<ProjectConfig>(serializedProject);
        }
    }
}