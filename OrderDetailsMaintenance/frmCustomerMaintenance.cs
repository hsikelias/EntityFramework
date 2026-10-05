using OrderDetailsMaintenance.Models.DataLayer;






namespace OrderDetailsMaintenance{
    public partial class frmCustomerMaintenance : Form
    {
        private readonly NorthwindContext _context = new NorthwindContext();
        private Customer? _currentCustomer;


        // Lekish Sai Podili
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        // Lekish Sai Podili
        private void btnFind_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text.Trim();

            if (customerId == "")
            {
                MessageBox.Show("Please enter a customer ID.");
                return;
            }

            _currentCustomer = _context.Customers.Find(customerId);

            if (_currentCustomer == null)
            {
                MessageBox.Show(
                "Customer not found.",
                "Customer Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                txtContact.Clear();
                txtAddress.Clear();
                txtCity.Clear();
                txtCountry.Clear();

                return;
            }

            txtContact.Text = _currentCustomer.ContactName ?? "";
            txtAddress.Text = _currentCustomer.Address ?? "";
            txtCity.Text = _currentCustomer.City ?? "";
            txtCountry.Text = _currentCustomer.Country ?? "";
        }


        // Lekish Sai Podili
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentCustomer == null)
            {
                MessageBox.Show(
                    "Please find a customer before saving.",
                    "No Customer Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            _currentCustomer.ContactName = txtContact.Text.Trim();
            _currentCustomer.Address = txtAddress.Text.Trim();
            _currentCustomer.City = txtCity.Text.Trim();
            _currentCustomer.Country = txtCountry.Text.Trim();
            _context.Customers.Update(_currentCustomer);
            _context.SaveChanges();


            MessageBox.Show(
                "Customer information was updated successfully.",
                "Customer Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        // Lekish Sai Podili
        private void btnExit_Click(object sender, EventArgs e)
        {

            Close();
        }
    }
}