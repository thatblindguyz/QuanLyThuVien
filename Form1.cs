using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestLogin1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
           SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestLogin;Integrated Security=True;");
            try
            {
                conn.Open();
                string tk = textBoxUsername.Text;
                string mk = textBoxPassword.Text;
                string sql = "select * from test where username = '" + tk + "'and password = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (textBoxUsername.Text == "" || textBoxPassword.Text == "")
                {
                    MessageBox.Show("Bạn cần điền tài khoản và mật khẩu để đăng nhập", "Thông báo", MessageBoxButtons.OK);
                }
                else if (dataReader.Read() == true)
                {
                    this.Hide();
                    FormMain f_main = new FormMain();
                    f_main.ShowDialog();
                    textBoxPassword.Text = "";

                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu","Thông báo",MessageBoxButtons.OK);
                    textBoxPassword.Text = "";
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi kết nối" +ex, "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.PasswordChar == '*')
            {
                textBoxPassword.PasswordChar = '\0';

            }
            else
            {
                textBoxPassword.PasswordChar = '*';
            }
             
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

