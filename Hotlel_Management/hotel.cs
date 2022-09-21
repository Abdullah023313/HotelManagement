using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Hotel_Management
{
    class Hotel
    {

        public void clear_textbox(DevExpress.XtraEditors.XtraUserControl TP)
        {

            foreach (Control a in TP.Controls)
            {
                
                    MessageBox.Show(a.Text + a.Name);
                    a.Visible= false;
                
            }
        }

        DataAccessLayer Dal = new DataAccessLayer();
        public DataTable get_room()
        {
            DataTable Dt = new DataTable();
            Dal.Connect();
            Dt = Dal.SelectData("get_room", null);
            Dal.Disconnect();
            return Dt;
        }
        public DataTable get_customer()
        {
            DataTable Dt = new DataTable();
            Dal.Connect();
            Dt = Dal.SelectData("get_customer", null);
            Dal.Disconnect();
            return Dt;
        }
     
        public void add_room( string type, string details, int floor, double price)
        {
            SqlParameter[] Param = new SqlParameter[4];
            try
            {
          
                Param[0] = new SqlParameter("@ro_type", SqlDbType.NVarChar);
                Param[0].Value = type;
                Param[1] = new SqlParameter("@details", SqlDbType.NVarChar);
                Param[1].Value = details;
                Param[2] = new SqlParameter("@floor", SqlDbType.Int);
                Param[2].Value = floor;
                Param[3] = new SqlParameter("@price", SqlDbType.Float);
                Param[3].Value = price;
                Dal.Connect();
                Dal.ExecuteCommand("add_room", Param);
                MessageBox.Show("completed successfully");
            }
            catch
            {
                Dal.Disconnect();
            }
        }
        public void Update_Room(int id, string type, string details, int floor, double price)
        {
            SqlParameter[] Param = new SqlParameter[5];
            try
            {
                Param[0] = new SqlParameter("@ro_id", SqlDbType.Int);
                Param[0].Value = id;
                Param[1] = new SqlParameter("@ro_type", SqlDbType.NVarChar);
                Param[1].Value = type;
                Param[2] = new SqlParameter("@details", SqlDbType.NVarChar);
                Param[2].Value = details;
                Param[3] = new SqlParameter("@floor", SqlDbType.Int);
                Param[3].Value = floor;
                Param[4] = new SqlParameter("@price", SqlDbType.Float);
                Param[4].Value = price;
                Dal.Connect();
                Dal.ExecuteCommand("updateRoom", Param);
              
            }
            catch
            {
                Dal.Disconnect();
            }
        }
        public void delete_room(int id)
        {

            SqlParameter[] Param = new SqlParameter[1];
            try
            {
                Param[0] = new SqlParameter("@ro_id", SqlDbType.Int);
                Param[0].Value = id;
                Dal.Connect();
                Dal.ExecuteCommand("delete_room", Param);
                MessageBox.Show("completed successfully");
            }
            catch
            {
                Dal.Disconnect();
            }
        }
        public Boolean reservation_for_customer(string proof, DateTime date_arrival, DateTime date_departure)
        {

            DataTable Dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[3];
            try
            {
                Param[0] = new SqlParameter("@proof", SqlDbType.NVarChar);
                Param[0].Value = proof;
                Param[1] = new SqlParameter("@date_arrival", SqlDbType.Date);
                Param[1].Value = date_arrival;
                Param[2] = new SqlParameter("@date_departure", SqlDbType.Date);
                Param[2].Value = date_departure;
                Dal.Connect();
                Dt = Dal.SelectData("reservation_for_customer", Param);
               
            }
            catch
            {
                Dal.Disconnect();
            }
            return (Dt.Rows.Count > 0) ? true : false;
        }


        public int Add_Cutomer(string name, string last, string proof, string phone)
        {

            try
            {
                SqlConnection SqlCon = new SqlConnection("Server=DESKTOP-LQFS6V0;Database=hotel;integrated security = true");
                SqlCommand SqlCmd = new SqlCommand("addCustomer", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                SqlCmd.Parameters.Add("@last ", SqlDbType.VarChar).Value = last;
                SqlCmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
                SqlCmd.Parameters.Add("@proof ", SqlDbType.VarChar).Value = proof;
                SqlParameter rol = new SqlParameter("@id", SqlDbType.Int);
                rol.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(rol);
                SqlCon.Open();
                SqlCmd.ExecuteNonQuery();
                SqlCon.Close();
                return Convert.ToInt32(SqlCmd.Parameters["@id"].Value);
            }
            catch
            {
                return -1;
            }
        }

        public DataTable getIdEmptyRooms(DateTime date_arrival, DateTime date_departure)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[2];
            try
            {
                Param[0] = new SqlParameter("@date_arrival", SqlDbType.Date);
                Param[0].Value = date_arrival;
                Param[1] = new SqlParameter("@date_departure", SqlDbType.Date);
                Param[1].Value = date_departure;
                Dal.Connect();
                Dt = Dal.SelectData("getIdEmptyRooms", Param);
            }
            catch
            {
                Dal.Disconnect();
            }
            return Dt;
        }
        public DataTable getEmptyRooms(DateTime date_arrival, DateTime date_departure)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[2];
            try
            {
                Param[0] = new SqlParameter("@date_arrival", SqlDbType.Date);
                Param[0].Value = date_arrival;
                Param[1] = new SqlParameter("@date_departure", SqlDbType.Date);
                Param[1].Value = date_departure;
                Dal.Connect();
                Dt = Dal.SelectData("getEmptyRooms", Param);
            }
            catch
            {
                Dal.Disconnect();
            }
            return Dt;
        }
        public DataTable searchRoom(DateTime date_arrival, DateTime date_departure, string text)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[3];
            try
            {
                Param[0] = new SqlParameter("@date_arrival", SqlDbType.Date);
                Param[0].Value = date_arrival;
                Param[1] = new SqlParameter("@date_departure", SqlDbType.Date);
                Param[1].Value = date_departure;
                Param[2] = new SqlParameter("@x", SqlDbType.NVarChar);
                Param[2].Value = text;
                Dal.Connect();
                Dt = Dal.SelectData("searchRoom", Param);
            }
            catch
            {
                Dal.Disconnect();
            }
            return Dt;
        }


        public string total_account_room(int d, int ro_id)
        {
            try
            {
                SqlConnection SqlCon = new SqlConnection("Server=DESKTOP-LQFS6V0;Database=hotel;integrated security = true");
                SqlCommand SqlCmd = new SqlCommand("total_account_room", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.Add("@d", SqlDbType.Int).Value = d;
                SqlCmd.Parameters.Add("@ro_id", SqlDbType.Int).Value = ro_id;
                SqlParameter x = new SqlParameter("@x", SqlDbType.Int);
                x.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(x);
                SqlCon.Open();
                SqlCmd.ExecuteNonQuery();
                SqlCon.Close();
                return Convert.ToInt32(SqlCmd.Parameters["@x"].Value).ToString(); ;
            }
            catch
            {
                return "";
            }
        }

        public void Add_Registration(int c_id, int ro_id, DateTime date_booking, DateTime date_arrival, DateTime date_departure, double total_account_room)
        {
            SqlParameter[] Param = new SqlParameter[6];
            try
            {
                Param[0] = new SqlParameter("@c_id", SqlDbType.Int);
                Param[0].Value = c_id;
                Param[1] = new SqlParameter("@ro_id", SqlDbType.Int);
                Param[1].Value = ro_id;
                Param[2] = new SqlParameter("@date_booking", SqlDbType.Date);
                Param[2].Value = date_booking;
                Param[3] = new SqlParameter("@date_arrival", SqlDbType.Date);
                Param[3].Value = date_arrival;
                Param[4] = new SqlParameter("@date_departure", SqlDbType.Date);
                Param[4].Value = @date_departure;
                Param[5] = new SqlParameter("@total_account_room", SqlDbType.Float);
                Param[5].Value = total_account_room;
                Dal.Connect();
                Dal.ExecuteCommand("addRegistration", Param);
                MessageBox.Show("completed successfully");
            }
            catch
            {
                Dal.Disconnect();
            }
        }
        public DataTable departing(DateTime date)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[1];
            try
            {
                Param[0] = new SqlParameter("@date", SqlDbType.Date);
                Param[0].Value = date;
                Dal.Connect();
                Dt = Dal.SelectData("departing", Param);
            }
            catch
            {
                Dal.Disconnect();
            }
            return Dt;
        }
        public DataTable arrivals(DateTime date)
        {
            DataTable Dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[1];
            try
            {
                Param[0] = new SqlParameter("@date", SqlDbType.Date);
                Param[0].Value = date;
                Dal.Connect();
                Dt = Dal.SelectData("arrivals ", Param);
            }
            catch
            {
                Dal.Disconnect();
            }
            return Dt;
        }
        public DataTable resident()
        {
            DataTable Dt = new DataTable();
            Dal.Connect();
            Dt = Dal.SelectData("resident", null);
            Dal.Disconnect();
            return Dt;
        }

    }
}