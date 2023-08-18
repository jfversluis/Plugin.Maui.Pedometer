using Microsoft.Maui.ApplicationModel;

namespace Plugin.Maui.Pedometer;

/// <summary>
/// Monitor changes to the device pedometer.
/// </summary>
public interface IPedometer
{
	/// <summary>
	/// Gets a value indicating whether reading the pedometer is supported on this device.
	/// </summary>
	bool IsSupported { get; }

	/// <summary>
	/// Gets a value indicating whether the pedometer is actively being monitored.
	/// </summary>
	bool IsMonitoring { get; }

	/// <summary>
	/// Occurs when pedometer reading changes.
	/// </summary>
	event EventHandler<PedometerData>? ReadingChanged;

	/// <summary>
	/// Start monitoring for changes to the pedometer.
	/// </summary>
	/// <remarks>
	/// Will throw <see cref="FeatureNotSupportedException"/> if not supported on device.
	/// </remarks>
	void Start();

	/// <summary>
	/// Stop monitoring for changes to the pedometer.
	/// </summary>
	void Stop();
}