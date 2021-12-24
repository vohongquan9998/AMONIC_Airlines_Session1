using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
namespace Session1_2.models
{
    class DataProvider
    {
        SqlConnection con;
        string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString.ToString();

        public SqlConnection Con { get => con; set => con = value; }

        public bool Connect()
        {
            try {
                con = new SqlConnection(connectionString);
                con.Open();
                return true;
            } catch (Exception sqlex) { throw sqlex;}
        }
        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }
    }
}
