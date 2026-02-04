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
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}