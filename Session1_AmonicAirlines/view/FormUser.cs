using Session1_2.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Session1_2.view
{
    public partial class FormUser : Form
    {
        DateTime time;
        DateTime date;
        Users users;
        TimeSpan timeSpent;
        public FormUser(object user)
        {
            InitializeComponent();
            this.users = (Users)user;
            LoadDataTableOfUser();
        }

        private void LoadDataTableOfUser()
        {
            lbName.Text = "Hi " + users.Firstname + ",Welcome to AMONIC Airline";
            timer1.Start();
            date = DateTime.Now.Date;
            time = DateTime.Now;

            //Xu ly crashes
            Process processCrash = new Process();
            string queryCrash = "SELECT COUNT(*) FROM LogData " +
                "WHERE logoutTime IS NULL AND UserID = @id";
            int numofCrashes = processCrash.SqlScalar(queryCrash, new string[] { "id" }, new object[] { users.Id });
            lbNumCrash.Text = numofCrashes.ToString();

            //Xu ly Update Reason

            Process processReason = new Process();
            string queryReason = "SELECT * FROM LogData " +
                "WHERE logoutTime IS NULL AND REASON IS NULL AND UserID=@id";
            SqlDataReader reader = processReason.SqlDataReader(queryReason, new string[] { "id" }, new object[] { users.Id });
            if(reader.Read())
            {
                string loginTimeCrash, loginDateCrash;
                loginDateCrash = reader["loginDate"].ToString();
                loginTimeCrash = reader["loginTime"].ToString();
                FormDetected formDetected = new FormDetected(users.Id, loginDateCrash, loginTimeCrash);
                formDetected.ShowDialog();
            }

            Process processLoad = new Process();

            string queryLoad = "SELECT ID,UserID,loginDate,cast(loginTime as varchar(5)) as LoginTime,cast(logoutTime as varchar(5)) as LogoutTime,cast(timeSpent as varchar(5)) as TimeSpent,reason " +
                "FROM LogData " +
                "WHERE UserID = @id";
            dgvUser.DataSource = processLoad.SqlSelect(queryLoad, new string[] { "id" }, new object[] {users.Id });

            dgvUser.Columns["ID"].Visible = false;
            dgvUser.Columns["UserID"].Visible = false;


            Process processInsert = new Process();
            string queryInsert = "INSERT INTO LogData(UserID,loginDate,loginTime) "+
                "VALUES(@userID,@loginDate,@loginTime)";
            string[] paraInsert = { "userID", "loginDate", "loginTime" };
            object[] valuesInsert = { users.Id, date.ToString("yyyy-MM-dd"), time.ToString("T").Substring(0,8) };

            processInsert.SqlNonQuery(queryInsert, paraInsert, valuesInsert);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timeSpent = DateTime.Now - time;
            lbtime.Text = timeSpent.ToString().Substring(0, 8);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát?","Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DateTime logout = DateTime.Now;
                Process processUpdate = new Process();

                string queryUpdate = "UPDATE LogData " +
                    "SET logoutTime = @logoutTime,timeSpent = @timeSpent " +
                    "WHERE UserID = @UserID AND loginDate = @loginDate AND loginTime = @loginTime";
                string[] paraUpdate = { "logoutTime", "timeSpent", "UserID","loginDate","loginTime" };
                object[] valuesUpdate = { logout.ToString("T").Substring(0,8), timeSpent.ToString().Substring(0, 8), users.Id, date.ToString("yyyy-MM-dd"),time.ToString("T").Substring(0,8) };
                processUpdate.SqlNonQuery(queryUpdate, paraUpdate, valuesUpdate);
                               
                Application.Exit();
            }
        }
    }
}
