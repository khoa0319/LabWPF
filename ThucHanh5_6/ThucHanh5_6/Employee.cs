using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh5_6
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public Employee()
        {

        }

    }


    public class MyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
