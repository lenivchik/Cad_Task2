using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp2.Clases
{
    public class Handler : INotifyPropertyChanged
    {
        public List<Banknote> BanknoteList { get; }
        private int balance;
        private Boolean in_out;
        private string info_text;
        private string but_text;
        private bool inf_fl;
        private Brush _foregroundColor;
        public Handler() {
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

        public Boolean Inf_fl { get => inf_fl; set { inf_fl = value; Changeinfo(); } }
        public int Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        public string InfoText
        {
            get { return info_text; }
            set
            {
                info_text = value;
                OnPropertyChanged("InfoText");
            }
        }

        public string ButText
        {
            get { return but_text; }
            set
            {
                but_text = value;
                OnPropertyChanged("ButText");
            }
        }


        public Brush ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                _foregroundColor = value;
                OnPropertyChanged("ForegroundColor");
            }
        }

        public void Changeinfo()
        {

            if (Inf_fl)
            {
                InfoText = "Выберете количество вносимых купюр";
                ButText = "Внести";
                ForegroundColor = Brushes.Black;

            }
            else
            {
                InfoText = "Выберите купюры для выдачи";
                ButText = "Снять";
                ForegroundColor = Brushes.Black;

            }
        }

        public void Check_Abl(int title)
        {
            if (Inf_fl)
                Check_Input(title);
            Check_Output(title);
        }

        private void Check_Input(int title)
        {

            Banknote banknote = BanknoteList.Find(x=>x.Title == title);
            if (banknote.Avaible(Inf_fl))      
                banknote.Wish += 1;
            else
            {
                ForegroundColor = Brushes.Red;
                if(Inf_fl)
                    InfoText = "Достигнут лимит ввода данного типа купюр";
                else
                    InfoText = "Достигнут лимит вывода данного типа купюр";

            }
        }

        private void Check_Output(int title)
        {
            int res = sum();
            Banknote banknote = BanknoteList.Find(x => x.Title == title);
            if (res + title - balance <= 0)
            {
                Check_Input(title);
            }
            else
            {
                ForegroundColor = Brushes.Red;
                InfoText = "Недостаточно средств";
            }
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


        public void Confirm()
        {
            if (Inf_fl)
                Add_Balance();
            else
                Remoove_Balance();
        }

        private void Add_Balance()
        {
            int sum = 0;
            foreach (var bank in BanknoteList)
            {
                bank.Current += bank.Wish;
                sum += bank.Title * bank.Wish;
                bank.Wish = 0;
            }
            Balance += sum;
            ForegroundColor = Brushes.Gold;
            InfoText = "Успешно";
        }

        private void Remoove_Balance()
        {
            int sum = 0;
            foreach (var bank in BanknoteList)
            {
                bank.Current -= bank.Wish;
                sum += bank.Title * bank.Wish;
                bank.Wish = 0;
            }
            Balance -= sum;
            InfoText = "Успешно";
            ForegroundColor = Brushes.Gold;
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
