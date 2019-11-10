using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace DataAccessLayer
{
    public class Datahandler
    {
        SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

        public Datahandler()
        {
            connection.DataSource = @"DESKTOP-3ORQK5F\SQLEXPRESS";
            connection.InitialCatalog = "SmartSystem";
            connection.IntegratedSecurity = true;
        }

        public DataSet ReadData(string tableName)
        {
            DataSet rawData = new DataSet();
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("SELECT * FROM {0}", tableName);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, conn);
                adapter.FillSchema(rawData, SchemaType.Source, tableName);
                adapter.Fill(rawData, tableName);
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rawData;
        }
        public DataSet ReadDataEmployeeStatus(string tableName,string employeeid, string employeestatus)
        {
            DataSet rawData = new DataSet();
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("SELECT [{1}],[{2}] FROM {0}", tableName,employeeid,employeestatus);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, conn);
                adapter.FillSchema(rawData, SchemaType.Source, tableName);
                adapter.Fill(rawData, tableName);
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return rawData;
        }
        #region Insertingdata
        public void InsertClientConfiguration(int productid, string productname,string productuniqueid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "ClientConfig ([Product ID], [Product Name],[Product Unique ID])" +
                "VALUES ({0},'{1}','{2}')", productid, productname);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertClient(string clientname, int clienttelno, string clientemail, int locationid, int clientconfigid, int billingid, string password,string clientuniqueid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "Client ([Client Name], [Client TelNo], [Client Email], [Location ID], [Client Config ID], [Billing ID], [Password],[Client Unique ID])" +
                "VALUES ('{0}',{1},'{2}',{3},{4},{5},'{6}','{7}')", clientname, clienttelno, clientemail, locationid, clientconfigid, billingid, password);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertDepartment(string departmentname)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "Department ([Department Name])" +
                "VALUES ('{0}')", departmentname);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertEmployee(string employeename, string employeesurname, int departmentid, string employeejobdescription, string employeeusername, string employeepassword, string employeestatus)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "Employee ([Employee Name], [Employee Surname], [Department ID], [Employee Job Description], [Employee Username], [Employee Password], [Employee Status])" +
                "VALUES ('{0}','{1}',{2},'{3}','{4}','{5}','{6}')", employeename, employeesurname, departmentid, employeejobdescription, employeeusername, employeepassword,employeestatus);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertJob(string type, string status, string startdate, string enddate, int productid, int locationid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "Job ([Type], [Status], [Start Date], [End Date], [Product ID], [Location ID])" +
                "VALUES ('{0}','{1}','{2}','{3}',{4},{5})", type, status, startdate, enddate, productid, locationid);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertLocation(string streetaddress, string country, string province, string city, int postalcode)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "Location ([Street Address], [Country], [Province], [City], [Postal Code])" +
                "VALUES ('{0}','{1}','{2}','{3}',{4})", streetaddress, country, province, city, postalcode);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertBilling(string billingdetails, double billingamount)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "MonthlyBilling ([Billing Details], [Billing Amount])" +
                "VALUES ('{0}',{1})",billingdetails, billingamount);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertProduct(string productname, string producttype, double productcost, int productquantity)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "Product ([Product Name], [Product Type], [Product Cost], [Product Quantity])" +
                "VALUES ('{0}','{1}',{2},{3})",productname, producttype, productcost, productquantity);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void InsertTechnicalTeam(int jobid, int employeeid, int employeeid2, int employeeid3, int employeeid4)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("INSERT INTO " +
                "TechnicalTeam ([Job ID], [Employee ID], [Employee ID 2], [Employee ID 3], [Employee ID 4])" +
                "VALUES ({0},{1},{2},{3},{4})",jobid,employeeid, employeeid2, employeeid3, employeeid4);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion
        #region UpdateData
        public void UpdateClientConfiguration(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE ClientConfig Set [Product ID] = {0}, [Product Name]='{1}',[Product Unique ID]='{2}' Where [Client Config ID] = {3}",
                list[0], list[1], list[2],list[3]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateClient(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [Client] Set [Client Name]='{0}', [Client TelNo]={1}, [Client Email]= '{2}', [Location ID] ={3}, [Client Config ID] = {4}, [Billing ID] = {5}, [Password]= '{6}',[Client Unique ID]='{7}' Where [Client ID] = {8}"
                , list[0], list[1], list[2], list[3], list[4], list[5], list[6], list[7],list[8]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateDepartment(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [Department] Set [Department Name]='{0}' Where [Department ID] = {1} "
                , list[0], list[1]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateEmployee(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [Employee] Set [Employee Name] = '{0}', [Employee Surname] = '{1}', [Department ID] = {2}, [Employee Job Description] = '{3}', [Employee Username] = '{4}', [Employee Password] = '{5}', [Employee Status] = {6} Where [Employee ID]= {7}"
                , list[0], list[1], list[2], list[3], list[4], list[5], list[6],list[7]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateEmployeeStatus(string employeestatus, int employeeid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [Employee] Set [Employee Status] = '{0}' Where [Employee ID]= {1}"
                , employeestatus, employeeid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateJob(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [Job] Set [Type]='{0}', [Status] = '{1}', [Start Date] ='{2}', [End Date] = '{3}', [Product ID] = {4}, [Location ID] = {5} Where [Job ID] = {6}"
                , list[0], list[1], list[2], list[3], list[4], list[5], list[6]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateLocation(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [Location] Set [Street Address] = '{0}', [Country] = '{1}', [Province] = '{2}', [City] = '{3}', [Postal Code] = {4} Where [Location ID] = {5}"
                , list[0], list[1], list[2], list[3], list[4], list[5]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateBilling(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [MonthlyBilling] Set [Billing Details] = '{0}', [Billing Amount] ={1} Where [Billing ID] = {2} "
                , list[0], list[1], list[2]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateProduct(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [Product] Set [Product Name] = '{0}', [Product Type] = '{1}', [Product Cost] = {2}, [Product Quantity] = {3} Where [Product ID] = {4}"
                , list[0], list[1], list[2], list[3], list[4]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void UpdateTechnicalTeam(ArrayList list)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("UPDATE [TechnicalTeam] Set [Job ID] = {0}, [Employee ID] = {1}, [Employee ID 2] = {2}, [Employee ID 3] ={3}, [Employee ID 4] ={4} Where [Team ID] ={5}"
                , list[0], list[1], list[2], list[3], list[4], list[5]);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                
                
            }
            
        }
        #endregion
        #region DeleteData
        public void DeleteClientConfiguration(int clientconfigid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [ClientConfig] Where [Client Config ID] = {0}", clientconfigid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteClient(int clientid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [Client] Where [Client ID]= {0}", clientid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteDepartment(int departmentid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [Department] Where [Department ID]= {0}", departmentid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteEmployee(int employeeid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [Employee] Where [Employee ID] = {0}", employeeid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteJob(int jobid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [Job] Where [Job ID]= {0}", jobid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteLocation(int locationid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [Location] Where [Location ID] = {0}", locationid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteBilling(int billingid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [MonthlyBilling] Where [Billing ID] =  {0}", billingid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteProduct(int productid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [Product] Where [Product ID] = {0}", productid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public void DeleteTechnicalTeam(int teamid)
        {
            SqlConnection conn = new SqlConnection(connection.ToString());
            string qry = string.Format("DELETE [TechnicalTeam] Where [Team ID] = {0}", teamid);

            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(qry, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        #endregion

    }
}
