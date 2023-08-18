namespace Plugin.Maui.Pedometer;

/// <summary>
/// Contains the data measured by the user's device pedometer.
/// </summary>
public class PedometerData
{
	/// <summary>
	/// Gets the timestamp for this sensor reading.
	/// </summary>
	public DateTimeOffset Timestamp { get; internal set; }

	/// <summary>
	/// Gets the total number of steps since the current measuring session started.
	/// </summary>
	public int NumberOfSteps { get; internal set; }
}
