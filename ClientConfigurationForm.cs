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
    public partial class ClientConfigurationForm : Form
    {
        public ClientConfigurationForm()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void ClientConfigurationForm_Load(object sender, EventArgs e)
        {
            RefreshingClientConfigurationform();
        }
        public void RefreshingClientConfigurationform()
        {
            bs.DataSource = new Client_Configuration().PopulateClient_Configuration();
            dgvClientConfiguration.DataSource = null;
            dgvClientConfiguration.DataSource = bs;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddClientConfig_Click(object sender, EventArgs e)
        {
            List<Client_Configuration> morethanoneproduct = new List<Client_Configuration>();

            foreach (var item in morethanoneproduct)
            {
                if (item.ProductUniqueId==txtProductID.Text)
                {
                    MessageBox.Show("Only one product per client", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto skip;
                }
                else
                {
                    break;
                }
            }
            try
            {
                int productid = int.Parse(txtProductID.Text);
                string productname = txtProductName.Text;
                string productuniqueid = txtProductUniqueId.Text;
                Client_Configuration config = new Client_Configuration();
                string message = config.InsertClientConfiguration(productid, productname,productuniqueid);
                


                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshingClientConfigurationform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            skip:;
        }

        private void btnUpdateClientConfigID_Click(object sender, EventArgs e)
        {
 
            try
            {
                int configid = ((Client_Configuration)bs.Current).ClientConfigID;
                ArrayList dataParams = new ArrayList();
                dataParams.Add(int.Parse(txtProductID.Text));
                dataParams.Add(txtProductName.Text);
                dataParams.Add(txtProductUniqueId.Text);
                dataParams.Add(configid);
                string message = new Client_Configuration().UpdateClientConfiguration(dataParams);
              


               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                RefreshingClientConfigurationform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteClientConfigID_Click(object sender, EventArgs e)
        {
            Client_Configuration config = (Client_Configuration)bs.Current;
            string message =config.DeleteClientConfiguration(config.ClientConfigID);
         

               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            RefreshingClientConfigurationform();
        }

        private void dgvClientConfiguration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClientConfiguration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtClientConfigID.DataBindings.Count > 0)
                txtClientConfigID.DataBindings.RemoveAt(0);
            if (txtProductID.DataBindings.Count > 0)
                txtProductID.DataBindings.RemoveAt(0);
            if (txtProductName.DataBindings.Count > 0)
                txtProductName.DataBindings.RemoveAt(0);
            if (txtProductUniqueId.DataBindings.Count > 0)
                txtProductUniqueId.DataBindings.RemoveAt(0);


            try
            {
                // The code binds column index 2 to the TextBox control
                txtClientConfigID.DataBindings.Add(
                    new Binding("Text", dgvClientConfiguration[0, e.RowIndex], "Value", false));
                txtProductID.DataBindings.Add(
        new Binding("Text", dgvClientConfiguration[1, e.RowIndex], "Value", false));
                txtProductName.DataBindings.Add(
        new Binding("Text", dgvClientConfiguration[2, e.RowIndex], "Value", false));
                txtProductUniqueId.DataBindings.Add(
        new Binding("Text", dgvClientConfiguration[3, e.RowIndex], "Value", false));

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select on the record you wish to view", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnSearchClientConfigID_Click(object sender, EventArgs e)
        {
            dgvClientConfiguration.ClearSelection();

            foreach (DataGridViewRow row in dgvClientConfiguration.Rows)
            {
                int rowindex = Convert.ToInt32(row.Cells["ClientConfigID"].Value);

                if (rowindex == int.Parse(txtSearchClientConfigID.Text))
                {
                    row.Selected = true;
                }

            }
        }
    }
}
