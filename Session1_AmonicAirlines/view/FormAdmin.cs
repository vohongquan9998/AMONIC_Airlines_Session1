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
    public partial class FormAdmin : Form
    {
        Process process;
        Users users = new Users();
        int CurrentID;
        public FormAdmin(object user)
        {
            InitializeComponent();
            this.users = (Users)user;
            LoadDataAdminAndUser();


        }

        private void LoadComboBoxOffice()
        {
            process = new Process();
            string query = "SELECT * FROM Offices";
            DataTable tb = new DataTable();
            cboOffice.DataSource = tb = process.SqlSelect(query, new string[] {}, new object[] {});
            DataRow row = tb.NewRow();
            row["ID"] = tb.Rows.Count;
            row["Title"] = "All Offices" ;
            tb.Rows.Add(row);
            tb.AcceptChanges();
            cboOffice.DisplayMember = "Title";
            cboOffice.ValueMember = "ID";
            cboOffice.Text = "All Offices";
        }

        
        private void LoadDataAdminAndUser()
        {
            process = new Process();
            dgvAdmin.DataSource = process.SqlSPSelect("spNew_LoadDataTable", new string[] { }, new object[] { });                      
        }

        private void ChangeRowColor()
        {
            dgvAdmin.Columns["ID"].Visible = false;
            foreach (DataGridViewRow r in dgvAdmin.Rows)
            {
                if (Convert.ToString(r.Cells["User Role"].Value).StartsWith("A"))
                {
                    r.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboOffice.Text == "All Offices")
            {
                LoadDataAdminAndUser();
                ChangeRowColor();
            }
            else
            {
                process = new Process();
                dgvAdmin.DataSource = process.SqlSPSelect("spNew_LoadDataTableFromOfficeTitle", new string[] {"Otitle"}, new object[] {cboOffice.Text});
                ChangeRowColor();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new FormAddUser();
            formAddUser.ShowDialog();
        }

        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                DataGridViewRow r = dgvAdmin.Rows[e.RowIndex];
                CurrentID = (int)r.Cells["ID"].Value;
            }
        }

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            ChangeRole changeRole = new ChangeRole(CurrentID);
            changeRole.ShowDialog();
        }

        private void btnChangeActive_Click(object sender, EventArgs e)
        {
            Process processActive = new Process();
            string queryActive = "SELECT ACTIVE FROM Users WHERE ID = @CurrentID";
            SqlDataReader reader = processActive.SqlDataReader(queryActive, new string[] { "CurrentID" }, new object[] { CurrentID });
            bool active = (reader.Read()) ? !(bool)reader["Active"] : (bool)reader["Active"];
            string query = "UPDATE Users " +
                "SET Active = @active " +
                "WHERE ID = @userID";
           int rec =  process.SqlNonQuery(
                query, 
                new string[] {"active","userId"}, 
                new object[] { active, CurrentID }
                );
            if (rec >= 0)
                MessageBox.Show("Updated Successfully");
            LoadDataAdminAndUser();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadComboBoxOffice();
            //LoadDataAdminAndUser();
        }

        private void FormAdmin_Activated(object sender, EventArgs e)
        {
            LoadDataAdminAndUser();
            LoadComboBoxOffice();
        }
    }
}
