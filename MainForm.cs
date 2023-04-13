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
    public partial class MainForm : Form
    {
        private readonly AppDbContext _context;
        private readonly User _user;
        public MainForm(AppDbContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;
            _user.Orders = _context.Orders.Where(b => b.UserId == _user.Id).ToList();
            Text = $"Библиотека пользователя {_user.Name}";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _user.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bookForm = new BookForm(_context, _user);
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                _user.Orders.Add(bookForm.Book);
                _context.SaveChanges();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _user.Orders;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var book = (Orders)selectedRow.DataBoundItem;
            _user.Orders.Remove(book);
            _context.SaveChanges();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _user.Orders;
        }
    }
}