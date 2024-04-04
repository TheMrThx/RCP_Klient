using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RCP_Klient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string currentVersion = "0.0.1"; //Aktualna wersja programu

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Login = TextBox_Login.Text;
            string Password = PasswordBox_Password.Password;

            if(string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password)){

                MessageBox.Show("Pola login i hasło nie mogą być puste");

            }
            else
            {
                
            }
        }
    }
}