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
    public partial class Productform : Form
    {
        public Productform()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void Productform_Load(object sender, EventArgs e)
        {
            RefreshingProductform();
        }
        public void RefreshingProductform()
        {
            bs.DataSource = new Product().PopulateProduct();
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = bs;
        }

        private void btnSearchProductID_Click(object sender, EventArgs e)
        {
            dgvProduct.ClearSelection();

            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                int rowindex = Convert.ToInt32(row.Cells["ProductId"].Value);

                if (rowindex == int.Parse(txtSearchProductID.Text))
                {
                    row.Selected = true;
                }

            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product pro = (Product)bs.Current;
            string message = pro.DeleteProduct(pro.ProductId);
           


               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            RefreshingProductform();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {

            try
            {
                int productid = ((Product)bs.Current).ProductId;
                ArrayList dataParams = new ArrayList();
                dataParams.Add(txtProductName.Text);
                dataParams.Add(txtProductType.Text);
                dataParams.Add(decimal.Parse(txtProductCost.Text));
                dataParams.Add(int.Parse(txtProductQuantity.Text));
                dataParams.Add(productid);
                string message = new Product().UpdateProduct(dataParams);
               


               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshingProductform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string productname = txtProductName.Text;
                string producttype = txtProductType.Text;
                double productcost = Convert.ToDouble(txtProductCost.Text);
                int productquantity = int.Parse(txtProductQuantity.Text);
                Product pro = new Product();
                string message = pro.InsertProduct(productname, producttype, productcost, productquantity);
               


               MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshingProductform();
            }
            catch (FormatException)
            {
                MessageBox.Show("Data entered not correct type of data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
           
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            DepartmentMenuform Menu = new DepartmentMenuform();
            Menu.Show();
        }

        private void dgvProduct_Click(object sender, EventArgs e)
        {
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtProductId.DataBindings.Count > 0)
                txtProductId.DataBindings.RemoveAt(0);
            if (txtProductName.DataBindings.Count > 0)
                txtProductName.DataBindings.RemoveAt(0);
            if (txtProductType.DataBindings.Count > 0)
                txtProductType.DataBindings.RemoveAt(0);
            if (txtProductCost.DataBindings.Count > 0)
                txtProductCost.DataBindings.RemoveAt(0);
            if (txtProductQuantity.DataBindings.Count > 0)
                txtProductQuantity.DataBindings.RemoveAt(0);
            try
            {
                // The code binds column index 2 to the TextBox control
                txtProductId.DataBindings.Add(
                    new Binding("Text", dgvProduct[0, e.RowIndex], "Value", false));
                txtProductName.DataBindings.Add(
        new Binding("Text", dgvProduct[1, e.RowIndex], "Value", false));
                txtProductType.DataBindings.Add(
        new Binding("Text", dgvProduct[2, e.RowIndex], "Value", false));
                txtProductCost.DataBindings.Add(
        new Binding("Text", dgvProduct[3, e.RowIndex], "Value", false));
                txtProductQuantity.DataBindings.Add(
        new Binding("Text", dgvProduct[4, e.RowIndex], "Value", false));
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select on the record you wish to view", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
    }
}
