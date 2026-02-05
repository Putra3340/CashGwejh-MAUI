#if  ANDROID
using Android.Widget;
#endif
using CashGwejh.Models;
using CashGwejh.Page;
using CashGwejh.Utils;
using System.Threading.Tasks;

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
            SaveData.LoadMilestone();
            Data_Stats.BindingContext = StaticBinding.HomeStats;
            Data_Trx.ItemsSource = StaticBinding.TransactionsList;
            Data_Milestone.BindingContext = StaticBinding.MilestoneStats;

            StaticBinding.HomeStats.SyncWithTransaction();
            StaticBinding.MilestoneStats.UpdateAmount();
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

        private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MilestonePage));
        }
    }
}
