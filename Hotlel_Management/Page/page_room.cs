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
    public partial class page_room : DevExpress.XtraEditors.XtraUserControl
    {
        public page_room()
        {
            InitializeComponent();
            data_room.DataSource = hotel.get_room();

        }
        private void data_room_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow sel = data_room.Rows[index];
                txt_id.Text = sel.Cells[0].Value.ToString();
                txt_type.Text = sel.Cells[1].Value.ToString();
                txt_price.Text = sel.Cells[2].Value.ToString();
                txt_details.Text = sel.Cells[3].Value.ToString();
                txt_floor.Text = sel.Cells[4].Value.ToString();
            }
            catch
            {

            }
        }
        Hotel hotel = new Hotel();
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_type.Text != "" && txt_floor.Text != "" && txt_price.Text != "")
                {
                    hotel.add_room(txt_type.Text, txt_details.Text,
                                        Convert.ToInt32(txt_floor.Text), Convert.ToDouble(txt_price.Text));
                    data_room.DataSource = hotel.get_room();
                }
                else
                {
                    MessageBox.Show("");
                    txt_type.Focus();
                }
            }
            catch
            {
               
            }
        }

        private void btn_delet_Click(object sender, EventArgs e)
        {
            try
            {
                hotel.delete_room(Convert.ToInt32(txt_id.Text));
                data_room.DataSource = hotel.get_room();
            }
            catch
            {
                if (txt_id.Text=="")
                {
                MessageBox.Show("قم بتحديد العنصر المراد حذفه");
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_type.Text != "" && txt_floor.Text != "" && txt_price.Text != "" && txt_id.Text != "")
                {
                    hotel.Update_Room(Convert.ToInt32(txt_id.Text), txt_type.Text, txt_details.Text,
                                 Convert.ToInt32(txt_floor.Text), Convert.ToDouble(txt_price.Text));
                    data_room.DataSource = hotel.get_room();
                    MessageBox.Show("completed successfully");
                }
            }
            catch
            {
                if (txt_id.Text == "")
                {
                    MessageBox.Show("قم بتحديد العنصر المراد التعديل عليه");
                }
            }
        }
    }
}
