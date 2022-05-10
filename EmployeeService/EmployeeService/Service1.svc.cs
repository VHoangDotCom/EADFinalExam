using EmployeeService.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DBExamContext db;

        public Service1()
        {
            db = new DBExamContext();
        }

        public Employee Create(Employee employee)
        {
            if (employee == null)
            {
                return null;
            }
            db.Employee.AddOrUpdate(employee);
            db.SaveChanges();
            return employee;
        }

        public List<Employee> FindAll()
        {
            return db.Employee.ToList();
        }

        public List<Employee> FindAllEmp()
        {
            throw new NotImplementedException();
        }

        public List<Employee> FindByDepartment(string department)
        {
            var listEmployee = db.Employee.Where(s => s.Department.Contains(department)).ToList();
            return listEmployee;
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Salary { get; set; }

        public string Department { get; set; }
    }

  
}
