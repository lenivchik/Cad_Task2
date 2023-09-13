using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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
            First_tb.DataContext = handler.BanknoteList[0];
            Sec_tb.DataContext = handler.BanknoteList[1];
            Th_tb.DataContext = handler.BanknoteList[2];
            Fo_tb.DataContext = handler.BanknoteList[3];
            Fi_tb.DataContext = handler.BanknoteList[4];
            Si_tb.DataContext = handler.BanknoteList[5];






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
            if (inf_fl)
                 handler.Check_Input(10);          
            else
                handler.Check_Output(10);
        }

        private void Button_50_1_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
                handler.Check_Input(50);
            else
                handler.Check_Output(50);

        }

        private void Button_100_1_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
                handler.Check_Input(100);
            else
                handler.Check_Output(100);
        }

        private void Button_500_1_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
                handler.Check_Input(500);
            else
                handler.Check_Output(500);

        }

        private void Button_1000_1_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
                handler.Check_Input(1000);
            else
                handler.Check_Output(1000);
        }

        private void Button_5000_1_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
                handler.Check_Input(5000);
            else
                handler.Check_Output(5000);
        }

        private void Button_10_2_Click(object sender, RoutedEventArgs e)
        {
            handler.min_but(10);
        }

        private void Button_50_2_Click(object sender, RoutedEventArgs e)
        {
            handler.min_but(50);
        }

        private void Button_100_2_Click(object sender, RoutedEventArgs e)
        {
            handler.min_but(100);
        }

        private void Button_500_2_Click(object sender, RoutedEventArgs e)
        {
            handler.min_but(500);
        }

        private void Button_1000_2_Click(object sender, RoutedEventArgs e)
        {
            handler.min_but(1000);
        }

        private void Button_5000_2_Click(object sender, RoutedEventArgs e)
        {
            handler.min_but(5000);
        }



        private void But_In_Out_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
            {
                handler.Add_Balance();
            }
            else
            {
                handler.Remoove_Balance();
            }
            MessageBox.Show("Успешно");
        }
    }
}
