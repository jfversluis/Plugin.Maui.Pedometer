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
}
