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
using TestCursovoi.ViewModel;

namespace TestCursovoi.View
{
    /// <summary>
    /// Логика взаимодействия для ManagementView.xaml
    /// </summary>
    public partial class ManagementView : UserControl, IView
    {
        public ManagementView(ManagementViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel; }
            set { DataContext = value; }
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
