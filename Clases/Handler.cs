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
        public List<Banknote> BanknoteList { get;}
        private int balance;
        private Boolean in_out;
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


        public bool Check_Input(int title)
        {
            Banknote banknote = BanknoteList.Find(x=>x.Title == title);
            if (banknote.Avaible(in_out))
            {
                banknote.Wish += 1;
                in_out = false;
                return true;
            }
            in_out = false;
            return false;
        }

        public bool Check_Output(int title)
        {
            in_out = true;
            int res = sum();
            Banknote banknote = BanknoteList.Find(x => x.Title == title);
            if (res + title - balance <= 0)
            {
                Check_Input(title);
                return true;
            }
            else
                return false;
        }
        public void min_but(int title)
        {
            Banknote banknote = BanknoteList.Find(x => x.Title == title);
            if (banknote.Wish > 0)
                banknote.Wish -= 1;

        }
        private int sum()
        {
            int sum = 0;
            foreach (var bank in BanknoteList)
            {
                sum += bank.Title * bank.Wish;
            }
            return sum;
        }


        public void Add_Balance()
        {
            int sum = 0;
            foreach (var bank in BanknoteList)
            {
                bank.Current += bank.Wish;
                sum += bank.Title * bank.Wish;
                bank.Wish = 0;
            }
            Balance += sum;

        }

        public void Remoove_Balance()
        {
            int sum = 0;
            foreach (var bank in BanknoteList)
            {
                bank.Current -= bank.Wish;
                sum += bank.Title * bank.Wish;
                bank.Wish = 0;
            }
            Balance -= sum;
        }
        public void Clear_Wish()
        {
            foreach (var bank in BanknoteList)
            {
                bank.Wish = 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



    }
}
