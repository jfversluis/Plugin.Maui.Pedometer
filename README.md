![](nuget.png) 
# Plugin.Maui.Pedometer

`Plugin.Maui.Pedometer` provides the ability to read the device pedometer in your .NET MAUI application. This plugin currently only supports iOS and Android.

## Install Plugin

[![NuGet](https://img.shields.io/nuget/v/Plugin.Maui.Pedometer.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Maui.Pedometer/)

Available on [NuGet](http://www.nuget.org/packages/Plugin.Maui.Pedometer).

Install with the dotnet CLI: `dotnet add package Plugin.Maui.Pedometer`, or through the NuGet Package Manager in Visual Studio.

## API Usage

`Plugin.Maui.Pedometer` provides the `Pedometer` class that can be used to monitor the device pedometer and track the user's step count.

### Permissions

Before you can start reading pedometer values, you will need to request the proper permissions on each platform.

#### iOS

On iOS, add the `NSMotionUsageDescription` key to your `info.plist` file. When declared, the permission will be requested automatically at runtime.

```xml
<key>NSMotionUsageDescription</key>
<string>This app wants to track your pedometer readings</string>
```

#### Android

On Android with API 29+, declare the `ACTIVITY_RECOGNITION` permissions in your `AndroidManifest.xml` file. This should be placed in the `manifest` node. You can also add this through the visual editor in Visual Studio.

The runtime permission is automatically requested by the plugin when `Start()` is called.

```xml
<uses-permission android:name="android.permission.ACTIVITY_RECOGNITION" />
```

### Dependency Injection

You will first need to register the `Pedometer` with the `MauiAppBuilder` following the same pattern that the .NET MAUI Essentials libraries follow.

```csharp
builder.Services.AddSingleton(Pedometer.Default);
```

You can then enable your classes to depend on `IPedometer` as per the following example.

```csharp
public class StepCounterViewModel
{
    readonly IPedometer pedometer;

    public StepCounterViewModel(IPedometer pedometer)
    {
        this.pedometer = pedometer;
    }

    public void StartCounting()
    {
        pedometer.ReadingChanged += (sender, reading) =>
        {
            Console.WriteLine(reading.NumberOfSteps);
        };

        pedometer.Start();
    }
}
```

### Straight usage

Alternatively if you want to skip using the dependency injection approach you can use the `Pedometer.Default` property.

```csharp
public class StepCounterViewModel
{
    public void StartCounting()
    {
        pedometer.ReadingChanged += (sender, reading) =>
        {
            Console.WriteLine(reading.NumberOfSteps);
        };

        Pedometer.Default.Start();
    }
}
```

### Pedometer

Once you have created a `Pedometer` you can interact with it in the following ways:

#### Events

##### `ReadingChanged`

Occurs when pedometer reading changes.

#### Properties

##### `IsSupported`

Gets a value indicating whether reading the pedometer is supported on this device.

##### `IsMonitoring`

Gets a value indicating whether the pedometer is actively being monitored.

#### Methods

##### `Start()`

Start monitoring for changes to the pedometer.

##### `Stop()`

Stop monitoring for changes to the pedometer.
