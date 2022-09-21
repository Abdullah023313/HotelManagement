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
    public partial class page_arrivals : DevExpress.XtraEditors.XtraUserControl
    {
        public page_arrivals()
        {
            InitializeComponent();
            dtp_arrival_ValueChanged(this ,null);
            dtp_arrival.Value = DateTime.Now.Date;
            
        }
        Hotel hotel = new Hotel();
    
        private void dtp_arrival_ValueChanged(object sender, EventArgs e)
        {
            data_arrivals.DataSource = hotel.arrivals(dtp_arrival.Value);
        }
    }
}
