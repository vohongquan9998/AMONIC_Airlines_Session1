using Session1_2.controls;
using Session1_2.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Session1_2
{
    public partial class Form1 : Form
    {
        int count = 0;
        int time = 10;
        public Form1()
        {
            InitializeComponent();
        }
        Users user = new Users();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.TextLength == 0)
                MessageBox.Show("Vui long nhap email");
            else if (txtPass.TextLength == 0)
                MessageBox.Show("Vui long nhap pass");
            else
            {
                if (user.CheckUser(txtUser.Text, txtPass.Text))
                {
                    if (user.Roleid == 1)
                    {
                        this.Visible = false;
                        FormAdmin formAdmin = new FormAdmin(user);
                        formAdmin.ShowDialog();
                    }
                    else
                    {
                        if (user.Active)
                        {
                            this.Visible = false;
                            FormUser FormUser = new FormUser(user);
                            FormUser.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Tai khoan bị vô hiệu hoá,vui lòng liên hệ người quản trị viên");
                        }
                    
                    }
                }
                else
                {
                    MessageBox.Show("Sai tai khoan");
                    count++;
                    if(count == 3)
                    {
                        btnLogin.Enabled = false;
                        count = 0;
                        timer1.Start();
                        lbTime.Visible = true;
                    }    
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            lbTime.Text = time.ToString();
            if (time == 0)
            {
                time = 10;
                timer1.Stop();
                btnLogin.Enabled = true;
                lbTime.Visible = false;
            }
        }
    }
}
