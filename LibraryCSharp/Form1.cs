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
    public partial class Form1 : Form
    {
        string[,] user_information = new string[100, 7];
        int memberCounter = 0;
        string[,] book_information = new string[100, 8];
        int bookCounter = 0;
        bool FoundCounter = false;
        int book_id = 0;
        bool isAdmin = false, Exist = false, ExistEdit = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            user_information[memberCounter, 0] = user_id.Text;
            user_information[memberCounter, 1] = user_name.Text;
            user_information[memberCounter, 2] = user_fullname.Text;
            user_information[memberCounter, 3] = national_code.Text;
            user_information[memberCounter, 4] = phone_number.Text;
            user_information[memberCounter, 5] = user_address.Text;
            user_information[memberCounter, 6] = pictureBox1.ImageLocation;
            memberCounter += 1;
            MessageBox.Show("کاربر اضافه شد");
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            user_id.Text = "";
            user_name.Text = "";
            national_code.Text = "";
            phone_number.Text = "";
            user_address.Text = "";
            user_fullname.Text = "";
            pictureBox1.ImageLocation = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTimer.Text = DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            usersPage.Enabled = false;
            usersPage.Visible = false;
            booksPage.Enabled = false;
            bookInformaiton.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isAdmin == true)
            {
                button1.Text = "ورود مدیر";
                label2.Text = "مهمان";
                isAdmin = false;
                usersPage.Enabled = false;
                booksPage.Enabled = false;
                button7.Visible = false;
                button7.Enabled = false;
                textBox18.Text = "";
                textBox17.Text = "";
                textBox16.Text = "";
                textBox15.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                pictureBox3.ImageLocation = "";
                button9.Visible = false;
                button8.Visible = false;
                button9.Enabled = false;
                button8.Enabled = false;

                MessageBox.Show("از حساب مدیر خارج شدید");
            }
            else
            {
                LoginForm frm = new LoginForm();
                frm.ShowDialog();
                if (frm.login)
                {
                    usersPage.Enabled = true;
                    booksPage.Enabled = true;
                    label2.Text = "مدیر";
                    button1.Text = "خروج از حساب";
                    isAdmin = true;
                }
            }
        }

        private void upload_image_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Image File |*.jpg;*.bmp";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog2.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bookCounter; i++)
            {
                if (book_information[i, 0].ToString() == textBox9.Text || book_information[i, 5].ToString() == textBox10.Text || book_information[i, 6].ToString() == textBox11.Text || book_information[i, 7].ToString() == pictureBox2.ImageLocation)
                {
                    MessageBox.Show("اطلاعات از قبل وجود دارد، اطلاعات جدید وارد کنید");
                    Exist = true;
                    break;
                }
                else
                {
                    Exist = false;
                }
            }
            if (Exist == false)
            {
                book_information[bookCounter, 0] = textBox9.Text;
                book_information[bookCounter, 1] = textBox8.Text;
                book_information[bookCounter, 2] = textBox7.Text;
                book_information[bookCounter, 3] = textBox6.Text;
                book_information[bookCounter, 4] = textBox5.Text;
                book_information[bookCounter, 5] = textBox10.Text;
                book_information[bookCounter, 6] = textBox11.Text;
                book_information[bookCounter, 7] = pictureBox2.ImageLocation;
                bookCounter += 1;
                MessageBox.Show("کتاب اضافه شد");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image File |*.jpg;*.bmp";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            pictureBox2.ImageLocation = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false && textBox2.Enabled == false && textBox3.Enabled == false && textBox4.Enabled == false)
            {
                MessageBox.Show("از قسمت 'جستجو بر اساس' یک گزینه را انتخاب کنید");
            }
            else
            {
                for (int i = 0; i < bookCounter; i++)
                {
                    if (textBox1.Enabled == true && book_information[i, 0].ToString() == textBox1.Text)
                    {
                        FoundCounter = true;
                        book_id = i;
                        break;
                    }
                    else if (textBox2.Enabled == true && book_information[i, 1].ToString() == textBox2.Text)
                    {
                        FoundCounter = true;
                        book_id = i;
                        break;
                    }
                    else if (textBox3.Enabled == true && book_information[i, 5].ToString() == textBox3.Text)
                    {
                        FoundCounter = true;
                        book_id = i;
                        break;
                    }
                    else if (textBox4.Enabled == true && book_information[i, 4].ToString() == textBox4.Text)
                    {
                        FoundCounter = true;
                        book_id = i;
                        break;
                    }
                }
                if (FoundCounter == false)
                {
                    MessageBox.Show("کتاب پیدا نشد");
                    bookInformaiton.Enabled = false;
                }
                else
                {
                    textBox18.Text = book_information[book_id, 0];
                    textBox17.Text = book_information[book_id, 1];
                    textBox16.Text = book_information[book_id, 2];
                    textBox15.Text = book_information[book_id, 3];
                    textBox14.Text = book_information[book_id, 4];
                    textBox13.Text = book_information[book_id, 5];
                    textBox12.Text = book_information[book_id, 6];
                    pictureBox3.ImageLocation = book_information[book_id, 7];
                    bookInformaiton.Enabled = true;
                    if (isAdmin == true)
                    {
                        button7.Enabled = true;
                        button7.Visible = true;
                    }
                    MessageBox.Show("کتاب پیدا شد، اطلاعات را داخل تب اطلاعات کتاب ببینید");
                }
                FoundCounter = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void user_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                user_fullname.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void user_fullname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                national_code.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void national_code_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(char.IsDigit((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                phone_number.Focus();
            }
        }

        private void phone_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(char.IsDigit((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                user_address.Focus();
            }
        }

        private void user_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                upload_image.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(char.IsDigit((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(char.IsDigit((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                button6.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(char.IsDigit((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                button2.Focus();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button9.Visible = true;
            button8.Visible = true;
            button9.Enabled = true;
            button8.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
            textBox14.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            textBox17.Enabled = true;
            textBox18.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Image File |*.jpg;*.bmp";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.ImageLocation = openFileDialog2.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox3.ImageLocation == "" || textBox18.Text == "" || textBox17.Text == "" || textBox16.Text == "" || textBox15.Text == "" || textBox14.Text == "" || textBox13.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("اطلاعات را کامل کنید");
            }
            else
            {
                for (int i = 0; i < bookCounter; i++)
                {
                    if (book_information[i, 0].ToString() == textBox18.Text || book_information[i, 5].ToString() == textBox14.Text || book_information[i, 6].ToString() == textBox12.Text || book_information[i, 7].ToString() == pictureBox3.ImageLocation)
                    {
                        MessageBox.Show("اطلاعات از قبل وجود دارد، اطلاعات جدید وارد کنید");
                        ExistEdit = true;
                        break;
                    }
                    else
                    {
                        ExistEdit = false;
                    }
                }
                if (ExistEdit == false)
                {
                    book_information[book_id, 0] = textBox18.Text;
                    book_information[book_id, 1] = textBox17.Text;
                    book_information[book_id, 2] = textBox16.Text;
                    book_information[book_id, 3] = textBox15.Text;
                    book_information[book_id, 4] = textBox14.Text;
                    book_information[book_id, 5] = textBox13.Text;
                    book_information[book_id, 6] = textBox12.Text;
                    book_information[book_id, 7] = pictureBox3.ImageLocation;
                    MessageBox.Show("کتاب ویرایش شد");
                    button8.Enabled = false;
                    button9.Enabled = false;
                    button8.Visible = false;
                    button9.Visible = false;
                }
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox17.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox16.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox15.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox14.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
            }
            if (!(char.IsDigit((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button7.Focus();
            }
            if (!(char.IsDigit((char)e.KeyCode) || (e.KeyCode == Keys.Back)))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox12.Focus();
            }
            if (!(char.IsLetter((char)e.KeyCode) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Space)))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
