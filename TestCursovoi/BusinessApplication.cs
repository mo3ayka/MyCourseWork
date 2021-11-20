using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCursovoi
{
    public class BusinessApplication
    {
        private static BusinessApplication _currentApplication;

        public static BusinessApplication CurrentApplication => _currentApplication ??
            (_currentApplication = new BusinessApplication());

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
            
    }
}
