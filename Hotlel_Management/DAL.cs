using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Hotel_Management
{
    class DataAccessLayer
    {
        static SqlConnection SqlCon;
        public DataAccessLayer()
        {
            SqlCon = new
            SqlConnection("Server=.;Database=hotel;integrated security = true");
        }
        public void Connect()
        {
            if (SqlCon.State != ConnectionState.Open)
                SqlCon.Open();
        }
        public void Disconnect()
        {
            if (SqlCon.State != ConnectionState.Closed)
                SqlCon.Close();
        }
        public DataTable SelectData(String Stored, SqlParameter[] Param)
        {
            SqlCommand SqlCmd = new SqlCommand(Stored, SqlCon);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            if (Param != null)
            {
                for (int i = 0; i < Param.Length; i++)
                {
                    SqlCmd.Parameters.Add(Param[i]);
                }
            }
            SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
            DataTable Dt = new DataTable();
            SqlDa.Fill(Dt);
            return Dt;
        }

        public void ExecuteCommand(String Stored, SqlParameter[] Param)
        {
            SqlCommand SqlCmd = new SqlCommand(Stored, SqlCon);
            SqlCmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Param.Length; i++)
            {
                SqlCmd.Parameters.Add(Param[i]);
            }
            SqlCmd.ExecuteNonQuery();
        }
    }
}