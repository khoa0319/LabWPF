using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3
{
    public class Examinee
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public double Subject1 { get; set; }
        public double Subject2 { get; set; }
        public double Subject3 { get; set; }

        public double Total { get => GetTotal();}
        public Examinee()
        {

        }
        public Examinee(int id, string name, double subject1, double subject2, double subject3)
        {
            ID = id;
            Name = name;
            Subject1 = subject1;
            Subject2 = subject2;
            Subject3 = subject3;
        }

        public virtual double GetTotal() => Subject1 + Subject2 + Subject3;

    }
}
