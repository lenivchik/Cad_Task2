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
            handler.Clear_Wish();
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
            Main_w.Children.Remove(Tb_Balance);
            Grid.SetColumn(Tb_Balance, 1);
            Tb_Balance.Margin = new Thickness(0, 10, 0, 0);
            Input_Output.Children.Add(Tb_Balance);
            String info;
            Tb_Info.Foreground = Brushes.Black;
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

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            string info = "Выберете количество вносимых купюр";
            Tb_Info.Foreground=Brushes.Black;
            Tb_Info.Text = info;

            int sp2= int.Parse(((TextBlock)((Grid)((Panel)((Control)sender).Parent).Parent).Children[1]).Text);
            if (inf_fl)
            {
                if (!handler.Check_Input(sp2))
                {
                    info = "Достигнут лимит данного типа купюр";
                    Tb_Info.Foreground = Brushes.Gold;
                    Tb_Info.Text = info;
                }
            }           
            else
               if(!handler.Check_Output(sp2))
            {
                info = "Недостаточно средств";
                Tb_Info.Foreground = Brushes.Gold;
                Tb_Info.Text = info;

            }



        }
        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            int sp2 = int.Parse(((TextBlock)((Grid)((Panel)((Control)sender).Parent).Parent).Children[1]).Text);
            handler.min_but(sp2);
        }



        private void But_In_Out_Click(object sender, RoutedEventArgs e)
        {
            if (inf_fl)
                handler.Add_Balance();
            else
                handler.Remoove_Balance();
            String info = "Успешно";
            Tb_Info.Foreground = Brushes.Gold;
            Tb_Info.Text = info;
        }
    }

}
