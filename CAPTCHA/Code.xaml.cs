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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CAPTCHA
{
    /// <summary>
    /// Логика взаимодействия для Code.xaml
    /// </summary>
    public partial class Code : Window
    {
        DispatcherTimer times = new DispatcherTimer();
        string kod;
        int index;
        int time = 11;
        public Code(string kod, int index)
        {
            InitializeComponent();
            this.kod = kod;
            this.index = index;
            times.Interval = new TimeSpan(0, 0, 1);
            times.Tick += new EventHandler(Timer);
            times.Start();
        }

        

        public void Timer(object sender, EventArgs e)
        {
            time--;
            tb_Time.Text = "Осталось " + time + " секунд";
            if (time < 0)
            {
                times.Stop();
                ClassFrame.frameL.Navigate(new PageAuto(index));
                Close();
            }
        }

        private void tb_Code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tb_Code.Text.Length == 5)
            {
                if (tb_Code.Text == kod)
                {
                    times.Stop();
                    MessageBox.Show("Успешно!", "Авторизация");
                    Close();
                }
                else
                {
                    times.Stop();
                    MessageBox.Show("Код введен неверно!", "Ошибка");
                    ClassFrame.frameL.Navigate(new PageAuto(index));
                    Close();

                }
            }
        }
    }
}
