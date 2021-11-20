using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCursovoi.DBWorkLogic
{
    public class DBconnecting
    {
        public DBconnecting()
        {

        }

        private static DBconnecting _currentConnecting;

        public static DBconnecting CurrentConnecting => _currentConnecting ??
            (_currentConnecting = new DBconnecting());

        private IDataLayer _dataLayer = XpoDefault.GetDataLayer(MSSqlConnectionProvider.GetConnectionString(".\\SQLEPISHEVHOME", "AutoShop"), AutoCreateOption.DatabaseAndSchema);

        public IDataLayer DataLayer => _dataLayer;
    }
}
