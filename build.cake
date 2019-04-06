var target = Argument("target", "Default");
var solution = Argument("solution", "Photter.sln");
var configuration = Argument("configuration", "Release");

Task("Restore").Does(() => {
   DotNetCoreRestore();
});

Task("Clean").Does(() => {
   DotNetCoreClean(solution);
});

Task("Build")
   .IsDependentOn("Restore")
   .IsDependentOn("Clean")
   .Does(() => {
      var settings = new DotNetCoreBuildSettings {
         Configuration = configuration
      };

      DotNetCoreBuild(solution, settings);
   });

Task("Test")
   .Does(() => {
         var projects = GetFiles("./*Test/*.csproj");
         
         var settings = new DotNetCoreTestSettings() {
            Configuration = configuration,
            NoBuild = true
         };
         
         foreach(var project in projects) 
            DotNetCoreTest(project.FullPath, settings);   
   });

Task("Default")
   .IsDependentOn("Build")
   .IsDependentOn("Test");

RunTarget(target);
