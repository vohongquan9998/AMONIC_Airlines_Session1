using Session1_2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Session1_2.controls
{
    class Users
    {
        private int id;
        private int roleid;
        private string email;
        private string pass;
        private string firstname;
        private string lastname;
        private int officeId;
        private bool active;
        private DateTime birth;

        DataProvider provider = new DataProvider();
        Process process = new Process();
        public Users() {
            provider.Connect();
        }

        public Users(int id, int roleid, string email, string pass, string firstname, string lastname, int officeId, DateTime birth, bool active)
        {
            this.id = id;
            this.roleid = roleid;
            this.email = email;
            this.pass = pass;
            this.firstname = firstname;
            this.lastname = lastname;
            this.officeId = officeId;
            this.birth = birth;
            this.active = active;
        }


        public int Id { get => id; set => id = value; }
        public int Roleid { get => roleid; set => roleid = value; }
        public string Email { get => email; set => email = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int OfficeId { get => officeId; set => officeId = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public bool Active { get => active; set => active = value; }


        public string createMD5(string input)
        {
            MD5 mD5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = mD5.ComputeHash(inputBytes);

            StringBuilder b = new StringBuilder();
            for(int i = 0;i<hash.Length;i++)
            {
                b.Append(hash[i].ToString("X2"));
            }
            return b.ToString();
        }

        public bool CheckUser(string email,string pass)
        {
            string MD5pass = createMD5(pass);
            string strStr = "SELECT * FROM Users WHERE Email = @email AND Password = @pass";
            string[] paras = { "email", "pass" };
            string[] values = { email, MD5pass };

            SqlDataReader dataReader = process.SqlDataReader(strStr, paras, values);

       
            if(dataReader.Read())
            {
                id = (int)dataReader["ID"];
                roleid = (int)dataReader["RoleID"];
                email = (string)dataReader["Email"];
                pass = (string)dataReader["Password"];
                firstname = (string)dataReader["FirstName"];
                lastname = (string)dataReader["LastName"];
                officeId = (int)dataReader["OfficeID"];
                active = (bool)dataReader["Active"];
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
