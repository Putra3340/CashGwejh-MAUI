using CashGwejh.Models;
using CashGwejh.Page;
using CashGwejh.Utils;

namespace CashGwejh
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
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
            await Shell.Current.GoToAsync(nameof(ManagePage));
        }
    }
}
