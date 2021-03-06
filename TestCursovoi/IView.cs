using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCursovoi
{
    public interface IView
    {
        IViewModel ViewModel
        {
            get;
            set;
        }

        void Show();

        bool? ShowDialog();
    }

    public interface IViewModel { }
}
