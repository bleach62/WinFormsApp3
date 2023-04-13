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

namespace WinFormsApp3
{
    public partial class RegistrationForm : Form
    {
        private readonly AppDbContext _context;
        private readonly AppDbContext Users;
        public RegistrationForm(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            User user1;
            
            using (var context = new AppDbContext())
            {
                var password = textBox6.Text;
                user1 = context.Users.FirstOrDefault(u => u.Password == password);
            }
            if (!(Regex.IsMatch(textBox1.Text, @"\P{IsCyrillic}")) && !(Regex.IsMatch(textBox2.Text, @"\P{IsCyrillic}")) && !(Regex.IsMatch(textBox3.Text, @"\P{IsCyrillic}")) && validateEmailRegex.IsMatch(textBox4.Text) && user1 == null )
            {
                var user = new User
                {
                    Name = textBox1.Text,
                    Surname = textBox2.Text,
                    Role = textBox3.Text,
                    Email = textBox4.Text,
                    NumberPhone = maskedTextBox1.Text,
                    Password = textBox6.Text
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Неверно введены данные");
            }
           
        }
    }
}
