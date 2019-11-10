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
    public partial class EmployeeStatus : Form
    {
        List<Employee> EmployeeStatusTree;
        public EmployeeStatus()
        {
            InitializeComponent();
        }
        private void EmployeeStatus_Load(object sender, EventArgs e)
        {
            RefreshingEmployeeStatusform();
            
        }
        public void RefreshingEmployeeStatusform()
        {
            new EmployeeWorkStatus().GetAssignedEmployees();
            EmployeeStatusTree = new Employee().PopulateEmployeeStatus();
            PopulateTreeView(EmployeeStatusTree);

        }
        private void PopulateTreeView(List<Employee> dtParent)
        {
            TreeNode treeNode = new TreeNode();
            List<string> Empstatus = new List<string>();
            foreach (var item in dtParent)
            {
                if (Empstatus.Contains("Assigned"))
                {
                    if (Empstatus.Contains("Unassigned"))
                    {
                        break;
                    }
                    else
                    {
                        if (item.EmployeeStatus == "Unassigned")
                        {
                            Empstatus.Add(item.EmployeeStatus);
                        }
                    }
                }
                else
                {
                    if (item.EmployeeStatus == "Assigned")
                    {

                        Empstatus.Add(item.EmployeeStatus);
                    }
                }
              
            }
            foreach (var item in Empstatus)
            {
                treeNode = tvEmployeeStatus.Nodes.Add(item.ToString());
        //        //Display Parent node and ID number
             
                PopulateTreeViewChild(item.ToString(), treeNode);
            }
        //    //The ExpandAll method expands all the TreeNode objects, which includes all the child tree nodes, 
        //    //that are in the TreeView control.
            tvEmployeeStatus.ExpandAll();
        }
        private void PopulateTreeViewChild(string parentId, TreeNode ParentNode)
        {

            //Child Node Selection
            List<int> Empid = new List<int>();
            foreach (var item in EmployeeStatusTree)
            {
                if (item.EmployeeStatus==parentId)
                {
                    Empid.Add(item.EmployeeId);
                }
            }
            TreeNode childnode = new TreeNode();
            foreach (var item in Empid)
            {
                if (ParentNode == null)
                    childnode = tvEmployeeStatus.Nodes.Add(item.ToString());
                else
                    childnode = ParentNode.Nodes.Add(item.ToString());

            }

        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Close();
            Employeeform EmployeeForm = new Employeeform();
            EmployeeForm.Show();
        }
    }
}
