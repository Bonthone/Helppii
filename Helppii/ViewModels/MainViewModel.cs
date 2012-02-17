using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Device.Location;


namespace helppii
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            this.Items.Add(new ItemViewModel() { Title = "Viininmaistelu", Location = new GeoCoordinate(60.1810, 24.9218), Description = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu", ImagePath = "Images/icon_car.png" });
            this.Items.Add(new ItemViewModel() { Title = "Talkoot", Location = new GeoCoordinate(60.1817, 24.9248), Description = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", ImagePath = "Images/icon_f.png" });
            this.Items.Add(new ItemViewModel() { Title = "Jutteluseuraa", Location = new GeoCoordinate(60.1870, 24.9228), Description = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent", ImagePath = "Images/icon_food.png" });
            this.Items.Add(new ItemViewModel() { Title = "Talkoot", Location = new GeoCoordinate(60.1510, 24.9318), Description = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", ImagePath = "Images/icon_cat.png" });
            this.Items.Add(new ItemViewModel() { Title = "Kimppakyyti", Location = new GeoCoordinate(60.1410, 24.9238), Description = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", ImagePath = "Images/icon_food.png" });
            this.Items.Add(new ItemViewModel() { Title = "Talkoot", Location = new GeoCoordinate(60.1510, 24.9258), Description = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", ImagePath = "Images/icon_trade.png" });
            this.Items.Add(new ItemViewModel() { Title = "Bileet", Location = new GeoCoordinate(60.1410, 24.9278), Description = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", ImagePath = "Images/icon_car.png" });
            this.Items.Add(new ItemViewModel() { Title = "Talkoot", Location = new GeoCoordinate(60.1210, 24.9218), Description = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", ImagePath = "Images/icon_food.png" });
            this.Items.Add(new ItemViewModel() { Title = "Jotain", Location = new GeoCoordinate(60.1310, 24.9220), Description = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus", ImagePath = "Images/icon_f.png" });



            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}