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
    public partial class TechnicalTeamform : Form
    {
        public TechnicalTeamform()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Employeeform EmployeeInfo = new Employeeform();
            EmployeeInfo.Show();
        }
        BindingSource bs = new BindingSource();
        private void TechnicalTeamform_Load(object sender, EventArgs e)
        {
            RefreshingTechnicalTeamform();
        }
        public void RefreshingTechnicalTeamform()
        {
            bs.DataSource = new Technical_Team().PopulateTechnical_Team();
            dgvTechnicalTeam.DataSource = null;
            dgvTechnicalTeam.DataSource = bs;
        }

        private void btnSearchTeamID_Click(object sender, EventArgs e)
        {
            dgvTechnicalTeam.ClearSelection();

            foreach (DataGridViewRow row in dgvTechnicalTeam.Rows)
            {
                int rowindex = Convert.ToInt32(row.Cells["TeamId"].Value);

                if (rowindex == int.Parse(txtSearchTeamID.Text))
                {
                    row.Selected = true;
                }

            }
        }

        private void btnJob_Click(object sender, EventArgs e)
        {
            Jobform JobInfo = new Jobform();
            JobInfo.Show();
        }

        private void btnDeleteTechnicalTeam_Click(object sender, EventArgs e)
        {
            Technical_Team tech = (Technical_Team)bs.Current;
            string message=tech.DeleteTechnicalTeam(tech.TeamId);
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            RefreshingTechnicalTeamform();
        }

        private void btnUpdateTechnicalTeam_Click(object sender, EventArgs e)
        {

            try
            {
                int teamid = ((Technical_Team)bs.Current).TeamId;
                ArrayList dataParams = new ArrayList();
                dataParams.Add(int.Parse(txtJobID.Text));
                dataParams.Add(int.Parse(txtEmployee1ID.Text));
                dataParams.Add(int.Parse(txtEmployee2ID.Text));
                dataParams.Add(int.Parse(txtEmployee3ID.Text));
                dataParams.Add(int.Parse(txtEmployee4ID.Text));
                dataParams.Add(teamid);
                string message = new Technical_Team().UpdateTechnicalTeam(dataParams);
                
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshingTechnicalTeamform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTechnicalTeam_Click(object sender, EventArgs e)
        {

            try
            {
                int jobid = int.Parse(txtJobID.Text);
                int empid1 = int.Parse(txtEmployee1ID.Text);
                int empid2 = int.Parse(txtEmployee2ID.Text);
                int empid3 = int.Parse(txtEmployee3ID.Text);
                int empid4 = int.Parse(txtEmployee4ID.Text);

                Technical_Team tech = new Technical_Team();
                string message = tech.InsertTechnicalTeam(jobid, empid1, empid2, empid3, empid4);
                
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshingTechnicalTeamform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            TechnicalDepartmentView TechnicalTeamView = new TechnicalDepartmentView();
            TechnicalTeamView.Show();
        }

        private void dgvTechnicalTeam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtTeamId.DataBindings.Count > 0)
                txtTeamId.DataBindings.RemoveAt(0);
            if (txtJobID.DataBindings.Count > 0)
                txtJobID.DataBindings.RemoveAt(0);
            if (txtEmployee1ID.DataBindings.Count > 0)
                txtEmployee1ID.DataBindings.RemoveAt(0);
            if (txtEmployee2ID.DataBindings.Count > 0)
                txtEmployee2ID.DataBindings.RemoveAt(0);
            if (txtEmployee3ID.DataBindings.Count > 0)
                txtEmployee3ID.DataBindings.RemoveAt(0);
            if (txtEmployee4ID.DataBindings.Count > 0)
                txtEmployee4ID.DataBindings.RemoveAt(0);


            try
            {
                // The code binds column index 2 to the TextBox control
                txtTeamId.DataBindings.Add(
                    new Binding("Text", dgvTechnicalTeam[0, e.RowIndex], "Value", false));
                txtJobID.DataBindings.Add(
        new Binding("Text", dgvTechnicalTeam[1, e.RowIndex], "Value", false));
                txtEmployee1ID.DataBindings.Add(
        new Binding("Text", dgvTechnicalTeam[2, e.RowIndex], "Value", false));
                txtEmployee2ID.DataBindings.Add(
        new Binding("Text", dgvTechnicalTeam[3, e.RowIndex], "Value", false));
                txtEmployee3ID.DataBindings.Add(
        new Binding("Text", dgvTechnicalTeam[4, e.RowIndex], "Value", false));
                txtEmployee4ID.DataBindings.Add(
new Binding("Text", dgvTechnicalTeam[5, e.RowIndex], "Value", false));
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select on the record you wish to view", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
