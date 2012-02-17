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
using Microsoft.Phone.Tasks;

namespace helppii
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PropertiesView.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/PropertiesView.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask wbTask = new WebBrowserTask();
            wbTask.Uri = new Uri("http://yhteisvastuu.fi/fi/osallistu/tule-vapaaehtoiseksi", UriKind.Absolute);
            wbTask.Show();
        }

        private void ListBoxItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            object item = this.MainMenu.SelectedItem;
            
            if (item == null)
                return;

            ListBoxItem listItem = item as ListBoxItem;
            string tag = (string)listItem.Tag;

            if (tag == "ShowMap")
                NavigationService.Navigate(new Uri("/MapView.xaml", UriKind.Relative));
            else if (tag == "AddReq")
                NavigationService.Navigate(new Uri("/NewIssue.xaml", UriKind.Relative));
        }
    }
}