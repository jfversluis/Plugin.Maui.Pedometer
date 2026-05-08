# $ Copilot InstructionsREPO 

## Project Overview

This is a .NET MAUI plugin that provides the ability to read the device pedometer (step counter). It targets Android, iOS (no Windows/macOS).

### Architecture

Event-based sensor: `IPedometer` with Start/Stop and `ReadingChanged` event.
Data model: `PedometerData` with step count.

- Android: SensorManager TYPE_STEP_COUNTER
- iOS: CoreMotion CMPedometer
- No Windows/macOS support

## Code Conventions

### Namespace
All code uses: `Plugin.Maui.Pedometer`

### File Naming
- `*.shared. Cross-platform codecs` 
- `*.android. Androidcs` 
- `*.macios. iOS/macOScs` 
- `*.windows. Windowscs` 
- `*.net. Generic .NET fallbackcs` 

### Standards
- File-scoped namespaces
- `camelCase` for private fields, `PascalCase` for public
- XML docs required on all public APIs
- Null-conditional operators for platform interop

## Building

```bash
dotnet build src/Plugin.Maui.Pedometer/Plugin.Maui.Pedometer.csproj -c Release
```

## When Making Changes
1. Ensure the plugin builds on all target platforms
2. If adding public API, update the interface
3. Implement on all supported platforms
4. Update sample app and README
