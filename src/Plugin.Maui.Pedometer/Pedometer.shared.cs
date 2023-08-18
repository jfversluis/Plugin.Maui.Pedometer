using Microsoft.Maui.ApplicationModel;

namespace Plugin.Maui.Pedometer;

public static class Pedometer
{
	static IPedometer? defaultImplementation;

	/// <summary>
	/// Provides the default implementation for static usage of this API.
	/// </summary>
	public static IPedometer Default =>
		defaultImplementation ??= new FeatureImplementation();

	internal static void SetDefault(IPedometer? implementation) =>
		defaultImplementation = implementation;

	/// <summary>
	/// Occurs when pedometer reading changes.
	/// </summary>
	public static event EventHandler<PedometerData> ReadingChanged
	{
		add => Default.ReadingChanged += value;
		remove => Default.ReadingChanged -= value;
	}

	/// <summary>
	/// Gets a value indicating whether reading the pedometer is supported on this device.
	/// </summary>
	public static bool IsSupported => Default.IsSupported;

	/// <summary>
	/// Gets a value indicating whether the pedometer is actively being monitored.
	/// </summary>
	public static bool IsMonitoring
		=> Default.IsMonitoring;

	/// <summary>
	/// Start monitoring for changes to the pedometer.
	/// </summary>
	/// <remarks>
	/// Will throw <see cref="FeatureNotSupportedException"/> if not supported on device.
	/// </remarks>
	public static void Start()
		=> Default.Start();

	/// <summary>
	/// Stop monitoring for changes to the pedometer.
	/// </summary>
	public static void Stop()
		=> Default.Stop();
}
