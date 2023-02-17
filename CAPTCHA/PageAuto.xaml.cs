using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace CAPTCHA
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        int time = 60;
        DispatcherTimer timer = new DispatcherTimer();
        public PageAuto(int index)
        {
            InitializeComponent();
            switch (index)
            {
                case 1:
                    bt_auto.IsEnabled = false;
                    tb_login.IsEnabled = false;
                    pb_password.IsEnabled = false;
                    spCode.Visibility = Visibility.Visible;
                    timer.Interval = new TimeSpan(0, 0, 1);
                    timer.Tick += new EventHandler(Timer_tick);
                    timer.Start();
                    break;
                case 2:
                    bt_auto.IsEnabled = false;
                    spCode.Visibility = Visibility.Collapsed;
                    Captcha captcha = new Captcha(2);
                    captcha.Show();
                    break;
            }
        }

        private void Timer_tick(object sender, EventArgs e) 
        {
            time--;
            tb_Time.Text = "Получить новый код можно через " + time.ToString() + " секунд";
            if (time == 0)
            {
                bt_NewCode.Visibility = Visibility.Visible;
                timer.Stop();

            }
        }

        private void bt_NewCode_Click(object sender, RoutedEventArgs e)
        {
            if (tb_login.Text == "" || pb_password.Password == "")
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                if (tb_login.Text == "admin" && pb_password.Password == "1234")
                {
                    Random rnd = new Random();
                    string code = rnd.Next(10000, 50000).ToString();
                    MessageBox.Show(code + "\nЗапомните пожалуйста код", "Код");
                    Code codee = new Code(code, 1);
                    codee.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }

        private void bt_auto_Click(object sender, RoutedEventArgs e)
        {
            if (tb_login.Text == "" || pb_password.Password == "")
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                if (tb_login.Text == "admin" && pb_password.Password == "1234")
                {
                    Random rnd = new Random();
                    string code = rnd.Next(10000, 50000).ToString();
                    MessageBox.Show(code + "\nЗапомните следующий код", "Код");
                    Code windowCode = new Code(code, 1);
                    windowCode.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }
    }
}
