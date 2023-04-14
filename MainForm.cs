using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            int Id = _user.Id;
            _user = _context.Users.Include(u => u.Orders).FirstOrDefault(u => u.Id == Id);
            Text = $"Библиотека пользователя {_user.Name}";
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _user.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm(_context, _user);
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                _user.Orders.Add(orderForm.Order);
                _context.SaveChanges();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _user.Orders;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var order = (Order)selectedRow.DataBoundItem;
            _user.Orders.Remove(order);
            _context.SaveChanges();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _user.Orders;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var selectedrow = dataGridView1.SelectedRows[0];
            var order = (Order)selectedrow.DataBoundItem;
            int numeric;
            bool isNumber = int.TryParse(textBox1.Text, out numeric);
            Regex r = new Regex(@"\d{2}/\d{2}/\d{4}");
            if (radioButton1.Checked == true && textBox1.Text != "" && r.IsMatch(textBox1.Text))
            {
                order.Date_t =  textBox1.Text;
                _context.SaveChanges();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _user.Orders;
            }
            else if (radioButton2.Checked == true && textBox1.Text != "" && !(Regex.IsMatch(textBox1.Text, @"\P{IsCyrillic}")))
            {
                order.Product = textBox1.Text;
                _context.SaveChanges();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _user.Orders;
            }
            else if (radioButton3.Checked == true && textBox1.Text != "" && isNumber)
            {
                order.Countof = textBox1.Text;
                _context.SaveChanges();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _user.Orders;
            }

        }
    }
}