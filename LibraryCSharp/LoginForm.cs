using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryCSharp
{
    public partial class LoginForm : Form
    {
        int counter = 0, time_counter = 0;
        public bool login = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void admin_login_Click(object sender, EventArgs e)
        {
            if (time_counter == 60 || time_counter == 0)
            {
                timer1.Enabled = false;
                time_counter = 0;
                if (user_username.Text == "admin" && user_passwd.Text == "admin123")
                {
                    MessageBox.Show("کاربر مدیر به برنامه خوش آمدید");
                    login = true;
                    this.Close();
                }
                else
                {
                    if (counter == 2)
                    {
                        timer1.Enabled = true;
                        MessageBox.Show("شما 3 بار رمز عبور و یا نام کاربری اشتباه وارد کردید، تا 1 دقیقه دیگر دوباره میتوانید تلاش کنید");
                    }
                    else
                    {
                        MessageBox.Show("خطا: نام کاربری یا رمز عبور اشتباه است!");
                        counter += 1;
                    }
                }
            }
        }

        private void user_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                user_passwd.Focus();
            }
        }

        private void user_passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                admin_login.Focus();
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time_counter >= 60)
            {
                timer1.Enabled = false;
                time_counter = 0;
                label3.Text = time_counter.ToString();
                counter = 0;
            }
            else
            {
                time_counter += 1;
                label3.Text = time_counter.ToString();
            }
        }
    }
}
