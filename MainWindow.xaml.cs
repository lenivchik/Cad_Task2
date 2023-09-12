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
using WpfApp2.Clases;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Boolean inf_fl;
        Handler handler;
        public MainWindow()
        {
            InitializeComponent();
            handler = new Handler();
            bank_table.ItemsSource = handler.BanknoteList;
            Tb_Balance.DataContext=handler;
            

        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            inf_fl = true;
            Main_w.Visibility= Visibility.Collapsed;
            Chenge_Info();
            Input_Output.Visibility = Visibility.Visible;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Input_Output.Visibility = Visibility.Collapsed;
            Tb_Balance.Margin = new Thickness(0, 159, 0, 0);
            Input_Output.Children.Remove(Tb_Balance);
            Main_w.Children.Add(Tb_Balance);
            Main_w.Visibility=Visibility.Visible;
        }

        private void Output_Click(object sender, RoutedEventArgs e)
        {
            inf_fl=false;
            Main_w.Visibility = Visibility.Collapsed;
            Chenge_Info();
            Input_Output.Visibility = Visibility.Visible;
        }

        private void Chenge_Info()
        {
            Tb_Balance.Margin = new Thickness(0, 10, 0, 0);
            Main_w.Children.Remove(Tb_Balance);
            Input_Output.Children.Add(Tb_Balance);
            String info;
            if (inf_fl)
            {
                info = "Выберете количество вносимых купюр";
                Tb_Info.Text = info;
                But_In_Out.Content = "Внести";
            }
            else
            {
                inf_fl = false;
                info = "Выберите купюры для выдачи";
                Tb_Info.Text = info;
                But_In_Out.Content = "Снять";
            }
        }

        private void Button_10_1_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_10.Text);
            int up;

            if (inf_fl)
            {
                 up = handler.Check_Input(10, cur);
            }
            else
            {
                up = handler.Check_Output(10, cur, int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            if (cur != up)
                tb_10.Text = up.ToString();

        }

        private void Button_50_1_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_50.Text);
            int up;

            if (inf_fl)
            {
                up = handler.Check_Input(10, cur);
            }
            else
            {
                up = handler.Check_Output(50, cur, int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            if (cur != up)
                tb_50.Text = up.ToString();

        }

        private void Button_100_1_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_100.Text);
            int up;

            if (inf_fl)
            {
                up = handler.Check_Input(100, cur);
            }
            else
            {
                up = handler.Check_Output(100, cur, int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            if (cur != up)
                tb_100.Text = up.ToString();

        }

        private void Button_500_1_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_500.Text);
            int up;

            if (inf_fl)
            {
                up = handler.Check_Input(500, cur);
            }
            else
            {
                up = handler.Check_Output(500, cur, int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            if (cur != up)
                tb_500.Text = up.ToString();

        }

        private void Button_1000_1_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_1000.Text);
            int up;

            if (inf_fl)
            {
                up = handler.Check_Input(1000, cur);
            }
            else
            {
                up = handler.Check_Output(1000, cur, int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            if (cur != up)
                tb_1000.Text = up.ToString();

        }

        private void Button_5000_1_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_5000.Text);
            int up;

            if (inf_fl)
            {
                up = handler.Check_Input(5000, cur);
            }
            else
            {
                up = handler.Check_Output(5000, cur, int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            if (cur != up)
                tb_5000.Text = up.ToString();

        }

        private void Button_10_2_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_10.Text);            
            if (cur > 0)
            {
                tb_10.Text = (cur-1).ToString();
            }
        }

        private void Button_50_2_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_50.Text);
            if (cur > 0)
            {
                tb_50.Text = (cur - 1).ToString();
            }
        }

        private void Button_100_2_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_100.Text);
            if (cur > 0)
            {
                tb_100.Text = (cur - 1).ToString();
            }
        }

        private void Button_500_2_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_500.Text);
            if (cur > 0)
            {
                tb_500.Text = (cur - 1).ToString();
            }
        }

        private void Button_1000_2_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_1000.Text);
            if (cur > 0)
            {
                tb_1000.Text = (cur - 1).ToString();
            }
        }

        private void Button_5000_2_Click(object sender, RoutedEventArgs e)
        {
            int cur = int.Parse(tb_5000.Text);
            if (cur > 0)
            {
                tb_5000.Text = (cur - 1).ToString();
            }
        }

        private void clearAll()
        {
            tb_10.Text = "0" ;
            tb_50.Text = "0";
            tb_100.Text = "0";
            tb_500.Text = "0";
            tb_1000.Text = "0";
            tb_5000.Text = "0";
        }

        private void But_In_Out_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
            {
                handler.Balance= handler.Add_Balance(int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            else
            {
                handler.Balance=handler.Remoove_Balance(int.Parse(tb_10.Text), int.Parse(tb_50.Text), int.Parse(tb_100.Text), int.Parse(tb_500.Text), int.Parse(tb_1000.Text), int.Parse(tb_5000.Text));
            }
            MessageBox.Show("Успешно");
            clearAll();
        }
    }
}
