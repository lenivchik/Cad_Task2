using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Clases
{
    public class Banknote: INotifyPropertyChanged
    {
        public int Title { get;}
        public int Max {  get;}
        private int current;
        private int wish;

        public Banknote(int title, int current, int max) {
            this.Title = title;
            this.current = current;
            this.Max = max;
            wish = 0;
            
        }
        public int Current
        { get { return current; }
            set {
                current = value;
                OnPropertyChanged("Current");
            }
        }

        public int Wish
        {
            get { return wish; }
            set
            {
                wish = value;
                OnPropertyChanged("Wish");
            }
        }

        public bool Avaible(Boolean inp)
        {
            if (inp)
                return (Max - current - wish) > 0;

            return ((current - wish) > 0) ;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
