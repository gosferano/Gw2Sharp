# Gw2Sharp
[![GitHub CI](https://img.shields.io/github/workflow/status/Archomeda/Gw2Sharp/CI/master?label=CI&logo=GitHub)](https://github.com/Archomeda/Gw2Sharp/actions?workflow=CI)
[![NuGet](https://img.shields.io/nuget/v/Gw2Sharp.svg?label=NuGet&logo=nuget)](https://www.nuget.org/packages/Gw2Sharp)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Gw2Sharp.svg?label=Downloads&logo=nuget)](https://www.nuget.org/packages/Gw2Sharp)
[![Discord](https://img.shields.io/discord/384735285197537290.svg?label=Discord&logo=discord)](https://discord.gg/u2YDPea)  
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=Archomeda_Gw2Sharp&metric=coverage)](https://sonarcloud.io/dashboard?id=Archomeda_Gw2Sharp)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=Archomeda_Gw2Sharp&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=Archomeda_Gw2Sharp)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=Archomeda_Gw2Sharp&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=Archomeda_Gw2Sharp)

Gw2Sharp is a cross-platform .NET wrapper library for the [official Guild Wars 2 API](https://wiki.guildwars2.com/wiki/API) written in C#.

This library has been written to be as close as possible to the official API structure, with a few exceptions to make life easier.
*Make sure to read the [introductory guide](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html) to get started.*

## Supported services
The following services supported by Gw2Sharp:
- WebAPI v2 - [introduction](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html#web-api-v2), [endpoints](https://archomeda.github.io/Gw2Sharp/master/guides/endpoints.html)
- Render service - [introduction](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html#render-service)
- Mumble service - [introduction](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html#mumble)
- Chat links - [introduction](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html#chat-links)

## Requirements
This project targets .NET 5, .NET Core 3.1 and .NET Standard 2.0 for compatibility with older .NET Frameworks (check the [.NET Standard 2.0 compatibility table](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support))
It supports the C# 8.0 nullable reference types feature for your convenience, but it's not required when consuming the library.

## Installing
You can find the library on [NuGet](https://www.nuget.org/packages/Gw2Sharp/). Or, alternatively, you can install it by running `dotnet add package Gw2Sharp` in a console, or `Install-Package Gw2Sharp` in the package manager console.

## Usage
For basic usage, check out the [introductory guide](https://archomeda.github.io/Gw2Sharp/master/guides/introduction.html).  
You can find the other guides there as well to help you get started on the advanced usage of Gw2Sharp, such as caching and exception handling.

## Compiling
Visual Studio 2019 (16.10) or later is required, along with the [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) and [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1). 
If they aren't installed automatically for some reason, make sure to install them manually.

## Contributing
Contributing is always welcome, but please keep them in scope of this project.
I'm looking for all contributions that fixes bugs.
But regarding implementing new features, it's better to raise an issue first explaining why that new feature should be added.

If you're adding something new, do add some tests for it as well.
I'm aiming for this project to be as stable as possible.
