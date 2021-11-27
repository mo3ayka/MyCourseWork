using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;
using System.Security;
using System.Windows;
using TestCursovoi.View;

namespace TestCursovoi
{
    public class AuthenticationViewModel : IViewModel, INotifyPropertyChanged, ICloseWindow
    {
        private readonly IAuthenticationService _authenticationService;
        
        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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

        #endregion

        #region Commands

        private DelegateCommand _loginCommand;

        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login, null));

        #endregion

        #region Actions

        public Action Close { get; set; }

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
                Close.Invoke();
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
