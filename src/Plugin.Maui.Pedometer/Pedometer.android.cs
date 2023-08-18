using Android.Content;
using Android.Content.PM;
using Android.Hardware;
using Android.Runtime;
using AndroidX.Core.App;
using Microsoft.Maui.ApplicationModel;

namespace Plugin.Maui.Pedometer;

partial class FeatureImplementation : Java.Lang.Object, IPedometer, ISensorEventListener
{
	readonly SensorManager? sensorManager;
	readonly PackageManager? packageManager = Application.Context.PackageManager;

	public FeatureImplementation()
	{
		sensorManager = Application.Context.GetSystemService(Context.SensorService) as SensorManager;

		if (sensorManager is null)
		{
			throw new Exception("Initialization error: Android SensorManager could not be retrieved.");
		}

		if (packageManager is null)
		{
			throw new Exception("Initialization error: Android PackageManager could not be retrieved.");
		}
	}

	public bool IsSupported => packageManager!.HasSystemFeature(PackageManager.FeatureSensorStepCounter) &&
        packageManager.HasSystemFeature(PackageManager.FeatureSensorStepDetector);

	public bool IsMonitoring { get; private set; }

	public event EventHandler<PedometerData>? ReadingChanged;

	public void OnAccuracyChanged(Sensor? sensor, [GeneratedEnum] SensorStatus accuracy)
	{
	}

	public void OnSensorChanged(SensorEvent? e)
	{
		int count = 0;

		switch (e?.Sensor?.Type)
		{
			case SensorType.StepCounter:
				if (e?.Values?.Count > 0)
				{
					count = (int)e.Values[0];
				}
				else
				{
					count = 0;
				}
				break;
		}

		ReadingChanged?.Invoke(this, new()
		{
			NumberOfSteps = count
		});
	} 

	public void Start()
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}

		if (IsMonitoring)
		{
			return;
		}

		IsMonitoring = true;

		if (OperatingSystem.IsAndroidVersionAtLeast(29))
		{
			ActivityCompat.RequestPermissions(Platform.CurrentActivity,
				new[] { Android.Manifest.Permission.ActivityRecognition }, 1337);
		}

		sensorManager?.RegisterListener(this, sensorManager.GetDefaultSensor(SensorType.StepCounter), SensorDelay.Fastest);
	}

	public void Stop()
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}

		if (!IsMonitoring)
		{
			return;
		}

		sensorManager?.UnregisterListener(this);

		IsMonitoring = false;
	}
}