namespace Proyecto2Propina;

public partial class MainPage : ContentPage
{
	private readonly Random _random = new();

	public MainPage()
	{
		InitializeComponent();
		int initialTip = 15; // Propina inicial del 15%
		// TipSlider.Value = initialTip;
		// EstablecerPropina();
	}
}
