using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestCursovoi.DBWorkLogic;
using TestCursovoi.Models;
using TestCursovoi.View;

namespace TestCursovoi
{
    public class MainViewModel : IViewModel, INotifyPropertyChanged
    {
        private string _title = $"AutoСервис / {BusinessApplication.CurrentApplication.CurrentUser.Login}";

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged(nameof(Title));
            }
        }

        private ObservableCollection<UserControlMenuItem> _menuElements = new ObservableCollection<UserControlMenuItem>();

        public ObservableCollection<UserControlMenuItem> MenuElements
        {
            get { return _menuElements; }
            set
            {
                _menuElements = value;
                NotifyPropertyChanged(nameof(MenuElements));
            }
        }

        private ObservableCollection<UserControl> _selectedSubItem = new ObservableCollection<UserControl>();

        public ObservableCollection<UserControl> SelectedSubItem
        {
            get { return _selectedSubItem; }
            set
            {
                _selectedSubItem = value;
                NotifyPropertyChanged(nameof(SelectedSubItem));
            }
        }

        public void InitializeMenuItem()
        {
            var userRole = BusinessApplication.CurrentApplication.CurrentUser.Role;

            #region Управление

            var menuManagement = new List<SubItem>();

            if (userRole == UserRole.Admin)
                menuManagement.Add(new SubItem("Пользователи", new ManagementView(new ManagementViewModel())));


            var Management = new ItemMenu("Управление", PackIconKind.User, menuManagement);

            _menuElements.Add(new UserControlMenuItem(Management, this));

            #endregion

            #region Справочники

            var menuGuide = new List<SubItem>();

            menuGuide.Add(new SubItem("Контрагенты", new Test()));

            var Guide = new ItemMenu("Справочники", PackIconKind.Books, menuGuide);

            _menuElements.Add(new UserControlMenuItem(Guide, this));

            #endregion
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
