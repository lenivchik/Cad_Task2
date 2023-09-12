using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Clases
{
    public class Handler : INotifyPropertyChanged
    {
        public List<Banknote> BanknoteList { get; set; }
        private int balance;
        public  Handler() {
            BanknoteList = new List<Banknote>
            {
                new Banknote(10, 5, 10),
                new Banknote(50, 5, 10),
                new Banknote(100, 5, 10),
                new Banknote(500, 5, 10),
                new Banknote(1000, 5, 10),
                new Banknote(5000, 5, 10)
            };
            balance = 10000;
        }
        public int Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }


        public int Check_Input(int title, int tb)
        {
            int banknote = BanknoteList.Find(x=>x.Title == title).Avaible();
            if(banknote > tb)
                return tb+1;
            MessageBox.Show("Достигнут лимит данного типа купюр");
            return tb;
        }

        public int Check_Output(int title,int tb, int tb1, int tb2, int tb3, int tb4, int tb5, int tb6)
        {
            int res = 10 * tb1 + 50 * tb2 + 100 * tb3 + 500 * tb4 + 1000 * tb5 + 5000 * tb6;
            if (res + title*(tb+1)-balance<=0)
            {
                return Check_Input(title,tb);
            }
            MessageBox.Show("Недостаточно средств");

            return tb;
        }

        private int calk_pl(int tb1, int tb2, int tb3, int tb4, int tb5, int tb6)
        {
            BanknoteList[0].Current += tb1;
            BanknoteList[1].Current += tb2;
            BanknoteList[2].Current += tb3;
            BanknoteList[3].Current += tb4;
            BanknoteList[4].Current += tb5;
            BanknoteList[5].Current += tb6;
            return 10 * tb1 + 50 * tb2 + 100 * tb3 + 500 * tb4 + 1000 * tb5 + 5000 * tb6;
        }
        private int calk_m(int tb1, int tb2, int tb3, int tb4, int tb5, int tb6)
        {
            BanknoteList[0].Current -= tb1;
            BanknoteList[1].Current -= tb2;
            BanknoteList[2].Current -= tb3;
            BanknoteList[3].Current -= tb4;
            BanknoteList[4].Current -= tb5;
            BanknoteList[5].Current -= tb6;
            return 10 * tb1 + 50 * tb2 + 100 * tb3 + 500 * tb4 + 1000 * tb5 + 5000 * tb6;
        }

        public int Add_Balance(int tb1, int tb2, int tb3, int tb4, int tb5, int tb6)
        {

            return balance + calk_pl(tb1, tb2, tb3, tb4, tb5, tb6);

        }

        public int Remoove_Balance(int tb1, int tb2, int tb3, int tb4, int tb5, int tb6)
        {

            return balance - calk_m(tb1, tb2, tb3, tb4, tb5, tb6);

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



    }
}
