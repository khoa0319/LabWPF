using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3
{
    public class ProExaminee : Examinee
    {
        public double English { get; set; }
        public ProExaminee(int id, string name, double subject1, double subject2, double subject3, double english) : base(id, name, subject1, subject2, subject3)
        {
            English = english;
        }

        public override double GetTotal() => base.GetTotal() + English;

        public static List<ProExaminee> Getdata()
        {
            var list = new List<ProExaminee>
            {
                new ProExaminee(1, "Nguyễn Văn A", 5, 6, 7, 8),
                new ProExaminee(2, "Nguyễn Văn B", 5, 6, 7, 8),
                new ProExaminee(101, "Bùi Tiến Dũng", 6, 7, 8, 9),
                new ProExaminee(3, "Nguyễn Văn A", 5, 6, 7, 8),
                new ProExaminee(4, "Nguyễn Văn A", 5, 6, 7, 8)
            };
            return list;
        }
    }
}
