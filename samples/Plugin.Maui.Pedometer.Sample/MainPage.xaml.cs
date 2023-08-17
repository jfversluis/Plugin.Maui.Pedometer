namespace Plugin.Maui.Pedometer.Sample;

public partial class MainPage : ContentPage
{
	readonly IPedometer pedometer;

	public MainPage(IPedometer pedometer)
	{
		InitializeComponent();
		
		this.pedometer = pedometer;
		pedometer.PedometerReadingChanged += Pedometer_PedometerReadingChanged;
	}

	void Pedometer_PedometerReadingChanged(object sender, PedometerData e)
	{
		StepCount.Text = e.NumberOfSteps.ToString();
	}

	void Button_Clicked(object sender, EventArgs e)
	{
		pedometer.Start();
    }
}
