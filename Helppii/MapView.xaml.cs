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
using Microsoft.Phone.Controls.Maps;
using System.Collections.ObjectModel;
using helppii.ViewModels;

namespace helppii
{
    public partial class MapView : PhoneApplicationPage
    {
        GeoCoordinateWatcher watcher;

        public MapView()
        {
            InitializeComponent();

            watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            watcher.MovementThreshold = 25;
            watcher.Start();

            DataContext = new IssuesViewModel
            {
                Issues = new ObservableCollection<Issue>() 
                        {
                            new Issue
                                {
                                    Location = new GeoCoordinate(51.569593, 10.103504),
                                    Title = "Viininmaistelut",
                                    Description = "Heh juum, olis tollaset maistelut",
                                    Id = new Guid()
                                },
                            new Issue
                                {
                                    Location = new GeoCoordinate(-45.569593, 1.103504),
                                    Title = "Sohva pitäis siirtää",
                                    Description = "Heh juum, olis tollanen sohva",
                                    Id = new Guid()

                                },
                            new Issue
                                {
                                    Location = new GeoCoordinate(60.2465, 24.8559),
                                    Title = "Tarviis juttuseuraa",
                                    Description = "Heh juum, tarviis tollasta seuraa",
                                    Id = new Guid()
                                }, 
                            new Issue
                                {
                                    Location = new GeoCoordinate(60.2, 24.8),
                                    Title = "Talkooapua",
                                    Description = "Heh juum, tarviis tollasta talkooapua",
                                    Id = new Guid()
                                }
                        }
            };
        }


        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            myMap.Center = e.Position.Location;
            myMap.ZoomLevel = 10;

            //Pushpin pin1 = new Pushpin();
            //pin1.Location = e.Position.Location;
            //myMap.Children.Add(pin1);
        }

        private void Show_Zoom(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Issue i = ((ListBox)sender).SelectedItem as Issue;
            string id = i.Id.ToString();
            NavigationService.Navigate(new Uri("/IssueView.xaml?id=" + id, UriKind.RelativeOrAbsolute)); 
        }

    }
}