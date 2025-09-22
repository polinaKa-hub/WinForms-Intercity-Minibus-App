using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AdminForm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public static int action = 0;
        public AdminForm()
        {
            InitializeComponent();
            label1.Visible = false;
            numUpDownId.Visible = false;
            
            tbCarBrend.Enabled = false;
            tbLicensePlate.Enabled = false;
            tbDriverPhone.Enabled = false;
            tbDriverName.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            numUpDownId.Visible = false;
            
            label8.Text = "Внесите значения";
            tbFrom.Enabled = true; tbFrom.Clear(); 
            tbTo.Enabled = true; tbTo.Clear();
            tbDate.Enabled = true; tbDate.Clear();
            tbTime.Enabled = true; tbTime.Clear();
            label15.Visible = true;
            label16.Visible = true;
            numUpDownSeats.Enabled = true; numUpDownSeats.Value = 0;
            numUpDownResSeats.Enabled = true; numUpDownResSeats.Value=0;
            action = 1;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            numUpDownId.Visible = true;
            
            label8.Text = "Введите id маршрута, который необходимо удалить";

            tbFrom.Enabled = false;
            tbTo.Enabled = false;
            tbDate.Enabled = false;
            tbTime.Enabled = false;
            numUpDownSeats.Enabled = false;
            numUpDownResSeats.Enabled = false;
            label15.Visible = false;
            label16.Visible = false;
            action = 2;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            numUpDownId.Visible = true;

            label8.Text = "Введите id маршрута, который необходимо отредактировать";
            tbFrom.Enabled = true;
            tbTo.Enabled = true;
            tbDate.Enabled = true;
            tbTime.Enabled = true;
            numUpDownSeats.Enabled = true;
            numUpDownResSeats.Enabled = true;
            label15.Visible = true;
            label16.Visible = true;
            action = 3;
        }

        private void numUpDownId_ValueChanged(object sender, EventArgs e)
        {
            connection.Open();
            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM marshrytka.route WHERE id = @id_route", connection);
            cmd1.Parameters.AddWithValue("@id_route", numUpDownId.Value);

            using (MySqlDataReader reader = cmd1.ExecuteReader())
            {
                while (reader.Read())
                {
                    tbFrom.Text = reader.GetString("from_where");
                    tbTo.Text = reader.GetString("to_where");
                    tbDate.Text = reader.GetString("date");
                    tbTime.Text = reader.GetString("time");
                    numUpDownSeats.Value = reader.GetInt32("number_seats");
                    numUpDownResSeats.Value = reader.GetInt32("num_reserved_seats");
                                      
                }
            }
            connection.Close();
            connection.Open();
            MySqlCommand cmd2 = new MySqlCommand("SELECT marshrytka.route.id_minibus, marshrytka.minibus. * FROM " +
                "marshrytka.route JOIN marshrytka.minibus ON marshrytka.route.id_minibus = minibus.id WHERE marshrytka.route.id =  @id_route;", connection);

            cmd2.Parameters.AddWithValue("@id_route", numUpDownId.Value);

            using (MySqlDataReader reader2 = cmd2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    numUpDownIdMinibus.Value = reader2.GetInt32("id_minibus");
                    tbCarBrend.Text = reader2.GetString("car_brend");
                    tbLicensePlate.Text = reader2.GetString("license_plate");
                    tbDriverName.Text = reader2.GetString("driver_name");
                    tbDriverPhone.Text = reader2.GetString("driver_phone_number");


                }
            }
            connection.Close();
            
        }

        private void numUpDownIdMinibus_ValueChanged(object sender, EventArgs e)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM marshrytka.minibus WHERE id = @id_minibus;", connection);

                cmd1.Parameters.AddWithValue("@id_minibus", numUpDownIdMinibus.Value);

                using (MySqlDataReader reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tbCarBrend.Text = reader.GetString("car_brend");
                        tbLicensePlate.Text = reader.GetString("license_plate");
                        tbDriverName.Text = reader.GetString("driver_name");
                        tbDriverPhone.Text = reader.GetString("driver_phone_number");
                    }
                }

                connection.Close();
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (action == 1)
            {
                connection.Open();
                if (checkFunction())
                {
                    string iqueryAdd = "INSERT INTO marshrytka.route(from_where,to_where,date,time,number_seats,num_reserved_seats, id_minibus) VALUES ( '" +
            tbFrom.Text + "', '" + tbTo.Text + "', '" + tbDate.Text + "', '" + tbTime.Text + "', '" + numUpDownSeats.Value + "', '" + numUpDownResSeats.Value +
            "', '" + numUpDownIdMinibus.Value + "'); SELECT LAST_INSERT_ID();";
                    MySqlCommand cmd1 = new MySqlCommand(iqueryAdd, connection);

                    try
                    {
                        int newRouteId = Convert.ToInt32(cmd1.ExecuteScalar());
                        MessageBox.Show("Маршрут добавлен! ID новой записи: " + newRouteId);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                    connection.Close();
                }
            }

            if(action == 2)
            {
                connection.Open();

                string iqueryDelete = "DELETE FROM marshrytka.route WHERE id= '" + numUpDownId.Value +  "';";
                MySqlCommand cmd2 = new MySqlCommand(iqueryDelete, connection);

                try
                {
                    MySqlDataReader myReader = cmd2.ExecuteReader();
                    MessageBox.Show("Маршрут удалён!");
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }

            if(action == 3)
            {
                connection.Open();

                string iqueryUpdate = "UPDATE marshrytka.route SET from_where = @From, to_where = @To, date=@Date, time=@Time, " +
                    "number_seats = @NumSeats, num_reserved_seats=  @NumResSeats , id_minibus= '" + numUpDownIdMinibus.Value + "'WHERE id='" + numUpDownId.Value +  "';";

                MySqlCommand cmd2 = new MySqlCommand(iqueryUpdate, connection);
                cmd2.Parameters.AddWithValue("@From", tbFrom.Text);
                cmd2.Parameters.AddWithValue("@To", tbTo.Text);
                cmd2.Parameters.AddWithValue("@Date", tbDate.Text);
                cmd2.Parameters.AddWithValue("@Time", tbTime.Text);
                cmd2.Parameters.AddWithValue("@NumSeats", numUpDownSeats.Value.ToString());
                cmd2.Parameters.AddWithValue("@NumResSeats", numUpDownResSeats.Value.ToString());
                try
                {
                    MySqlDataReader myReader = cmd2.ExecuteReader();
                    MessageBox.Show("Маршрут изменён!");
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }

                
                connection.Close();
            }
        }

        private bool checkFunction()
        {
            string datePattern = @"^\d{4}-\d{2}-\d{2}$"; // Паттерн для даты в формате "гггг-мм-дд"
            string timePattern = @"^([01]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$"; // Паттерн для времени в формате "чч:мм:сс"

            //проверка на пустые поля
            if (string.IsNullOrEmpty(tbFrom.Text) || string.IsNullOrEmpty(tbTo.Text) || string.IsNullOrEmpty(tbTime.Text) || string.IsNullOrEmpty(tbDate.Text) 
                || numUpDownSeats.Value == 0 || numUpDownResSeats.Value == null )
            {
                MessageBox.Show("Поля не должны быть пустыми!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //проверка полей Откуда и Куда
            else if ((tbFrom.Text != "Браслав" && tbFrom.Text != "Полоцк") || (tbTo.Text != "Браслав" && tbTo.Text != "Полоцк"))
            {
                MessageBox.Show("Поля 'Откуда' и 'Куда' должны иметь значения 'Полоцк' или 'Браслав'!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFrom.Focus(); tbTo.Focus();
                return false;
            }
            //проверка даты 
            if (!Regex.IsMatch(tbDate.Text, datePattern))
            {
                MessageBox.Show("Пожалуйста, введите дату в формате 'гггг-мм-дд'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDate.Focus();
                return false;
            }
           
            //проверка времени
            if (!Regex.IsMatch(tbTime.Text, timePattern))
            {
                MessageBox.Show("Пожалуйста, введите время в формате 'чч:мм:сс'.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTime.Focus();
                return false;
            }
           
            if (numUpDownSeats.Value < numUpDownResSeats.Value)
            {
                MessageBox.Show("Количество забронированных мест не может быть больше возможных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numUpDownResSeats.Focus();
                return false;
            }
            return true;

        }
    }
}
