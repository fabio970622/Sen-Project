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
    
    public class Technical_Team
    {
        public string message = "Procedure Successful";
        private int teamid;

        public int TeamId
        {
            get { return teamid; }
            set { teamid = value; }
        }
        private int jobid;

        public int JobId
        {
            get { return jobid; }
            set { jobid = value; }
        }
        private int employeeid;

        public int EmployeeId
        {
            get { return employeeid; }
            set { employeeid = value; }
        }
        private int employeeid2;

        public int EmployeeId2
        {
            get { return employeeid2; }
            set { employeeid2 = value; }
        }
        private int employeeid3;

        public int EmployeeId3
        {
            get { return employeeid3; }
            set { employeeid3 = value; }
        }

        private int employeeid4;

        public int EmployeeId4
        {
            get { return employeeid4; }
            set { employeeid4 = value; }
        }
        public Technical_Team(int teamid, int jobid, int employeeid, int employeeid2, int employeeid3, int employeeid4)
        {
            this.TeamId = teamid;
            this.JobId = jobid;
            this.EmployeeId = employeeid;
            this.EmployeeId2 = employeeid2;
            this.EmployeeId3 = employeeid3;
            this.EmployeeId4 = employeeid4;
        }
        public Technical_Team()
        {

        }
        public List<Technical_Team> PopulateTechnical_Team()
        {
            List<Technical_Team> Technical_TeamList = new List<Technical_Team>();
            Datahandler dh = new Datahandler();
            DataSet ds = dh.ReadData("TechnicalTeam");

            foreach (DataRow item in ds.Tables["TechnicalTeam"].Rows)
            {
                Technical_TeamList.Add(
                    new Technical_Team(int.Parse(item["Team ID"].ToString()),
                    int.Parse(item["Job ID"].ToString()),
                    int.Parse(item["Employee ID"].ToString()),
                    int.Parse(item["Employee ID 2"].ToString()),
                    int.Parse(item["Employee ID 3"].ToString()),
                    int.Parse(item["Employee ID 4"].ToString())));
            }
            
            return Technical_TeamList;
        }
        
        public string InsertTechnicalTeam(int jobid, int employeeid, int employeeid2, int employeeid3, int employeeid4)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.InsertTechnicalTeam(jobid, employeeid, employeeid2, employeeid3, employeeid4);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;
           
        }

        public string UpdateTechnicalTeam(ArrayList list)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.UpdateTechnicalTeam(list);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;
            
        }

        public string DeleteTechnicalTeam(int teamid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.DeleteTechnicalTeam(teamid);
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
