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
    public partial class RegistrationForm : Form
    {
        private readonly AppDbContext _context;
        public RegistrationForm(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = textBox1.Text,
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Text
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрировались!",
           "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
