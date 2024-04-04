using System.Net.Sockets;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password)){

                MessageBox.Show("Pola login i hasło nie mogą być puste");

            }
            else
            {
                try
                {
                    // Adres IP i port serwera
                    string serverAddress = "127.0.0.1";
                    int port = 8888;

                    TcpClient client = new TcpClient(serverAddress, port);
                    Console.WriteLine("Połączono z serwerem.");

                    // Dane do logowania
                    string username = TextBox_Login.Text;
                    string password = PasswordBox_Password.Password;

                    // Wysłanie danych do serwera
                    string credentials = username + ":" + password;
                    byte[] data = Encoding.ASCII.GetBytes(credentials);
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);

                    // Oczekiwanie na odpowiedź od serwera
                    data = new byte[256];
                    int bytes = stream.Read(data, 0, data.Length);
                    string responseData = Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Odpowiedź serwera: " + responseData);

                    // Jeśli logowanie się powiodło, klient może wysłać dodatkowy tekst do serwera
                    if (responseData == "Zalogowano pomyślnie.")
                    {
                        MessageBox.Show("Zalogowano pomyślnie.");
                    }

                    client.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}