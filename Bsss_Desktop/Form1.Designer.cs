namespace Bsss_Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHeader = new Label();
            lblName = new Label();
            lblContact = new Label();
            lblService = new Label();
            lblDate = new Label();
            lblTime = new Label();
            txtName = new TextBox();
            txtContact = new TextBox();
            cmbService = new ComboBox();
            dtpDate = new DateTimePicker();
            dtpTime = new DateTimePicker();
            btnBook = new Button();
            btnSearch = new Button();
            btnUpdate = new Button();
            btnCancel = new Button();
            dgvBookings = new DataGridView();
            lblBookings = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBookings).BeginInit();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.BackColor = SystemColors.GradientActiveCaption;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = SystemColors.ControlText;
            lblHeader.Location = new Point(100, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(531, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "SERENE SPA AND SALON - BOOKING SYSTEM";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = SystemColors.ControlText;
            lblName.Location = new Point(30, 80);
            lblName.Name = "lblName";
            lblName.Size = new Size(58, 19);
            lblName.TabIndex = 1;
            lblName.Text = "NAME :";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContact.Location = new Point(30, 120);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(82, 19);
            lblContact.TabIndex = 3;
            lblContact.Text = "CONTACT :";
            lblContact.Click += lblContact_Click;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblService.Location = new Point(30, 160);
            lblService.Name = "lblService";
            lblService.Size = new Size(70, 19);
            lblService.TabIndex = 5;
            lblService.Text = "SERVICE :";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDate.Location = new Point(30, 200);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(51, 19);
            lblDate.TabIndex = 7;
            lblDate.Text = "DATE :";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTime.Location = new Point(30, 240);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(49, 19);
            lblTime.TabIndex = 9;
            lblTime.Text = "TIME :";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 80);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 2;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(130, 120);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(200, 23);
            txtContact.TabIndex = 4;
            // 
            // cmbService
            // 
            cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbService.Location = new Point(130, 160);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(200, 23);
            cmbService.TabIndex = 6;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(130, 200);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 23);
            dtpDate.TabIndex = 8;
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(130, 240);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(200, 23);
            dtpTime.TabIndex = 10;
            // 
            // btnBook
            // 
            btnBook.BackColor = SystemColors.ButtonShadow;
            btnBook.ForeColor = SystemColors.ControlText;
            btnBook.Location = new Point(30, 290);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(80, 30);
            btnBook.TabIndex = 11;
            btnBook.Text = "BOOK";
            btnBook.UseVisualStyleBackColor = false;
            btnBook.Click += btnBook_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonShadow;
            btnSearch.Location = new Point(120, 290);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 30);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.ButtonShadow;
            btnUpdate.Location = new Point(210, 290);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(80, 30);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ButtonShadow;
            btnCancel.Location = new Point(300, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // dgvBookings
            // 
            dgvBookings.AllowUserToAddRows = false;
            dgvBookings.BackgroundColor = SystemColors.ActiveBorder;
            dgvBookings.Location = new Point(400, 90);
            dgvBookings.MultiSelect = false;
            dgvBookings.Name = "dgvBookings";
            dgvBookings.ReadOnly = true;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.Size = new Size(350, 230);
            dgvBookings.TabIndex = 16;
            // 
            // lblBookings
            // 
            lblBookings.AutoSize = true;
            lblBookings.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBookings.Location = new Point(400, 68);
            lblBookings.Name = "lblBookings";
            lblBookings.Size = new Size(86, 19);
            lblBookings.TabIndex = 15;
            lblBookings.Text = "BOOKINGS:";
            // 
            // Form1
            // 
            ClientSize = new Size(800, 370);
            Controls.Add(lblHeader);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblContact);
            Controls.Add(txtContact);
            Controls.Add(lblService);
            Controls.Add(cmbService);
            Controls.Add(lblDate);
            Controls.Add(dtpDate);
            Controls.Add(lblTime);
            Controls.Add(dtpTime);
            Controls.Add(btnBook);
            Controls.Add(btnSearch);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(lblBookings);
            Controls.Add(dgvBookings);
            Name = "Form1";
            Text = "Serene Spa and Salon Booking System";
            ((System.ComponentModel.ISupportInitialize)dgvBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private Label lblName;
        private Label lblContact;
        private Label lblService;
        private Label lblDate;
        private Label lblTime;
        private Label lblBookings;

        private TextBox txtName;
        private TextBox txtContact;
        private ComboBox cmbService;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;

        private Button btnBook;
        private Button btnSearch;
        private Button btnUpdate;
        private Button btnCancel;

        private DataGridView dgvBookings;
    }
}
       
