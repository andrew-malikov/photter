using System;
using System.IO;
using Newtonsoft.Json;

namespace Photter.Core.Configs {
    public class JsonProjectProvider : IProjectProvider {
        private readonly string _pathToConfig;

        public JsonProjectProvider(string workDir) : this(
            workDir,
            "photter.config.json"
        ) { }

        public JsonProjectProvider(string workDir, string configFileName) {
            if (String.IsNullOrEmpty(workDir))
                throw new ArgumentException($"wrong the path to work directory: {workDir}");

            _pathToConfig = Path.Combine(workDir, configFileName);

            if (String.IsNullOrWhiteSpace(_pathToConfig))
                throw new ArgumentException($"wrong the path to config file: {_pathToConfig}");
        }

        public AppConfig Provide() {
            var serializedProject = "";

            if (!File.Exists(_pathToConfig))
                throw new FileNotFoundException($"can't find the project config: {_pathToConfig}");

            try {
                serializedProject = File.ReadAllText(_pathToConfig);
            }
            catch (IOException) {
                throw new IOException($"Can't open the config file: {_pathToConfig}");
            }

            return JsonConvert.DeserializeObject<AppConfig>(serializedProject);
        }
    }
}