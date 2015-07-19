# Piwik C# Analytics API

This is the official C# implementation of the [Piwik Analytics API](http://piwik.org/docs/analytics-api/).

Check the [changelog](CHANGELOG.md) to know which Piwik Analytics APIs are supported.

## Usage

Two Visual Studio Solutions are provided :

  * [Piwik.Analytics.sln](Piwik.Analytics.sln) : Library project
  * [Piwik.Analytics.Samples.sln](Piwik.Analytics.Samples.sln) : Console Samples project

## Publishing the project to NuGet

### Requirements

* The process detailed in this section must be executed right before adding a
   release tag to git
* Publishing the project to NuGet must be done by a member of the Piwik team,
   holder of the private NuGet Key

### Steps

1. Add a new entry in [changelog](CHANGELOG.md)
2. Validate tests (requires #5)
3. Update and commit `AssemblyInfo.cs` with new version
4. Create git tag
5. Build the project using the Release solution configuration
6. Create NuGet packages using `nuget pack Piwik.Analytics\Piwik.Analytics.csproj -Prop Configuration=Release -Symbols`
7. Publish packages using `nuget push Piwik.Analytics.VERSION.nupkg`


# [License](LICENSE)
