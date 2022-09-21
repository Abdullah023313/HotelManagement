using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Hotel_Management.Page;

namespace Hotel_Management
{
    public partial class FRM_EmptyRooms : DevExpress.XtraEditors.XtraForm
    {

        DateTime date1;
        DateTime date2;
        public FRM_EmptyRooms()
        {
            InitializeComponent();
        }
        public FRM_EmptyRooms(DateTime date1 , DateTime date2)
        {
            InitializeComponent();
            this.date1 = date1;
            this.date2 = date2;
        }



        private void FRM_EmptyRooms_Activated(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel();
            page_registration registration = new page_registration();
            data_EmptyRooms.DataSource = hotel.getEmptyRooms(date1, date2);
         
        }
    }
}