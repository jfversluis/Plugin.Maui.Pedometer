namespace Plugin.Maui.Pedometer;

/// <summary>
/// TODO: Provide relevant comments for your APIs
/// </summary>
public interface IPedometer
{
	// TODO Define your plugin interface
	bool IsSupported { get; }

	bool IsMonitoring { get; }

	event EventHandler<PedometerData>? PedometerReadingChanged;

	void Start();

	void Stop();
}