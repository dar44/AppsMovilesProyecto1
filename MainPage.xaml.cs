namespace Proyecto1Colores;

public partial class MainPage : ContentPage
{
	private readonly Random _random = new();

	public MainPage()
	{
		InitializeComponent();
		EstablecerColor();
	}

	private void Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
	{
		EstablecerColor();
	}

	private void RandomButton_Clicked(object? sender, EventArgs e)
	{
		RedSlider.Value = _random.Next(0, 256);
		GreenSlider.Value = _random.Next(0, 256);
		BlueSlider.Value = _random.Next(0, 256);

		EstablecerColor();
	}

	private async void Clipboard_Clicked(object? sender, EventArgs e)
	{
		await Clipboard.Default.SetTextAsync(HexValueLabel.Text);
	}

	private void EstablecerColor()
	{
		int red = (int)RedSlider.Value;
		int green = (int)GreenSlider.Value;
		int blue = (int)BlueSlider.Value;

		Color color = Color.FromRgb(red, green, blue);

		ColorContainer.BackgroundColor = color;
		HexValueLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";
	}
}
