using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCursovoi
{
    public class User : XPObject, INotifyPropertyChanged
    {
        public User(Session session) : base(session) { }

        public User() { }

        private string _login;

        public string Login
        {
            get { return _login; }
            set { SetPropertyValue(nameof(Login), ref _login, value); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetPropertyValue(nameof(Password), ref _password, value); }
        }
        
        public UserRole Role
        {
            get;
            set;
        }
    }

    public enum UserRole
    {
        None = 0,
        User = 1,
        Admin = 255
    }
}
