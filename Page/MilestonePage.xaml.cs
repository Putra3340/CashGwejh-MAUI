#if ANDROID
using Android.Widget;
#endif
using CashGwejh.Models;
using CashGwejh.Utils;

namespace CashGwejh.Page;

public partial class MilestonePage : ContentPage
{
	public MilestonePage()
	{
        StaticBinding.MilestoneStats.UpdateAmount();
        this.BindingContext = StaticBinding.MilestoneStats;
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		if (this.BindingContext is not HomeMilestoneModel hmm) return;
#if ANDROID

        Toast.MakeText(Android.App.Application.Context, "Transaction Saved", ToastLength.Short).Show();
#endif
        Dispatcher.Dispatch(async () =>
        {
            SaveData.SaveMilestone();
            StaticBinding.MilestoneStats.UpdateAmount();
            await SaveData.SaveTransaction();
            StaticBinding.HomeStats.SyncWithTransaction();
            await Shell.Current.GoToAsync("..");
        });
    }
}