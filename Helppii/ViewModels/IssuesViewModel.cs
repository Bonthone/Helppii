using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace helppii.ViewModels
{
    public class IssuesViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<Issue> _issues;

        public ObservableCollection<Issue> Issues
        {
            get { return _issues; }
            set
            {
                if (_issues != value)
                {
                    _issues = value;
                    OnPropertyChanged("PushPins");
                }
            }
        }
    }
}
