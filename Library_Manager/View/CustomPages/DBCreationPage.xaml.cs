using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_Manager.View.CustomPages
{
    /// <summary>
    /// Interaction logic for DBCreationPage.xaml
    /// </summary>
    public partial class DBCreationPage : Page, INotifyPropertyChanged
    {
        public DBCreationPage()
        {
            DataContext = this;
            InitializeComponent();
            PasswordMsgVisibility = Visibility.Hidden;
        }

        private string?     libraryName;
        private string?     admin;
        private string?     creationpassword;
        private string?     configurationType;
        private Visibility  passwordMsgVisibility;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string LibraryName
        {
            get { return libraryName; }
            set
            {
                libraryName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LibraryName"));
            }
        }
        public string Admin
        {
            get { return admin; }
            set 
            {
                admin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Admin"));
            }
        }
        public string CreationPassword
        {
            get { return creationpassword; }
            set 
            { 
                creationpassword = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CreationPassword"));
            }
        }





        public string ConfigurationType
        {
            get { return configurationType; }
            set 
            {
                configurationType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConfigurationType"));
            }
        }

        public Visibility PasswordMsgVisibility
        {
            get { return passwordMsgVisibility; }
            set
            {
                passwordMsgVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PasswordMsgVisibility"));
            }
        }

        private int timesWarned;
        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CreationPassword))
            {
                PasswordMsgVisibility = Visibility.Visible;
                if (PasswordMsgVisibility == Visibility.Visible)
                    timesWarned++;
            }
            else
            {
                PasswordMsgVisibility = Visibility.Hidden;
                timesWarned = 0;
            }
            if (string.IsNullOrEmpty(LibraryName) || string.IsNullOrEmpty(Admin))
                return;
            else if (string.IsNullOrEmpty(CreationPassword) && timesWarned < 2)
                return;
            else
            {
                Uri uri = new Uri("/View/CustomPages/MainMenu.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
