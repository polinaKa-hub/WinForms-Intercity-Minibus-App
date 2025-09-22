using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UsFormSelectTime : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        
        public static string timeRoute;
        public static int id_route;

        public UsFormSelectTime()
        {
            InitializeComponent();

            string fromValue = UserForm.from;
            string toValue = UserForm.to;
            string dateValue = UserForm.date;
            string numValue = UserForm.num;

            UserForm userForm = new UserForm();
            if (userForm.textBoxFromWhere.Text == "Полоцк")
            {
                label1.Text = "Пункт отправления: Автовокзал г.Полоцк";
                label2.Text = "Пункт прибытия: Автовокзал г.Браслав";
            }
            else { 
                label1.Text = "Пункт отправления: Автовокзал г.Браслав";
                label2.Text = "Пункт прибытия: Автовокзал г.Полоцк";
            }

            connection.Open();

            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM marshrytka.route WHERE from_where = @from AND to_where = @to AND date = @date AND num_reserved_seats <= @num", connection);
            cmd1.Parameters.AddWithValue("@from", fromValue);
            cmd1.Parameters.AddWithValue("@to", toValue);
            cmd1.Parameters.AddWithValue("@date", dateValue);
            cmd1.Parameters.AddWithValue("@num", numValue);

            using (MySqlDataReader reader = cmd1.ExecuteReader())
            {
                while (reader.Read())
                {
                    string result = $"{reader["from_where"].ToString()} - {reader["to_where"].ToString()}, {reader["time"].ToString()}"; 
                    listBox1.Items.Add(result);

                    
                }
            }
            if (listBox1.Items.Count == 0)
            {            
                listBox1.Items.Insert(0, "Упс, маршрутов по вашему запросу нет :(");
            }
                connection.Close();

        }

        private void buttonReserve_Click(object sender, EventArgs e)
        {

            string lastValue = listBox1.Items[listBox1.Items.Count - 1].ToString();
            string[] parts = lastValue.Split(',');
            string time;
            if (parts.Length > 1)
            {
                connection.Open();
                time = parts[1].Trim(); // Получаем последнюю часть строки после ","

                string query1 = "SELECT * FROM marshrytka.route WHERE time = @Time";
                MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                cmd1.Parameters.AddWithValue("@Time", time);
                
                try
                {
                    MySqlDataReader reader1 = cmd1.ExecuteReader();
                    id_route = reader1.GetInt32("id");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close() ;
             }

            connection.Open();

            
            string idPerson = Login.id_person.ToString();
            string query = "INSERT INTO marshrytka.person_route (id_person, id_route, num_seats) VALUES (@idPerson, @idRoute, @NumSeats)";
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            cmd2.Parameters.AddWithValue("@idPerson", idPerson);
            cmd2.Parameters.AddWithValue("@idRoute", id_route);
            cmd2.Parameters.AddWithValue("@NumSeats", UserForm.num);

            try
            {
                MySqlDataReader reader2 = cmd2.ExecuteReader();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            connection.Close();

            connection.Open();
            string numSeats = UserForm.num;
            string query2 = "UPDATE marshrytka.route SET num_reserved_seats = num_reserved_seats + @numRes WHERE id = @idRoute;";
            MySqlCommand cmd3 = new MySqlCommand(query2, connection);
            cmd3.Parameters.AddWithValue("@numRes", numSeats);
            cmd3.Parameters.AddWithValue("@idRoute", id_route);

            try
            {
                MySqlDataReader reader2 = cmd3.ExecuteReader();
                MessageBox.Show("Поездка забронирована!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

       
    }
}
