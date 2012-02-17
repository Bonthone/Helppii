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
using System.Device.Location;

namespace helppii
{
    public partial class NewIssue : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;

        public NewIssue()
        {
            InitializeComponent();
        }

        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.Start();
            App.ViewModel.Items.Add(new ItemViewModel { Title = TitleTextBox.Text, Location = watcher.Position.Location, Description = description.Text });
            int index = App.ViewModel.Items.Count - 1;
            NavigationService.Navigate(new Uri("/IssueView.xaml?selectedItem=" + index, UriKind.RelativeOrAbsolute));
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
