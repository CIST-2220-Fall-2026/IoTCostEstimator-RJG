using IoTCostEstimator.Models;

namespace IoTCostEstimator.Views;

public partial class ItemEditorPage : ContentPage
{
	public ItemEditorPage()
	{
		InitializeComponent();
	}

    private async void SubmitButton_Clicked(object sender, EventArgs e)
    {
        TotalCostLabel.Text = "Enter item details and tap Submit.";

        if (string.IsNullOrWhiteSpace(TitleEntry.Text) ||
            string.IsNullOrWhiteSpace(UnitsEntry.Text))
        {
            await DisplayAlertAsync("Missing details",
                "Enter an item title and units.", "OK");
            return;
        }

        if (!decimal.TryParse(CostPerUnitEntry.Text, out decimal costPerUnit) ||
            !decimal.TryParse(UnitsNeededEntry.Text, out decimal unitsNeeded) ||
            costPerUnit < 0 || unitsNeeded < 0)
        {
            await DisplayAlertAsync("Invalid numbers",
                "Enter nonnegative numbers for cost and quantity.", "OK");
            return;
        }
        string title = TitleEntry.Text ?? string.Empty;
        string sourceUrl = SourceUrlEntry.Text ?? string.Empty;
        string units = UnitsEntry.Text ?? string.Empty;
        decimal cost = decimal.Parse(CostPerUnitEntry.Text);
        decimal quantity = decimal.Parse(UnitsNeededEntry.Text);
        MaterialItem item = new(title, sourceUrl, units, cost, quantity);
        TotalCostLabel.Text = item.ToString();
    }
}