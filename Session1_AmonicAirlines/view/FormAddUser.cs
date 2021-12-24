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
    public partial class FormAddUser : Form
    {
        Process process;
        Users users;
        public FormAddUser()
        {
            InitializeComponent();
            LoadOffice();
        }

        private void LoadOffice()
        {
            process = new Process();
            string query = "SELECT * FROM Offices";
            cboOffice.DataSource = process.SqlSelect(query, new string[] { }, new object[] { });
            cboOffice.DisplayMember = "Title";
            cboOffice.ValueMember = "ID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            process = new Process();
            users = new Users();
            int d = int.Parse(txtBirth.Text.Substring(0, 2));
            int m = int.Parse(txtBirth.Text.Substring(3, 2));
            int y = int.Parse(txtBirth.Text.Substring(6, 2));
            y = (y < 2) ? y += 2000 : y += 1900;

            DateTime date = new DateTime(y, m, d);

            string[] para = { "email", "pass", "firstname", "lastname", "officeID", "birth" };
            object[] values = { 
                txtEmail.Text.Trim(),
                users.createMD5(txtPass.Text.Trim()),
                txtFirstname.Text.Trim(),
                txtLastName.Text.Trim(),
                Convert.ToInt32(cboOffice.SelectedValue.ToString()),
                date.ToString("yyyy-MM-dd") 
            };
            int rec = process.SqlSPNonQuery("spNew_InsertUser", para, values);
            if (rec > 0)
                MessageBox.Show("Successfully");
            this.Close();
        }
    }
}
