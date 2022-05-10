using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeService.Data
{
    public class DBExamContext : DbContext
    {
        public DBExamContext() : base("name=FinalExam")
        {
        }
        public DbSet<Employee> Employee { get; set; }
       
    }
}