using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Wiwii
{
    public partial class MasterContentPage : ContentPage
    {
        MasterDetailPage myMaster;

        public MasterContentPage(MasterDetailPage _myMaster)
        {
            myMaster = _myMaster;
            InitializeComponent();
        }
    }
}
