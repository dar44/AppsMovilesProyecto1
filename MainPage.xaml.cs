namespace Proyecto1Colores;

public partial class MainPage : ContentPage
{
	private readonly Random _random = new();

	public MainPage()
	{
		// Función de inicialización de la aplicación. El color inicial es negro.
		InitializeComponent();
		RedSlider.Value = 0;
		GreenSlider.Value = 0;
		BlueSlider.Value = 0;
		EstablecerColor();
	}

	private void Slider_ValueChanged(object? sender, ValueChangedEventArgs e)
	{
		// Actualizar el color cuando cambia el valor de alguno de los sliders
		EstablecerColor();
	}

	private void RandomButton_Clicked(object? sender, EventArgs e)
	{
		// Generar valores aleatorios para los sliders
		RedSlider.Value = _random.Next(0, 256);
		GreenSlider.Value = _random.Next(0, 256);
		BlueSlider.Value = _random.Next(0, 256);

		EstablecerColor();
	}

	private async void Clipboard_Clicked(object? sender, EventArgs e)
	{
		// Copiar el valor hexadecimal al portapapeles
		await Clipboard.Default.SetTextAsync(HexValueLabel.Text);
	}

	private void EstablecerColor()
	{
		// Obtener los valores de los sliders y crear un color a partir de ellos
		int red = (int)RedSlider.Value;
		int green = (int)GreenSlider.Value;
		int blue = (int)BlueSlider.Value;

		Color color = Color.FromRgb(red, green, blue);
		Color textColor = ObtenerColorTextoPorContraste(red, green, blue);

		ColorContainer.BackgroundColor = color;
		HexValueLabel.Text = $"#{red:X2}{green:X2}{blue:X2}";
		RedValueLabel.TextColor = textColor;
		GreenValueLabel.TextColor = textColor;
		BlueValueLabel.TextColor = textColor;
		HexValueLabel.TextColor = textColor;
	}

	private static Color ObtenerColorTextoPorContraste(int red, int green, int blue)
	{
		// Esta función calcula la luminancia del color y devuelve negro o blanco 
		// dependiendo de cuál tenga mejor contraste con el fondo.
		double luminancia = (0.299 * red) + (0.587 * green) + (0.114 * blue);
		return luminancia > 186 ? Colors.Black : Colors.White;
	}
}
