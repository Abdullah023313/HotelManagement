using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Hotel_Management.Page
{
    public partial class page_registration : DevExpress.XtraEditors.XtraUserControl
    {
        public page_registration()
        {
            InitializeComponent();
            date_arrival.Value = DateTime.Now.Date;
            date_depart.Value = DateTime.Now.Date;
            btn_add.Visible = true;
        }

        Hotel hotel = new Hotel();

        private void valueDateChanged(object sender, EventArgs e)
        {
            try
            {
                if (date_arrival.Value < date_depart.Value)
                {
                    cmb_id_room.DataSource = hotel.getIdEmptyRooms(date_arrival.Value, date_depart.Value);
                    cmb_id_room.DisplayMember = "ro_id";
                  
                }
                else
                {

                    btn_add.Visible = false;
                    cmb_id_room.Text = String.Empty;
                    txt_account.Text = "";
                }
            }
            catch
            {
            }
        }

        private void cmb_id_room_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (date_arrival.Value < date_depart.Value)
                {
                    int d = (date_depart.Value - date_arrival.Value).Days;
                    txt_account.Text = hotel.total_account_room(d, Convert.ToInt32(cmb_id_room.Text));
                    btn_add.Visible = true;
                }
                else
                {
                    btn_add.Visible = false;
                    cmb_id_room.Text = String.Empty;
                    txt_account.Text = "";
                }
            }
            catch { }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_name.Text.Trim() != "" && txt_last.Text.Trim() != "" && txt_proof.Text.Trim() != "" && txt_account.Text.Trim() != "")
                {
                    if (hotel.reservation_for_customer(txt_proof.Text.Trim(), date_arrival.Value, date_depart.Value) == false)
                    {

                        int c_id = hotel.Add_Cutomer(txt_name.Text.Trim(), txt_last.Text.Trim(), txt_proof.Text.Trim(), txt_phone.Text.Trim());
                        hotel.Add_Registration(c_id, Convert.ToInt32(cmb_id_room.Text), DateTime.Now.Date, date_arrival.Value,
                                                date_depart.Value, Convert.ToDouble(txt_account.Text.Trim()));
                        txt_name.Text = "";
                        txt_last.Text = "";
                        txt_phone.Text = "";
                        txt_proof.Text = "";
                        txt_account.Text = "";
                        date_arrival.Value = DateTime.Now.Date;
                        date_depart.Value = DateTime.Now.Date;

                    }
                    else
                    {
                        MessageBox.Show("يوجد حجز بالفعل");
                    }
                }

                else
                {
                    MessageBox.Show("البيانات غير كاملة");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (date_arrival.Value < date_depart.Value)
            {
                FRM_EmptyRooms from = new FRM_EmptyRooms(date_arrival.Value, date_depart.Value);
                from.ShowDialog();
            }
        }
    }
}
