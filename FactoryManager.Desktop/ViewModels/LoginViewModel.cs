using System.Windows.Input;
using FactoryManager.Desktop.Services;

namespace FactoryManager.Desktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthenticationService authService)
        {
            _authService = authService;
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void ExecuteLogin(object parameter)
        {
            try
            {
                var result = await _authService.LoginAsync(Username, Password);
                if (result)
                {
                    // Nawigacja do głównego okna
                }
                else
                {
                    ErrorMessage = "Nieprawidłowe dane logowania";
                }
            }
            catch
            {
                ErrorMessage = "Wystąpił błąd podczas logowania";
            }
        }
    }
}
