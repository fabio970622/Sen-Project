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

namespace Presentation_Layer
{
    public partial class Loginform : Form
    {
        public Loginform()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void Loginform_Load(object sender, EventArgs e)
        {

        }

        private void btnClientLogin_Click(object sender, EventArgs e)
        {
            Boolean validate = new Client().Clientlogin(txtClientUsername.Text, txtClientPassword.Text);
            
            if (validate == true)
            {
                MessageBox.Show("Welcome to SmartSchoolSystem", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DepartmentMenuform Menu = new DepartmentMenuform();
                Menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your username or password is not valid", "Login Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEmployeeLogin_Click(object sender, EventArgs e)
        {
            Boolean validate = new Employee().Employeelogin(txtEmployeeUsername.Text,txtEmployeePassword.Text);
 
            if (validate==true)
            {
                MessageBox.Show("Welcome to work", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DepartmentMenuform Menu = new DepartmentMenuform();
                Menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your username or password is not valid", "Login Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
