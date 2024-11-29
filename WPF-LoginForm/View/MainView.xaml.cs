using System.Windows;
using System.Windows.Input;

namespace WPF_LoginForm.View
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(string surname, string name, string lastname, string job_title)
        {
            InitializeComponent();
            surnameText.Text = "Фамилия: " + surname;
            nameText.Text = "Имя: " + name;
            lastnameText.Text = "Отчество: " + lastname;
            jobText.Text = "Работа: " + job_title;
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
    }
}
