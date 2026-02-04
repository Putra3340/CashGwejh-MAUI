using Android.Widget;
using CashGwejh.Models;
using CashGwejh.Utils;
namespace CashGwejh.Page;

public partial class ManagePage : ContentPage
{
    public ManagePage()
    {
        InitializeComponent();
        try
        {

            BindingContext = new ManageTransactionViewModel();
        }
        catch (Exception ex)
        {
            Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();
        }
    }

    private void SaveTransaction_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is not ManageTransactionViewModel vm)
            return;
        if (sender is not Microsoft.Maui.Controls.Button btn)
            return;

        btn.IsEnabled = false;
        Dispatcher.Dispatch(() =>
        {
            var list = StaticBinding.TransactionsList;

            // add new transaction
            list.Add(vm);

            // reorder
            var sorted = list
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            // rebuild collection
            list.Clear();
            foreach (var item in sorted)
                list.Add(item);
        });

        var amount = vm.Amount;
        var currency = vm.SelectedCurrency;
        var type = vm.SelectedTransactionType;
        var category = vm.SelectedCategory;
        var account = vm.SelectedAccountType;
        var notes = vm.Notes;

        Toast.MakeText(Android.App.Application.Context, "Transaction Saved", ToastLength.Short).Show();
        Dispatcher.Dispatch(async () =>
        {
            await SaveData.SaveTransaction();
            StaticBinding.HomeStats.SyncWithTransaction();
            btn.IsEnabled = true;
            await Shell.Current.GoToAsync("..");
        });
    }
}