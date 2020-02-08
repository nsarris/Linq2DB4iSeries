var target = Argument("Target", "Default");
var configuration = Argument("Configuration", "Debug");
var basePath = "./build/" + Directory(configuration);
var packagePath =  "./nuget/";
var solutionFile = "./linq2db4iSeries.4.5-release.sln";
var iseriesProjFile ="./ISeriesProvider/LinqToDB.DataProvider.DB2iSeries.csproj";
var db2conProjFile ="./LinqToDB.DataProvider.DB2iSeries.DB2Connect/LinqToDB.DataProvider.DB2iSeries.DB2Connect.csproj";

Task("Clean")
    .Does(() => {
        CleanDirectory(basePath);
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() => {
		DotNetCoreClean(solutionFile);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() => {
        var settings = new DotNetCoreBuildSettings
        {
            Configuration = configuration,
			MSBuildSettings = new DotNetCoreMSBuildSettings()
				.WithProperty("TargetFrameworks", "net45")
        };

		DotNetCoreBuild(iseriesProjFile, settings);
		
		settings.MSBuildSettings.WithProperty("TargetFrameworks", "netstandard2.0");
        
		DotNetCoreBuild(db2conProjFile, settings);
    });

Task("Pack")
    .IsDependentOn("Build")
    .Does(() => {
        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = MakeAbsolute(Directory(packagePath)).FullPath,
            //VersionSuffix = suffix
			MSBuildSettings = new DotNetCoreMSBuildSettings()
				.WithProperty("TargetFrameworks", "net45")
        };
		
        DotNetCorePack(iseriesProjFile, settings);
		
		settings.MSBuildSettings.WithProperty("TargetFrameworks", "netstandard2.0");
		
        DotNetCorePack(db2conProjFile, settings);
    });

Task("Push")
    .IsDependentOn("Pack")
    .Does(() => {
        var packageFiles = GetFiles(packagePath + "*.nupkg")
            .Select(x => x.ToString());

        foreach(var file in packageFiles) {
            NuGetPush(file, new NuGetPushSettings {
                    //ApiKey = nugetApiKey,
                    //Source = nugetSource
                });
        }
    });

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);