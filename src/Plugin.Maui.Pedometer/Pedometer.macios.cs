using CoreMotion;
using Microsoft.Maui.ApplicationModel;

namespace Plugin.Maui.Pedometer;

partial class FeatureImplementation : IPedometer
{
	readonly CMPedometer pedometer;

	public FeatureImplementation()
	{
		pedometer = new();
	}

	// TODO Implement your macOS/iOS specific code
	public bool IsSupported => CMPedometer.IsStepCountingAvailable;

	public bool IsMonitoring { get; private set; }

	public event EventHandler<PedometerData>? PedometerReadingChanged;

	public void Start()
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}

		if (IsMonitoring)
		{

		}

		pedometer.StartPedometerUpdates(NSDate.Now, (data, error) =>
		{
			PedometerReadingChanged?.Invoke(this, new()
			{
				NumberOfSteps = (int)data.NumberOfSteps,
			});
		});
	}

	public void Stop()
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}

		if (!IsMonitoring)
		{

		}

		pedometer.StopPedometerUpdates();
	}
}