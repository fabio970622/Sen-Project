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
    
    public class Client_Configuration
    {
        public string message = "Procedure Successful";
        public string Prioritylevel = "";
        private int clientconfigid;

        public int ClientConfigID
        {
            get { return clientconfigid; }
            set { clientconfigid = value; }
        }

        private int productid;

        public int ProductId
        {
            get { return productid; }
            set { productid = value; }
        }

        private string productname;

        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }
        private string productuniqueid;

        public string ProductUniqueId
        {
            get { return productuniqueid; }
            set { productuniqueid = value; }
        }


        public Client_Configuration(int clientconfigid, int productid, string productname, string productuniqueid)
        {
            this.ClientConfigID = clientconfigid;
            this.ProductId = productid;
            this.ProductName = productname;
            this.ProductUniqueId = productuniqueid;
        }
        public Client_Configuration()
        {

        }
        public List<Client_Configuration> PopulateClient_Configuration()
        {
            List<Client_Configuration> Client_ConfigurationList = new List<Client_Configuration>();
            Datahandler dh = new Datahandler();
            DataSet ds = dh.ReadData("ClientConfig");

            foreach (DataRow item in ds.Tables["ClientConfig"].Rows)
            {
                Client_ConfigurationList.Add(
                    new Client_Configuration(int.Parse(item["Client Config ID"].ToString()),
                    int.Parse(item["Product ID"].ToString()),
                    item["Product Name"].ToString(),
                    item["Product Unique ID"].ToString()));

            }
            return Client_ConfigurationList;
        }
        public string InsertClientConfiguration(int productid, string productname,string productuniqueid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.InsertClientConfiguration(productid, productname, productuniqueid);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

            
        }

        public string UpdateClientConfiguration(ArrayList list)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.UpdateClientConfiguration(list);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

            
        }

        public string DeleteClientConfiguration(int clientconfigid)
        {
            Datahandler dh = new Datahandler();
            try
            {
                dh.DeleteClientConfiguration(clientconfigid);
            }
            catch (MyException e)
            {
                message = e.Message;
                return message;
            }


            return message;

            
        }
        
        public string BuildUniqueProductId(string urgency,string type,string dateissued,int productid)
        {
            
            switch (urgency)
            {
                case "critical":
                    Prioritylevel = "A";
                    break;
                case "high":
                    Prioritylevel = "B";
                    break;
                case "medium":
                    Prioritylevel = "C";
                    break;
                case "low":
                    Prioritylevel = "D";
                    break;

                default:
                    break;
            }
            string firstlettertype = type.Substring(0, 1);
            string yearissue = dateissued.Substring(0, 4);

            string numericnum = "000000";
            int number = productid.ToString().Length;
            int numericlength = numericnum.Length;
            string newvalue = numericnum.Remove((5 - number), number);
            string finalnumeric = newvalue + productid;
            string uniqueid = yearissue + firstlettertype + Prioritylevel + finalnumeric;
            return uniqueid;
        }
    }
}
