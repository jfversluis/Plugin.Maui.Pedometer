using Microsoft.Extensions.DependencyInjection;
using Plugin.Maui.Pedometer;

namespace Plugin.Maui.Pedometer.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<IPedometer>(Pedometer.Default);

		return builder.Build();
	}
}