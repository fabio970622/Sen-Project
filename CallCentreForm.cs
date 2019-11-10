using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BusinessLogicLayer;
using System.Threading;

namespace Presentation_Layer
{
    

    public partial class CallCentreForm : Form
    {
        public static string Result = "";
        BackgroundWorker bWorker;
        public CallCentreForm()
        {
            InitializeComponent();

        }
        private void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {

                Thread.Sleep(100);
                bWorker.ReportProgress(i);

                if (bWorker.CancellationPending)
                {

                    e.Cancel = true;
                    bWorker.ReportProgress(0);
                    return;
                }
            }
            bWorker.ReportProgress(100);
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            pbFillup.Value = e.ProgressPercentage;
            lblProgress.Text = "Processing......" + pbFillup.Value.ToString() + "%";
        }
        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                lblProgress.Text = "Call Ended";
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                lblProgress.Text = "Error while performing background operation.";
            }
            else
            {
                // Everything completed normally.
                lblProgress.Text = "Call Connected";
            }

            //Change the status of the buttons on the UI accordingly
            btnCall.Enabled = true;
            btnCallEnd.Enabled = false;
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            btnCall.Enabled = false;
            btnCallEnd.Enabled = true;
            bWorker.RunWorkerAsync();
            string clientid = Interaction.InputBox("What is your clientid");
            string urgency = Interaction.InputBox("How urgent do you need our help?\nCritical\nHigh\nMedium\nLow");

            string Workneeded = Interaction.InputBox("How can we help you? Do you wish to upgrade, maintaince,installation?");
            if (Workneeded == "upgrade")
            {
                int upgradeproductid = Convert.ToInt32(Interaction.InputBox("What is the productid that you would you like to upgrade to?"));
                string type = Interaction.InputBox("What type of product do you currently have or would like to install");
                string dateissued = DateTime.Now.ToShortDateString();
                MessageBox.Show("We will notify when a technical team will be available to help you", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Result = new Client_Configuration().BuildUniqueProductId(urgency, type, dateissued, upgradeproductid);
            }
            if (Workneeded == "maintaince")
            {
                int maintainproductid = Convert.ToInt32(Interaction.InputBox("What is the productid of your current product?"));
                string type = Interaction.InputBox("What type of product do you currently have or would like to install");
                string dateissued = Interaction.InputBox("What was the date that your current product was issued to you? Format: YYYY/MM/DD");
                Result = new Client_Configuration().BuildUniqueProductId(urgency, type, dateissued, maintainproductid);
                MessageBox.Show("We will notify when a technical team will be available to help you", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Workneeded == "installation")
            {

                int productid = Convert.ToInt32(Interaction.InputBox("What is the productid that you would you like to install?"));
                string type = Interaction.InputBox("What type of product would you like to install?");
                string dateissued = DateTime.Now.ToShortDateString();
                Result = new Client_Configuration().BuildUniqueProductId(urgency, type, dateissued, productid);
                MessageBox.Show("We will notify when a technical team will be available to help you", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

            }


        }

        private void CallCentreForm_Load(object sender, EventArgs e)
        {
            bWorker = new BackgroundWorker();
            bWorker.DoWork += new DoWorkEventHandler(bWorker_DoWork);
            bWorker.ProgressChanged += new ProgressChangedEventHandler
                  (bWorker_ProgressChanged);
            bWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (bWorker_RunWorkerCompleted);
            bWorker.WorkerReportsProgress = true;
            bWorker.WorkerSupportsCancellation = true;
        }

        private void btnCallEnd_Click(object sender, EventArgs e)
        {
            if (bWorker.IsBusy)
            {
                bWorker.CancelAsync();
            }
        }
    }
}
