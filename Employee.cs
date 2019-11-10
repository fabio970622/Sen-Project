using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Collections;
using System.Data;

namespace BusinessLogicLayer
{
    public class Employee
    {
        public string message = "Procedure Successful";
        private int employeeid;

        public int EmployeeId
        {
            get { return employeeid; }
            set { employeeid = value; }
        }
        private string employeename;

        public string EmployeeName
        {
            get { return employeename; }
            set { employeename = value; }
        }
        private string employeesurname;

        public string EmployeeSurname
        {
            get { return employeesurname; }
            set { employeesurname = value; }
        }
        private int departmentid;

        public int DepartmentId
        {
            get { return departmentid; }
            set { departmentid = value; }
        }
        private string employeejobdescription;

        public string EmployeeJobDescription
        {
            get { return employeejobdescription; }
            set { employeejobdescription = value; }
        }
        private string employeeusername;

        public string EmployeeUsername
        {
            get { return employeeusername; }
            set { employeeusername = value; }
        }
        private string employeepassword;

        public string EmployeePassword
        {
            get { return employeepassword; }
            set { employeepassword = value; }
        }
        private string employeestatus;

        public string EmployeeStatus
        {
            get { return employeestatus; }
            set { employeestatus = value; }
        }




        public Employee(int employeeid, string employeename, string employeesurname, int departmentid, string employeejobdescription, string employeeusername, string employeepassword, string employeestatus)
        {
            this.EmployeeId = employeeid;
            this.EmployeeName = employeename;
            this.EmployeeSurname = employeesurname;
            this.DepartmentId = departmentid;
            this.EmployeeJobDescription = employeejobdescription;
            this.EmployeeUsername = employeeusername;
            this.EmployeePassword = employeepassword;
            this.EmployeeStatus = employeestatus;
        }
        public Employee(int employeeid, string employeestatus)
        {
            this.EmployeeId = employeeid;
            this.EmployeeStatus = employeestatus;
        }
        public Employee()
        {

        }
        public List<Employee> PopulateEmployee()
        {
            List<Employee> EmployeeList = new List<Employee>();
            Datahandler dh = new Datahandler();
            DataSet ds = dh.ReadData("Employee");

            foreach (DataRow item in ds.Tables["Employee"].Rows)
            {
                EmployeeList.Add(
                    new Employee(int.Parse(item["Employee ID"].ToString()),
                    item["Employee Name"].ToString(),
                    item["Employee Surname"].ToString(),
                    int.Parse(item["Department ID"].ToString()),
                    item["Employee Job Description"].ToString(),
                    item["Employee Username"].ToString(),
                    item["Employee Password"].ToString(),
                    item["Employee Status"].ToString()));

            }
            return EmployeeList;
        }
        public List<Employee> PopulateEmployeeStatus()
        {
            List<Employee> EmployeeStatusList = new List<Employee>();
            Datahandler dh = new Datahandler();
            DataSet ds = dh.ReadDataEmployeeStatus("Employee","Employee ID","Employee Status");

            foreach (DataRow item in ds.Tables["Employee"].Rows)
            {
                EmployeeStatusList.Add(
                    new Employee(int.Parse(item["Employee ID"].ToString()),
                    item["Employee Status"].ToString()));

            }
            return EmployeeStatusList;
        }
        public string InsertEmployee(string employeename, string employeesurname, int departmentid, string employeejobdescription, string employeeusername, string employeepassword, string employeestatus)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.InsertEmployee(employeename, employeesurname, departmentid, employeejobdescription, employeeusername, employeepassword, employeestatus);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

        }
        public string UpdateEmployeeStatus(string employeestatus ,int employeeid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.UpdateEmployeeStatus(employeestatus, employeeid);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

          
        }


        public string UpdateEmployee(ArrayList list)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.UpdateEmployee(list);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

           
        }

        public string DeleteEmployee(int employeeid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.DeleteEmployee(employeeid);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

           
        }
        public Boolean Employeelogin(string username, string password)
        {
            List<Employee> getemployees = new Employee().PopulateEmployee();
            Boolean success = false;


            foreach (var item in getemployees)
            {
                if (item.EmployeeUsername == username && item.EmployeePassword == password && item.DepartmentId == 1)
                {
                    success = true;
                    break;
                }
                else
                {
                    if (item.EmployeeUsername == username && item.EmployeePassword == password && item.DepartmentId == 2)
                    {
                        success = true;
                        break;
                    }
                    else
                    {
                        if (item.EmployeeUsername == username && item.EmployeePassword == password && item.DepartmentId == 3)
                        {
                            success = true;
                            break;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }



            }
            return success;

        }

    }
}
