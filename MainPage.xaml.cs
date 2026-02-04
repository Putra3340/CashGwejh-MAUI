using Android.Widget;
using CashGwejh.Models;
using CashGwejh.Page;
using CashGwejh.Utils;

namespace CashGwejh
{
    public partial class MainPage : ContentPage
    {
        public static MainPage Instance = null;
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            Instance = this;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            SaveData.LoadTransaction();

            Data_Stats.BindingContext = StaticBinding.HomeStats;
            Data_Trx.ItemsSource = StaticBinding.TransactionsList;

            StaticBinding.HomeStats.SyncWithTransaction();
        }

        private async void FloatingButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(
                nameof(ManagePage),
                new Dictionary<string, object>
                {
                ["Transaction"] = null
                }
                );
        }

        private async void Data_Trx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is not ManageTransactionViewModel trx)
                return;

            ((CollectionView)sender).SelectedItem = null;

            await Shell.Current.GoToAsync(
    nameof(ManagePage),
    new Dictionary<string, object>
    {
        ["Transaction"] = trx
    }
);


        }
    }
}
