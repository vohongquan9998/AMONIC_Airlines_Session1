using Session1_2.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session1_2.view
{
    public partial class FormDetected : Form
    {
        int userId; string loginDate, loginTime;
        public FormDetected(int userId,string loginDate,string loginTime)
        {
            InitializeComponent();
            this.userId = userId;
            this.loginDate = loginDate;
            this.loginTime = loginTime;
            lbShow.Text = "No logout detected for last login on " + loginDate.Substring(0,10) + " at " + loginTime.Substring(0,8);
        }
        Process process;
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            process = new Process();
            string query = "UPDATE LogData " +
                "SET reason = @reason " +
                "WHERE UserID = @userId AND loginDate = @loginDate AND loginTime = @loginTime";
            string[] paras = { "reason", "userId", "loginDate", "loginTime" };
            object[] values = { (radSoftware.Checked) ? radSoftware.Text : (radSystemCrash.Checked) ? radSystemCrash.Text : txtReason.Text, userId,Convert.ToDateTime(loginDate).ToString("yyyy-MM-dd"), loginTime.Substring(0,8) };

            int rec = process.SqlNonQuery(query, paras, values);
            if (rec >= 0)
            {
                MessageBox.Show("Update successfully");
                this.Visible = false;
            }
        }
    }
}
