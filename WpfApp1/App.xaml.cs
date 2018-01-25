using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string text="policja";
        public string Text
        {
            get { return this.text; }
            set
            {
                this.text = value;      
                this.OnPropertyChanged(nameof(this.Text));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }












    }
}
