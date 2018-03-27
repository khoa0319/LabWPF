using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh4
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public Employee(string id, string name, DateTime date, string address)
        {
            ID = id;
            Name = name;
            BirthDate = date;
            Address = address;
        }
        public Employee()
        {

        }

        public static List<Employee> GetSampleData() => new List<Employee>
        {
            new Employee("16DH110001", "Nguyễn Văn A", new DateTime(1998, 11, 18), "Gò Công"),
            new Employee("16DH110002", "Nguyễn Văn B", new DateTime(1999, 2, 18), "Gò Công"),
            new Employee("16DH110003", "Nguyễn Văn C", new DateTime(1998, 3, 18), "Gò Công"),
            new Employee("16DH110004", "Nguyễn Văn D", new DateTime(1998, 2, 12), "Gò Công"),
            new Employee("16DH110005", "Nguyễn Văn E", new DateTime(1998, 2, 14), "Gò Công"),
            new Employee("16DH110006", "Nguyễn Văn F", new DateTime(1998, 2, 15), "Gò Công"),
            new Employee("16DH110010", "Nguyễn Văn J", new DateTime(1998, 9, 28), "Gò Công"),
            new Employee("16DH110007", "Nguyễn Văn G", new DateTime(1998, 5, 18), "Gò Công"),
            new Employee("16DH110008", "Nguyễn Văn H", new DateTime(1998, 2, 08), "Gò Công"),
            new Employee("16DH110009", "Nguyễn Văn I", new DateTime(1998, 8, 18), "Gò Công"),
            new Employee("16DH110001", "Nguyễn Văn A", new DateTime(1998, 11, 18), "Gò Công"),
            new Employee("16DH110002", "Nguyễn Văn B", new DateTime(1999, 2, 18), "Gò Công"),
            new Employee("16DH110003", "Nguyễn Văn C", new DateTime(1998, 3, 18), "Gò Công"),
            new Employee("16DH110004", "Nguyễn Văn D", new DateTime(1998, 2, 12), "Gò Công"),
            new Employee("16DH110005", "Nguyễn Văn E", new DateTime(1998, 2, 14), "Gò Công"),
            new Employee("16DH110006", "Nguyễn Văn F", new DateTime(1998, 2, 15), "Gò Công"),
            new Employee("16DH110010", "Nguyễn Văn J", new DateTime(1998, 9, 28), "Gò Công"),
            new Employee("16DH110007", "Nguyễn Văn G", new DateTime(1998, 5, 18), "Gò Công"),
            new Employee("16DH110008", "Nguyễn Văn H", new DateTime(1998, 2, 08), "Gò Công"),
            new Employee("16DH110009", "Nguyễn Văn I", new DateTime(1998, 8, 18), "Gò Công")
        };
    }
}
