using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RedSocialApp.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        public IRelayCommand LogoutCommand { get; }

        [ObservableProperty]
        private bool isUserLogout = true;

        public AppShellViewModel()
        {
            LogoutCommand = new RelayCommand(Logout);
        }

        private void Logout()
        {
            IsUserLogout = true;
            (App.Current.MainPage as AppShell).DisableAppAfterLogin();
        }
    }
}
