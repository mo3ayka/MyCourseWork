using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;
using System.Security;
using System.Windows;
using TestCursovoi.View;
using TestCursovoi.ViewModel;

namespace TestCursovoi
{
    public class AuthenticationViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly IAuthenticationService _authenticationService;
        
        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _loginCommand = new DelegateCommand(Login, null);
            _showViewCommand = new DelegateCommand(ShowView, null);
        }

        #region Properties

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; NotifyPropertyChanged(nameof(Username)); }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; NotifyPropertyChanged(nameof(Status)); }
        }

        private Visibility _visibility;

        public Visibility Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                NotifyPropertyChanged(nameof(Visibility));
            }
        }

        #endregion

        #region Commands

        private readonly DelegateCommand _loginCommand;

        public DelegateCommand LoginCommand { get { return _loginCommand; } }

        private readonly DelegateCommand _showViewCommand;

        public DelegateCommand ShowViewCommand { get { return _showViewCommand; } }
        #endregion

        private bool Authorization(object parameter)
        {
            PasswordBox passwordBox = parameter as PasswordBox;
            try
            {
                Validate(parameter);

                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(Username, passwordBox.Password);

                BusinessApplication.CurrentApplication.CurrentUser = user;

                //Update UI
                _loginCommand.RaiseCanExecuteChanged();
                Username = string.Empty; //reset
                passwordBox.Password = string.Empty; //reset
                Status = string.Empty;
                Visibility = Visibility.Hidden;

                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                Status = ex.Message;
            }
            catch(ValidateException ex)
            {
                Status = ex.Message;
            }
            catch (Exception ex)
            {
                Status = $"ERROR: {ex.Message}";
            }

            return false;
        }

        private void Login(object parameter)
        {
            if (Authorization(parameter))
                ShowView(parameter);
        }

        private void ShowView(object parameter)
        {
            Status = string.Empty;
            Window view;
            if (parameter == null)
                view = new MainWindow(new MainViewModel());
            else
                view = new MainWindow(new MainViewModel());

            if (view.ShowDialog() == true)
                Visibility = Visibility.Visible;
        }

        public void Validate(object parameter)
        {
            if (string.IsNullOrEmpty(Username))
                throw new ValidateException("Введите логин");
            if (string.IsNullOrEmpty((parameter as PasswordBox).Password))
                throw new ValidateException("Введите пароль");
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
