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
            bank_table.ItemsSource = handler.banknoteList;
            handler.banknoteList[0].max = 20;
            Tb_Balance.DataContext=handler;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void input_Click(object sender, RoutedEventArgs e)
        {
            inf_fl = true;
            Main_w.Visibility= Visibility.Collapsed;
            Chenge_Info();
            Input_Output.Visibility = Visibility.Visible;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Input_Output.Visibility = Visibility.Collapsed;
            Tb_Balance.Margin = new Thickness(0, 159, 0, 0);
            Input_Output.Children.Remove(Tb_Balance);
            Main_w.Children.Add(Tb_Balance);
            Main_w.Visibility=Visibility.Visible;
        }

        private void output_Click(object sender, RoutedEventArgs e)
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



    }
}
