using Microsoft.Extensions.DependencyInjection;
using CashGwejh.Page;
namespace CashGwejh
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ManagePage), typeof(ManagePage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(MilestonePage), typeof(MilestonePage));
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}