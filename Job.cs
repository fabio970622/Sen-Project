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
    public class Job
    { 
    public string message = "Procedure Successful";
        private int jobid;

        public int JobId
        {
            get { return jobid; }
            set { jobid = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string startdate;

        public string StartDate
        {
            get { return startdate; }
            set { startdate = value; }
        }

        private string enddate;

        public string EndDate
        {
            get { return enddate; }
            set { enddate = value; }
        }

        private int productid;

        public int ProductId
        {
            get { return productid; }
            set { productid = value; }
        }

        private int locationid;

        public int LocationId
        {
            get { return locationid; }
            set { locationid = value; }
        }
        public Job(int jobid, string type, string status, string startdate, string enddate, int productid, int locationid)
        {
            this.JobId = jobid;
            this.Type = type;
            this.Status = status;
            this.StartDate = startdate;
            this.EndDate = enddate;
            this.ProductId = productid;
            this.LocationId = locationid;
        }
        public Job()
        {

        }
        public List<Job> PopulateJob()
        {
            List<Job> JobList = new List<Job>();
            Datahandler dh = new Datahandler();
            DataSet ds = dh.ReadData("Job");

            foreach (DataRow item in ds.Tables["Job"].Rows)
            {
                JobList.Add(
                    new Job(int.Parse(item["Job ID"].ToString()),
                    item["Type"].ToString(),
                    item["Status"].ToString(),
                    item["Start Date"].ToString(),
                    item["End Date"].ToString(),
                    int.Parse(item["Product ID"].ToString()),
                    int.Parse(item["Location ID"].ToString())));

            }
            return JobList;
        }
        public string InsertJob(string type, string status, string startdate, string enddate, int productid, int locationid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.InsertJob(type, status, startdate, enddate, productid, locationid);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

          
        }

        public string UpdateJob(ArrayList list)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.UpdateJob(list);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

          
        }

        public string DeleteJob(int jobid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.DeleteJob(jobid);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;


          
        }
        public Stack<string> Queue(List<string> Result)
        {
            Stack<string> FinalQueue = new Stack<string>();
            foreach (var item in Result)
            {
                if (item.Contains("A"))
                {
                    FinalQueue.Push(item);
                }
                else
                {
                    if (item.Contains("B"))
                    {
                        FinalQueue.Push(item);
                    }
                    else
                    {
                        if (item.Contains("C"))
                        {
                            FinalQueue.Push(item);
                        }
                        else
                        {
                            if (item.Contains("D"))
                            {
                                FinalQueue.Push(item);
                            }
                        }
                    }
                }
            }
            return FinalQueue;
        }

    }
}
