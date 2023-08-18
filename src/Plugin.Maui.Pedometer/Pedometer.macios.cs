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

	public bool IsSupported => CMPedometer.IsStepCountingAvailable;

	public bool IsMonitoring { get; private set; }

	public event EventHandler<PedometerData>? ReadingChanged;

	public void Start()
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}

		if (IsMonitoring)
		{

		}

		IsMonitoring = true;

		pedometer.StartPedometerUpdates(NSDate.Now, (data, error) =>
		{
			ReadingChanged?.Invoke(this, new()
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

		IsMonitoring = false;
	}
}