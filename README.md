# Piwik C# Analytics API

This is the official C# implementation of the [Piwik Analytics API](http://piwik.org/docs/analytics-api/).

Check the [changelog](CHANGELOG.md) to know which Piwik Analytics APIs are supported.

## Usage

Two Visual Studio Solutions are provided :

  * [Piwik.Analytics.sln](Piwik.Analytics.sln) : Library project
  * [Piwik.Analytics.Samples.sln](Piwik.Analytics.Samples.sln) : Console Samples project

## Publishing the project to NuGet

### Requirements

* Must be executed before adding a release tag to git
* Must be done by a member of the Piwik team, holder of the private NuGet Key
* [WSL](https://msdn.microsoft.com/en-us/commandline/wsl/about)
* [.NET Core command-line (CLI) tools](https://github.com/dotnet/cli)
* [cbwin](https://github.com/xilun/cbwin)
* [nuget](https://dist.nuget.org/index.html)

### How-to

#### Using the command line

```bash
./publish.sh NEW_VERSION_NUMBER
```

#### Using [hotshell](http://julienmoumne.github.io/hotshell)

Enter the interactive menu with `hs` then activate `publish new version` menu entry.

# [License](LICENSE)
