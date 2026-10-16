using IoTCostEstimator.Models;

namespace IoTCostEstimator.Views;

public partial class ItemEditorPage : ContentPage
{
	public ItemEditorPage()
	{
		InitializeComponent();
	}

    private void SubmitButton_Clicked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text ?? string.Empty;
        string sourceUrl = SourceUrlEntry.Text ?? string.Empty;
        string units = UnitsEntry.Text ?? string.Empty;
        decimal cost = decimal.Parse(CostPerUnitEntry.Text);
        decimal quantity = decimal.Parse(UnitsNeededEntry.Text);
        MaterialItem item = new(title, sourceUrl, units, cost, quantity);
        TotalCostLabel.Text = item.ToString();
    }
}