using Session1_2.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session1_2.view
{
    public partial class ChangeRole : Form
    {
        Process process;
        int UserID;
        public ChangeRole(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            LoadOffice();
            
        }

        private void LoadAllLabel()
        {
            process = new Process();
            string query = "SELECT * FROM Users WHERE ID = @CurrentID";
            SqlDataReader reader = process.SqlDataReader(query, new string[] { "CurrentID" }, new object[] { UserID });
            if(reader.Read())
            {
                txtEmail.Text = (string)reader["Email"];
                txtFirstname.Text = (string)reader["Firstname"];
                txtLastName.Text = (string)reader["Lastname"];
                if ((int)reader["RoleID"] == 1)
                    radAdmin.Checked = true;
                else
                    radUser.Checked = true;
                cboOffice.SelectedValue = (int)reader["OfficeID"];
            }
        }

        private void LoadOffice()
        {
            process = new Process();
            string query = "SELECT * FROM Offices";
            cboOffice.DataSource = process.SqlSelect(query, new string[] { }, new object[] { });
            cboOffice.DisplayMember = "Title";
            cboOffice.ValueMember = "ID";
            LoadAllLabel();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            process = new Process();
            string query = "UPDATE Users "
                +"SET RoleID = @roleID,Email = @email,FirstName = @fname,LastName = @lname,OfficeID=@officeID "
                +"WHERE ID = @id";
            string[] para = { "roleID", "email", "fname", "lname", "officeID", "id" };
            object[] values = { 
                (radAdmin.Checked) ? 1 : 2, 
                txtEmail.Text.Trim(), 
                txtFirstname.Text.Trim(), 
                txtLastName.Text.Trim(), 
                Convert.ToInt32(cboOffice.SelectedValue.ToString()),
                UserID
            };

            int rec = process.SqlNonQuery(query, para, values);
            if (rec >= 0)
                MessageBox.Show("Successfully");
            this.Visible = false;
        }
    }
}
