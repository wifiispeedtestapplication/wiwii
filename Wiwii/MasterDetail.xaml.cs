using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Wiwii
{
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            var mPage = new MasterContentPage(this);
            Master = mPage;
            Detail = new NavigationPage(new SettingsPage());
            InitializeComponent();
        }
    }
}
