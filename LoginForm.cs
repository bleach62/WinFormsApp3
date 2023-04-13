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
    public partial class LoginForm : Form
    {
        private AppDbContext context;
        public LoginForm()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            
                User user;
                using (var context = new AppDbContext())
                {
                    var email = textBox1.Text;
                    var password = textBox2.Text;
                    user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                }
                if (user != null)
                {
                    MessageBox.Show("Вы успешно авторизовались!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm mainForm = new MainForm(new AppDbContext(), user);
                    Hide();
                    mainForm.ShowDialog();
                    DialogResult dialogResult =
                   MessageBox.Show("Закрыть программу?", "Думай", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        Close();
                    else if (dialogResult == DialogResult.No)
                        Show();
                }
                else
                {
                    MessageBox.Show("Неправильный email или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm(new AppDbContext());
            Hide();
            registrationForm.ShowDialog();
            Show();
        }
    }

}
