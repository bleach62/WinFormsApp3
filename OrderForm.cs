using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class OrderForm : Form
    {
        private readonly AppDbContext _context;
        private readonly User _user;
        
       
        public Order Order { get; private set; }
        public OrderForm(AppDbContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            var order = new Order
            {
                Date_t = today.ToString("yyyy-MM-dd"),
                UserId = _user.Id,
                Product = textBox3.Text,
                Countof = textBox4.Text
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            Order = order;
            DialogResult = DialogResult.OK;

        }
    }
}
