using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data; 
namespace OrderSystem_v1
{
    class Customer
    {
        public string ItemName { get; set; }
        public int ItemCost { get; set; }
        public int ItemCount { get; set; }
        public List<Customer> OrderItem = new List<Customer>();

        public int calculateTotalCost()
        {
            this.ItemCost = 0;
            for (int i = 0; i < OrderItem.Count; i++)
                this.ItemCost += OrderItem[i].ItemCost;
            return this.ItemCost;
        }
        public void Add_Information_Into_DataGridview(DataGridView datagridviewResult)
        {
            datagridviewResult.Rows.Add(this.ItemName, this.ItemCount, this.ItemCost);
        }


        public void AddOderIntoDb(MySqlConnection conn, MySqlCommand cmd, MySqlDataReader reader, DataGridView Menu)
        {
            Dictionary<string, int> menu = new Dictionary<string, int>(); // order count

            for (int i = 0; i < Menu.RowCount; i++)
                menu.Add(Menu.Rows[i].Cells[0].Value.ToString(), 0);

            for (int i = 0; i < OrderItem.Count; i++)
                menu[OrderItem[i].ItemName] += OrderItem[i].ItemCount;  //calculate customer total count;

             try
            {
                cmd = conn.CreateCommand();
                conn.Open();
       //         cmd.CommandText = "insert into Order_Info(Item_Count_1,Item_Count_2,Item_Count_3,TotalCost) values(10,20,30,10); ";

                cmd.CommandText = "insert into Order_Info(Item_Count_1,Item_Count_2,Item_Count_3,TotalCost) values(" + menu[Menu.Rows[0].Cells[0].Value.ToString()] + "," + menu[Menu.Rows[1].Cells[0].Value.ToString()] + "," + menu[Menu.Rows[2].Cells[0].Value.ToString()] +","+ calculateTotalCost()+ " ) ;"; 
                cmd.ExecuteNonQuery();              
                MessageBox.Show("訂單建立成功!"); 
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}