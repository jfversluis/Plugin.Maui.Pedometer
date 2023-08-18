namespace Plugin.Maui.Pedometer;

partial class FeatureImplementation : IPedometer
{
	// TODO Implement your .NET specific code.
	// This usually is a placeholder as .NET MAUI apps typically don't run on .NET generic targets unless through unit tests and such
	public bool IsSupported => false;

	public bool IsMonitoring => throw new NotImplementedException();

	public event EventHandler<PedometerData>? ReadingChanged;

	public void Start()
	{
		throw new NotImplementedException();
	}

	public void Stop()
	{
		throw new NotImplementedException();
	}
}