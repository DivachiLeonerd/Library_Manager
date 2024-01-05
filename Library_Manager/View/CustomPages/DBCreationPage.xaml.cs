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

        private string? libraryName;

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

        private string? admin;

        public string Admin
        {
            get { return admin; }
            set 
            {
                admin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Admin"));
            }
        }
        private string? creationpassword;

        public string CreationPassword
        {
            get { return creationpassword; }
            set 
            { 
                creationpassword = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CreationPassword"));
            }
        }

        private string? configurationType;

        public string ConfigurationType
        {
            get { return configurationType; }
            set 
            {
                configurationType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ConfigurationType"));
            }
        }

        private Visibility passwordMsgVisibility;
        public Visibility PasswordMsgVisibility
        {
            get { return passwordMsgVisibility; }
            set
            {
                passwordMsgVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PasswordMsgVisibility"));
            }
        }

        private static bool hasBeenWarned = false;
        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CreationPassword))
            {
                if (PasswordMsgVisibility == Visibility.Visible)
                    hasBeenWarned = true;
                else
                    PasswordMsgVisibility = Visibility.Visible;
            }
            else
                hasBeenWarned = true;
            if (string.IsNullOrEmpty(LibraryName) || string.IsNullOrEmpty(Admin) || string.IsNullOrEmpty(ConfigurationType)
                || (hasBeenWarned == false))
                return;
            else
            {
                Uri uri = new Uri("/View/CustomPages/MainMenu.xaml", UriKind.Relative);
                this.NavigationService.Navigate(uri);
            }
        }
    }
}
