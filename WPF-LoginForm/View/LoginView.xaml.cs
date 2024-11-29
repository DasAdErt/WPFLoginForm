using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        SqlConnection conn = new SqlConnection(@"Data Source=WIN-VREDO54O6RA; Initial Catalog=workers_db; Integrated Security=True");

        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtUser.Text;
            string password = txtPass.Password;
            conn.Open();
            SqlCommand cmd = new SqlCommand("select surname, name, lastname, job_title from workers " +
                $"where login = '{login}' and password = '{password}'", conn);
            //SELECT name, lastname, surname FROM workers WHERE login = 'BlueSky123' AND password = 'BlueSky123!@#'
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            string surname = dataReader[0].ToString();
            string name = dataReader[1].ToString();
            string lastname = dataReader[2].ToString();
            string job_title = dataReader[3].ToString();
            //MessageBox.Show(surname + " " + name + " " + lastname);
            dataReader.Close();
            conn.Close();

            MainView mainView = new MainView(surname, name, lastname, job_title);
            mainView.Show();
            this.Close();
        }
    }
}