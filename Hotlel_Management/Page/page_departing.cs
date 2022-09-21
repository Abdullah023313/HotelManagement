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
    public partial class page_departing : DevExpress.XtraEditors.XtraUserControl
    {
        public page_departing()
        {
            InitializeComponent();
            dtpdeparting.Value = DateTime.Now.Date;
        }
        Hotel hotel = new Hotel();
        private void dtpdeparting_ValueChanged(object sender, EventArgs e)
        {
            data_departing.DataSource = hotel.departing(dtpdeparting.Value);
        }

      
    }
}
