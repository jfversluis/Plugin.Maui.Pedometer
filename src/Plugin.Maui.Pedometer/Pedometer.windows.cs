namespace Plugin.Maui.Pedometer;

partial class FeatureImplementation : IPedometer
{
	//Windows.Devices.Sensors.Pedometer pedometer;

	public FeatureImplementation()
	{
		//pedometer = new Windows.Devices.Sensors.Pedometer();
	}

	// TODO Implement your Windows specific code
	public bool IsSupported => !string.IsNullOrEmpty(Windows.Devices.Sensors.Pedometer.GetDeviceSelector());

	public bool IsMonitoring { get; private set; }

	public event EventHandler<PedometerData>? PedometerReadingChanged;

	public void Start()
	{
		//Windows.Devices.Sensors.Pedometer.
	}

	public void Stop()
	{
		throw new NotImplementedException();
	}
}