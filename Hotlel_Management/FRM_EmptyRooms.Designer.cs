namespace Hotel_Management
{
    partial class FRM_EmptyRooms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.data_EmptyRooms = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.data_EmptyRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // data_EmptyRooms
            // 
            this.data_EmptyRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_EmptyRooms.Location = new System.Drawing.Point(0, 0);
            this.data_EmptyRooms.MainView = this.gridView1;
            this.data_EmptyRooms.Name = "data_EmptyRooms";
            this.data_EmptyRooms.Size = new System.Drawing.Size(528, 417);
            this.data_EmptyRooms.TabIndex = 54;
            this.data_EmptyRooms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.data_EmptyRooms;
            this.gridView1.Name = "gridView1";
            // 
            // FRM_EmptyRooms
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 417);
            this.Controls.Add(this.data_EmptyRooms);
            this.Font = new System.Drawing.Font("Tahoma", 18F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "FRM_EmptyRooms";
            this.Activated += new System.EventHandler(this.FRM_EmptyRooms_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.data_EmptyRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl data_EmptyRooms;
    }
}