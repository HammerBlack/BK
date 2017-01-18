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
    public partial class Form2 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=127.0.0.1; Uid = root;Pwd = pop782513; Database = sell_info;");
        MySqlCommand cmd;
        MySqlDataReader reader;
        Customer people = new Customer();
        EnsureForm ensureForm = new EnsureForm();
        Notice notice = new Notice(); 
        public Form2()
        {
            InitializeComponent();
            for (int i = 1; i <= 100; i++)
                comboBoxItemCount.Items.Add(i);
            try
            {
                conn.Open();
                cmd = new MySqlCommand("select itemName,itemUnit from goods ;",conn);
                reader = cmd.ExecuteReader();
                
                while(reader.Read())
                {
                    dataGridViewMenu.Rows.Add(reader[0].ToString(), reader[1].ToString()); 
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
             
        }

        private void label5_Click(object sender, EventArgs e)  //if click the labe1 X 
        {
            this.Close();
            Environment.Exit(Environment.ExitCode); //  leave systerm
            
        }
        int value1, value2;

        private void comboBoxItemCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            value1 = comboBoxItemCount.SelectedIndex + 1;
            textboxCost.Text = "" + value1 * value2;
            value2 = 0; 
        }

        private void dataGridViewMenu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            comboBoxItemCount.Enabled = true; 
            comboBoxItemCount.Text = "1";
            comboBoxItemCount.SelectedIndex = 0;
            textboxCost.Text = "0";
                   
            if((e.RowIndex < 0) || (dataGridViewMenu.Rows[e.RowIndex].Cells[0].Value == null))
            {
                textboxClean(); 
                return;
            }
            
           
            value1 = comboBoxItemCount.SelectedIndex + 1;
            value2 = int.Parse(dataGridViewMenu.Rows[dataGridViewMenu.CurrentRow.Index].Cells[1].Value.ToString());       
            textboxItem.Text = dataGridViewMenu.Rows[dataGridViewMenu.CurrentRow.Index].Cells[0].Value.ToString();
            textboxCost.Text = "" + value1 * value2;
            Conferm.Enabled = true;

        }

        private void Conferm_Click(object sender, EventArgs e)
        {
            people.OrderItem.Add(new Customer() { ItemName = textboxItem.Text.ToString(), ItemCount = comboBoxItemCount.SelectedIndex + 1, ItemCost = int.Parse(textboxCost.Text) });
            people.OrderItem[people.OrderItem.Count-1].Add_Information_Into_DataGridview(this.dataGridViewResult);
            textboxClean();
            textBoxTotalCost.Text = ""+people.calculateTotalCost();
            Conferm.Enabled = false;
            comboBoxItemCount.Enabled = false;
            EnsureOrder.Enabled = true; 
        }

        private void EnsureOrder_Click(object sender, EventArgs e)
        {
            people.AddOderIntoDb(conn, cmd,reader, dataGridViewMenu);
            cleanOldOrder();
            textBoxTotalCost.Text = ""; 
         }

        private void textboxClean()
        {
            textboxItem.Text = "";
            textboxCost.Text = "";
            comboBoxItemCount.Text = ""; 
        }

        private void dataGridViewResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (dataGridViewResult.Rows[e.RowIndex].Cells[0].Value == null))
                return;
            deleteRows();   
        }


        private void dataGridViewResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                deleteRows();
            }
        }


        private void deleteRows()
        {
            dataGridViewResult.AllowUserToDeleteRows = true;
            people.OrderItem.RemoveAt(dataGridViewResult.CurrentRow.Index);
            textBoxTotalCost.Text=""+ people.calculateTotalCost();
            dataGridViewResult.Rows.RemoveAt(dataGridViewResult.CurrentRow.Index);
            dataGridViewResult.Update();          
            MessageBox.Show("刪除成功!");
            dataGridViewResult.AllowUserToDeleteRows = false;
        }

        private void cleanOldOrder()
        {
            dataGridViewResult.Rows.Clear();
            people.ItemCount = 0;
            people.ItemName = "";
            people.ItemCost = 0;
            people.OrderItem.Clear();
        }
    }
}
