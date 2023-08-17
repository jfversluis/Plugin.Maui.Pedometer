namespace Plugin.Maui.Pedometer;

partial class FeatureImplementation : IPedometer
{
	// TODO Implement your Android specific code
	public bool IsSupported => false;

	public bool IsMonitoring => throw new NotImplementedException();

	public event EventHandler<PedometerData>? PedometerReadingChanged;

	public void Start()
	{
		throw new NotImplementedException();
	}

	public void Stop()
	{
		throw new NotImplementedException();
	}
}