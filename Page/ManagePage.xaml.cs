using Android.Widget;
using CashGwejh.Models;
using CashGwejh.Utils;
namespace CashGwejh.Page;

[QueryProperty(nameof(Transaction), "Transaction")]
public partial class ManagePage : ContentPage
{
    public ManageTransactionViewModel Transaction
    {
        get => field;
        set { if (value == null) return; field = value;BindingContext = value; IsUpdate = true;Btn_Delete.IsVisible = true; }
    }
    public bool IsUpdate = false;
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
        var list = StaticBinding.TransactionsList;

        if (!IsUpdate)
        {
            list.Add(vm);
        }
        else
        {
            var existing = list.FirstOrDefault(x => x.Id == vm.Id);
            if (existing != null)
            {
                existing.Amount = vm.Amount;
                existing.SelectedCurrency = vm.SelectedCurrency;
                existing.SelectedTransactionType = vm.SelectedTransactionType;
                existing.SelectedCategory = vm.SelectedCategory;
                existing.SelectedAccountType = vm.SelectedAccountType;
                existing.Notes = vm.Notes;
                existing.CreatedAt = vm.CreatedAt;
            }
        }

        var sorted = list
            .OrderByDescending(x => x.CreatedAt)
            .ToList();

        for (int i = 0; i < sorted.Count; i++)
        {
            var oldIndex = list.IndexOf(sorted[i]);
            if (oldIndex != i)
                list.Move(oldIndex, i);
        }

        Toast.MakeText(Android.App.Application.Context, "Transaction Saved", ToastLength.Short).Show();

        Dispatcher.Dispatch(async () =>
        {
            await SaveData.SaveTransaction();
            StaticBinding.HomeStats.SyncWithTransaction();
            btn.IsEnabled = true;
            IsUpdate = false;
            await Shell.Current.GoToAsync("..");
        });
    }

    private void FloatingButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is not ManageTransactionViewModel vm)
            return;
        if (sender is not Microsoft.Maui.Controls.Button btn)
            return;

        var list = StaticBinding.TransactionsList;
        var existing = list.FirstOrDefault(x => x.Id == vm.Id);
        list.Remove(existing);
        Toast.MakeText(Android.App.Application.Context, "Transaction Deleted", ToastLength.Short).Show();

        Dispatcher.Dispatch(async () =>
        {
            await SaveData.SaveTransaction();
            StaticBinding.HomeStats.SyncWithTransaction();
            btn.IsEnabled = true;
            IsUpdate = false;
            await Shell.Current.GoToAsync("..");
        });
    }
}