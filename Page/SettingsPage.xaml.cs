using CashGwejh.Utils;

namespace CashGwejh.Page;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void ClearTransaction_Clicked(object sender, EventArgs e)
    {
		SaveData.ClearTransaction();
    }
}