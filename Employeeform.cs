using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Collections;

namespace Presentation_Layer
{
    public partial class Employeeform : Form
    {
        public Employeeform()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void Employeeform_Load(object sender, EventArgs e)
        {
            RefreshingEmployeeform();
        }
        public void RefreshingEmployeeform()
        {
            bs.DataSource = new Employee().PopulateEmployee();
            dgvEmployee.DataSource = null;
            dgvEmployee.DataSource = bs;

        }

        private void btnSearchEmployeeID_Click(object sender, EventArgs e)
        {
            dgvEmployee.ClearSelection();

            foreach (DataGridViewRow row in dgvEmployee.Rows)
            {
                int rowindex = Convert.ToInt32(row.Cells["EmployeeId"].Value);

                if (rowindex == int.Parse(txtSearchEmployeeID.Text))
                {
                    row.Selected = true;
                }

            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = (Employee)bs.Current;
            string message = emp.DeleteEmployee(emp.EmployeeId);



               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            RefreshingEmployeeform();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
          
            try
            {
                int employeeid = ((Employee)bs.Current).EmployeeId;
                ArrayList dataParams = new ArrayList();
                dataParams.Add(txtEmployeeName.Text);
                dataParams.Add(txtEmployeeSurname.Text);
                dataParams.Add(int.Parse(txtDepartmentId.Text));
                dataParams.Add(txtEmployeeJobDescription.Text);
                dataParams.Add(txtUsername.Text);
                dataParams.Add(txtPassword.Text);
                dataParams.Add(txtEmployeeStatus.Text);
                dataParams.Add(employeeid);
                string message = new Employee().UpdateEmployee(dataParams);
              


               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshingEmployeeform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
 
            try
            {
                string employeename = txtEmployeeName.Text;
                string employeesurname = txtEmployeeSurname.Text;
                string jobdescription = txtEmployeeJobDescription.Text;
                int departmentid = int.Parse(txtDepartmentId.Text);
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string employeestatus = txtEmployeeStatus.Text;
                if (employeestatus==null)
                {
                    employeestatus = "Unassigned";
                }
                Employee emp = new Employee();
                string message = emp.InsertEmployee(employeename, employeesurname, departmentid, jobdescription, username, password, employeestatus);
           


               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshingEmployeeform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtEmployeeId.DataBindings.Count > 0)
                txtEmployeeId.DataBindings.RemoveAt(0);
            if (txtEmployeeName.DataBindings.Count > 0)
                txtEmployeeName.DataBindings.RemoveAt(0);
            if (txtEmployeeSurname.DataBindings.Count > 0)
                txtEmployeeSurname.DataBindings.RemoveAt(0);
            if (txtDepartmentId.DataBindings.Count > 0)
                txtDepartmentId.DataBindings.RemoveAt(0);
            if (txtEmployeeJobDescription.DataBindings.Count > 0)
                txtEmployeeJobDescription.DataBindings.RemoveAt(0);
            if (txtUsername.DataBindings.Count > 0)
                txtUsername.DataBindings.RemoveAt(0);
            if (txtPassword.DataBindings.Count > 0)
                txtPassword.DataBindings.RemoveAt(0);
            if (txtEmployeeStatus.DataBindings.Count > 0)
                txtEmployeeStatus.DataBindings.RemoveAt(0);

            try
            {
                // The code binds column index 2 to the TextBox control
                txtEmployeeId.DataBindings.Add(
                    new Binding("Text", dgvEmployee[0, e.RowIndex], "Value", false));
                txtEmployeeName.DataBindings.Add(
        new Binding("Text", dgvEmployee[1, e.RowIndex], "Value", false));
                txtEmployeeSurname.DataBindings.Add(
        new Binding("Text", dgvEmployee[2, e.RowIndex], "Value", false));
                txtDepartmentId.DataBindings.Add(
        new Binding("Text", dgvEmployee[3, e.RowIndex], "Value", false));
                txtEmployeeJobDescription.DataBindings.Add(
        new Binding("Text", dgvEmployee[4, e.RowIndex], "Value", false));
                txtUsername.DataBindings.Add(
        new Binding("Text", dgvEmployee[5, e.RowIndex], "Value", false));
                txtPassword.DataBindings.Add(
        new Binding("Text", dgvEmployee[6, e.RowIndex], "Value", false));
                txtEmployeeStatus.DataBindings.Add(
        new Binding("Text", dgvEmployee[7, e.RowIndex], "Value", false));

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select on the record you wish to view", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
