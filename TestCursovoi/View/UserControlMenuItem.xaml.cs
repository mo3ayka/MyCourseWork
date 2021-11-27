using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestCursovoi.Models;

namespace TestCursovoi.View
{
    /// <summary>
    /// Логика взаимодействия для UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        public UserControlMenuItem(ItemMenu itemMenu, MainViewModel mainViewModel)
        {
            InitializeComponent();

            //_context = context;
            _mainViewModel = mainViewModel;

            ListViewItemMenu.Visibility = Visibility.Collapsed;
            Visibility = itemMenu.SubItems == null || itemMenu.SubItems.Count == 0 ? Visibility.Collapsed : Visibility.Visible;

            DataContext = itemMenu;

        }

        #region Variables

        private MainViewModel _mainViewModel;

        private bool ignoreSelectionChanged = false;

        #endregion

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ignoreSelectionChanged)
            {
                ignoreSelectionChanged = false;
                return;
            }    
            
            _mainViewModel.SelectedSubItem.Clear();
            _mainViewModel.SelectedSubItem.Add(((SubItem)((ListView)sender).SelectedItem).Screen);

            //Очищает выделения в других Expander - ListView
            foreach (var item in _mainViewModel.MenuElements.Where(item => item != this))
                item.ClearSelection();
        }

        public void ClearSelection()
        {
            if (ListViewMenu.SelectedItem != null)
            {
                ignoreSelectionChanged = true;
                ListViewMenu.SelectedItem = null;
            }
        }
    }
}
