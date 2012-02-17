using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace helppii
{
    public partial class NewIssue : PhoneApplicationPage
    {
        public NewIssue()
        {
            InitializeComponent();
        }

        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MapView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ApplicationBarCancelButton_Click(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }

        }
    }
}
