using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3
{
    public class CupExaminee : Examinee
    {
        public double Database { get; set; }
        public CupExaminee(int id, string name, double subject1, double subject2, double subject3, double database) : base(id, name, subject1, subject2, subject3)
        {
            Database = database;
        }

        public override double GetTotal() => base.GetTotal() + Database;
        public static List<CupExaminee> Getdata()
        {
            var list = new List<CupExaminee>
            {
                new CupExaminee(1, "Nguyễn Văn A", 5, 6, 7, 8),
                new CupExaminee(2, "Nguyễn Văn B", 5, 6, 7, 8),
                new CupExaminee(101, "Bùi Tiến Dũng", 6, 7, 8, 9),
                new CupExaminee(3, "Nguyễn Văn A", 5, 6, 7, 8),
                new CupExaminee(4, "Lê Thanh Tâm", 5, 6, 7, 10)
            };
            return list;
        }
    }
}
