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
    public class Department
    {
        public string message = "Procedure Successful";
        private int departmentid;

        public int DepartmentId
        {
            get { return departmentid; }
            set { departmentid = value; }
        }

        private string departmentname;

        public string DepartmentName
        {
            get { return departmentname; }
            set { departmentname = value; }
        }
        public Department(int departmentid, string departmentname)
        {
            this.DepartmentId = departmentid;
            this.DepartmentName = departmentname;
        }
        public Department()
        {

        }
        public List<Department> PopulateDepartment()
        {
            List<Department> DepartmentList = new List<Department>();
            Datahandler dh = new Datahandler();
            DataSet ds = dh.ReadData("Department");

            foreach (DataRow item in ds.Tables["Department"].Rows)
            {
                DepartmentList.Add(
                    new Department(int.Parse(item["Department ID"].ToString()),
                    item["Department Name"].ToString()
                   ));

            }
            return DepartmentList;
        }
        public string InsertDepartment(string departmentname)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.InsertDepartment(departmentname);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

          
        }

        public string UpdateDepartment(ArrayList list)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.UpdateDepartment(list);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

            
        }

        public string DeleteDepartment(int departmentid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.DeleteDepartment(departmentid);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

        
        }

    }
}
