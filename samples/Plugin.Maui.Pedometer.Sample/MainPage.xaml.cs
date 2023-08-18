namespace Plugin.Maui.Pedometer.Sample;

public partial class MainPage : ContentPage
{
	readonly IPedometer pedometer;

	public MainPage(IPedometer pedometer)
	{
		InitializeComponent();
		
		this.pedometer = pedometer;
		pedometer.ReadingChanged += Pedometer_ReadingChanged;

		IsSupported.Text = $"Is supported: {pedometer.IsSupported}";
		StartStopMonitoring.IsEnabled = pedometer.IsSupported;
	}

	void Pedometer_ReadingChanged(object sender, PedometerData e)
	{
		MainThread.InvokeOnMainThreadAsync(() =>
		{
			StepCount.Text = e.NumberOfSteps.ToString();
		});
	}

	void Button_Clicked(object sender, EventArgs e)
	{
		if (!pedometer.IsMonitoring)
		{
			pedometer.Start();
		}
		else
		{
			pedometer.Stop();
		}

		UpdateIsMonitoring();
	}

	void UpdateIsMonitoring()
	{
		IsMonitoring.Text = $"Is monitoring: {pedometer.IsMonitoring}";
	}
}
