using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hotel_Management.Page;


namespace Hotel_Management
{
    public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Main()
        {
            InitializeComponent();
        }
        Hotel hotel = new Hotel();
        private void LoadPage(DevExpress.XtraEditors.XtraUserControl Page)
        {
            try
            {
                pn_container.Controls.Clear();
                Page.Dock = DockStyle.Fill;
                pn_container.Controls.Add(Page);
            }
            catch { }

        }
   
      
        private void btn_room_Click(object sender, EventArgs e)
        {
            page_room room = new page_room();
            LoadPage(room);
        }

        private void btn_departing_Click(object sender, EventArgs e)
        {
            page_departing departing = new page_departing();
            LoadPage(departing);
        }

 

        private void btn_arrivals_Click(object sender, EventArgs e)
        {
            page_arrivals arrivals = new page_arrivals();
            LoadPage(arrivals);
        }

        private void btn_resident_Click_1(object sender, EventArgs e)
        {
          
            page_resident resident = new page_resident();
            resident.data_resident.DataSource = hotel.resident();
            LoadPage(resident);
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            page_customer customer = new page_customer();
            customer.data_customer.DataSource = hotel.get_customer();
            LoadPage(customer);

        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            page_registration registration = new page_registration();
            LoadPage(registration);

        }

        private void Main_Load(object sender, EventArgs e)
        {
         

        }
    }
}
