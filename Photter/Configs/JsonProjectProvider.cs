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
                throw new NotImplementedException();

            _pathToConfig = Path.Combine(workDir, configFileName);

            if (String.IsNullOrWhiteSpace(_pathToConfig))
                throw new NotImplementedException();
        }

        public ProjectConfig Provide() {
            var serializedProject = "";

            try {
                serializedProject = File.ReadAllText(_pathToConfig);
            }
            catch (ArgumentException) {
                throw new NotImplementedException();
            }
            catch (PathTooLongException) {
                throw new NotImplementedException();
            }
            catch (DirectoryNotFoundException) {
                throw new NotImplementedException();
            }
            catch (IOException) {
                throw new NotImplementedException();
            }
            catch (UnauthorizedAccessException) {
                throw new NotImplementedException();
            }

            return JsonConvert.DeserializeObject<ProjectConfig>(serializedProject);
        }
    }
}