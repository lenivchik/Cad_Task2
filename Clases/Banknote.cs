using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Clases
{
    public class Banknote
    {
        public int title { get; set; }
        public int current { get; set; }
        public int max {  get; set; }

        public Banknote(int title, int current, int max) {
            this.title = title;
            this.current = current;
            this.max = max;            
        }

    }
}
