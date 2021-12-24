using Session1_2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Session1_2.controls
{
    class Process
    {
        DataProvider provider = new DataProvider();
        private SqlConnection con;

        public Process() {
            provider.Connect();
            con = provider.Con;
        }

        public bool Connect() {
            return provider.Connect();
        }

        public void Disconnect() {
            provider.Disconnect();
        }
        public SqlCommand commandFunc(string query,string[] paras,object[] values,bool isStore)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            if (Connect())
            {              
                if (isStore)
                {
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                if(paras!=null)
                {
                    for (int i = 0; i < paras.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(paras[i], values[i]);
                    }
                }
         
            }
            return cmd;
        }
        public SqlDataReader SqlDataReader(string query,string[] para,object[] values)
        {
            SqlDataReader reader = commandFunc(query, para, values, false).ExecuteReader();
            Disconnect();
            return reader;
        }

        public int SqlNonQuery(string query,string[] para,object[] values)
        {
            int rec = commandFunc(query, para, values, false).ExecuteNonQuery();
            Disconnect();
            return rec;
        }
        public int SqlSPNonQuery(string strStore,string[] para,object[] values)
        {
            int rec = commandFunc(strStore, para, values,true).ExecuteNonQuery();
            Disconnect();
            return rec;
        }
        public int SqlScalar(string query,string[] para,object[] values)
        {
            int rec =(int)commandFunc(query, para, values, false).ExecuteScalar();
            Disconnect();
            return rec;
        }
        public DataTable SqlSelect(string query,string[] para,object[] values)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(commandFunc(query, para, values, false));
            dap.Fill(dt);
            Disconnect();
            return dt;
        }
        public DataTable SqlSPSelect(string strStore, string[] para, object[] values)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(commandFunc(strStore, para, values, true));
            dap.Fill(dt);
            Disconnect();
            return dt;
        }
    }
}
