using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestCursovoi.Models
{
    public class ItemMenu
    {
        public ItemMenu(string header, PackIconKind icon, List<SubItem> subItems = null)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }
    }
}
