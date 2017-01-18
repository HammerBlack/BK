using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data; 

namespace OrderSystem_v1
{
      



    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=127.0.0.1; Uid = root;Pwd = pop782513; Database = sell_info;");
        MySqlCommand cmd ;
        MySqlDataReader reader;
        Form2 form2;
        Notice notice; //警告視窗的物件
        public Form1()
        {
            InitializeComponent();
            notice = new Notice(); //初始物件

            form2 = new Form2();
            this.button1.Click += new EventHandler(this.button1_Click);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && !this.button1.Focused)
                button1_Click(null, null); 
            return base.ProcessDialogKey(keyData);
        }


        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode); //  leave systerm
            InitializeComponent();
        }

        string str;
        private void button1_Click(object sender, EventArgs e)
        {
            this.determineIdAndPassWord();
        }
        private void jumpToNextForm()
        {
            reader.Close();
            cmd.CommandText = "insert into userlogintime(userId) values( '"+ id.Text.ToString() + "' );";
            cmd.ExecuteNonQuery(); 
            conn.Close();
            this.Enabled = true;
            this.Hide();
            notice.Close();
            form2.ShowDialog(this);

        }


        private void foreColorChange(object sender, EventArgs e)
        {
               button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (showPassword.Checked == false)
                password.UseSystemPasswordChar = true;
            else
                password.UseSystemPasswordChar = false; 
        }

        private void textBoxClean()
        {
            id.Text = "";
            password.Text = "";
        }



        private void determineIdAndPassWord()
        { 
            if ((id.Text.ToString() == "") || (id.Text.ToString() == ""))
            { 
                showNoticForm("不可空白");
            }
            else
            {
                str = "select Id, Pass from user where Id = @Id and Pass= @Pass ;";
                
                try
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = str; 
                    cmd.Parameters.AddWithValue("@Id", id.Text.ToString());
                    cmd.Parameters.AddWithValue("@Pass", password.Text.ToString());

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((id.Text.ToString()==reader[0].ToString()) &&(password.Text.ToString() == reader[1].ToString()))
                            jumpToNextForm();
   
                    }
                    if(!reader.Read())
                    {
                        showNoticForm("帳號或密碼錯誤，請從新輸入");
                        textBoxClean();
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

        }

        private void showNoticForm(string word)
        {
            notice.ChangeTextBox(word,this);
        }
       
    }
}
