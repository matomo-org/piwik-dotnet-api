#!/bin/bash

# http://redsymbol.net/articles/unofficial-bash-strict-mode/
set -euo pipefail
IFS=$'\n\t'

git pull

# bump vesion in AssemblyInfo.cs
sed -i "s/^\[assembly: AssemblyVersion[(]".*"[)]\]/[assembly: AssemblyVersion(\"$1\")]/" Piwik.Analytics/Properties/AssemblyInfo.cs

wrun dotnet build Piwik.Analytics/Piwik.Analytics.csproj -c Release

wrun nuget pack Piwik.Analytics/Piwik.Analytics.csproj -Prop Configuration=Release -Symbols

wrun nuget push Piwik.Analytics.$1.nupkg -Source nuget.org

git add Piwik.Analytics/Properties/AssemblyInfo.cs
git commit -m "chore: bump version to $1"
git tag -a $1 -m $1
git push --follow-tags
