using RedSocialApp.ViewModels;
using RedSocialApp.Views;
using CommunityToolkit.Mvvm.Messaging;
using RedSocialApp.Utils;

namespace RedSocialApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            RegisterRoute();
        }
        private void RegisterRoute()
        {
            Routing.RegisterRoute("Registrarse", typeof(RegistrarseView));
        }

        public void EnableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Flyout; // Habilita el FlyOut
            FlyoutItemsPrincipal.IsVisible = true; // Muestra el menú lateral
            Shell.Current.GoToAsync("//MainPage"); // Navega a la página principal
            var viewmodel = this.BindingContext as AppShellViewModel;
            viewmodel.IsUserLogout = false;
        }
        public void DisableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Disabled; // Deshabilita el FlyOut
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            Shell.Current.GoToAsync("//Login"); // Navega a la página de login
        }
    }
}
