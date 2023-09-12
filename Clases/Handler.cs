using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Clases
{
    public class Handler : INotifyPropertyChanged
    {
        public List<Banknote> banknoteList { get; set; }
        private int balance {  get; set; }
        public  Handler() {
            banknoteList = new List<Banknote>();
            banknoteList.Add(new Banknote(10,5,10));
            banknoteList.Add(new Banknote(50, 5, 10));
            banknoteList.Add(new Banknote(100, 5, 10));
            banknoteList.Add(new Banknote(500, 5, 10));
            banknoteList.Add(new Banknote(1000, 5, 10));
            banknoteList.Add(new Banknote(5000, 5, 10));
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
