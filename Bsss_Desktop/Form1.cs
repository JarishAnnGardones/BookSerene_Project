using Microsoft.VisualBasic;
using System;
using System.Xml.Linq;
using BsssBLogic;
using BsssCommon;

namespace Bsss_Desktop
{
    public partial class Form1 : Form
    {
        private BsssBService bookingService = new BsssBService();
        public Form1()
        {

            InitializeComponent();
            cmbService.Items.AddRange(bookingService.Services);
            LoadBookings();

        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtContact.Text) || cmbService.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dateTime = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            bookingService.Book(txtName.Text, txtContact.Text, dateTime, cmbService.SelectedItem.ToString());
            LoadBookings();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter a name to search.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var results = bookingService.SearchBookingsByName(name);
            dgvBookings.DataSource = results;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedBooking = (Booking)dgvBookings.SelectedRows[0].DataBoundItem;
            var newDate = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            var newService = cmbService.SelectedItem?.ToString() ?? selectedBooking.Service;

            bookingService.UpdateBooking(selectedBooking, newService, newDate);
            LoadBookings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedBooking = (Booking)dgvBookings.SelectedRows[0].DataBoundItem;
            bookingService.Cancel(selectedBooking);
            LoadBookings();
        }

        private void LoadBookings()
        {
            dgvBookings.DataSource = null;
            dgvBookings.DataSource = bookingService.GetAllBookings();
        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }

    }
}
       
 