# Plugin.Maui.Pedometer

`Plugin.Maui.Pedometer` provides the ability to do this amazing thing in your .NET MAUI application.

## Getting Started

* Available on NuGet: <http://www.nuget.org/packages/Plugin.Maui.Pedometer> [![NuGet](https://img.shields.io/nuget/v/Plugin.Maui.Pedometer.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Maui.Pedometer/)

## API Usage

`Plugin.Maui.Pedometer` provides the `Feature` class that has a single property `Brightness` that you can get or set.

You can either use it as a static class, e.g.: `Feature.Default.Property = 1` or with dependency injection: `builder.Services.AddSingleton<IFeature>(Feature.Default);`