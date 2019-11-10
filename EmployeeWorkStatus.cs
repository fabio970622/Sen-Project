using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogicLayer
{
    public class EmployeeWorkStatus:Employee
    {
        public EmployeeWorkStatus()
        {

        }

        public void GetAssignedEmployees()
        {
            
            List<Technical_Team> TeamInfo = new Technical_Team().PopulateTechnical_Team();
            List<int> TeamDetails = new List<int>();
            foreach (var item in TeamInfo)
            {
                TeamDetails.Add(item.EmployeeId);
                TeamDetails.Add(item.EmployeeId2);
                TeamDetails.Add(item.EmployeeId3);
                TeamDetails.Add(item.EmployeeId4);
            }
            List<Employee> EmployeeInfo = new Employee().PopulateEmployee();
            List<int> Assigned = new List<int>();
            List<int> Unassigned = new List<int>();
            foreach (var item in EmployeeInfo)
            {
                if (TeamDetails.Contains(item.EmployeeId))
                {
                    Assigned.Add(item.EmployeeId);
                }
                else
                {
                    Unassigned.Add(item.EmployeeId);
                }
                
            }
            foreach (var item in Assigned)
            {
                UpdateEmployeeStatus("Assigned", item);
            }
            foreach (var item in Unassigned)
            {
                UpdateEmployeeStatus("Unassigned", item);
            }


        }

    }
}
