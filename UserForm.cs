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
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class UserForm : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataReader mdr;

        public static string from, to, date, num;

        private void btnReservedSeats_Click(object sender, EventArgs e)
        {
            this.Close();
            UserFormReserve userFormReserve = new UserFormReserve();
            userFormReserve.ShowDialog();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Login.id_person = 0;
            this.Close();
            Login login = new Login();
            login.ShowDialog();
            
        }

        public UserForm()
        {
            InitializeComponent();
            textBoxFromWhere.ReadOnly = true;
            textBoxFromWhere.Text = "Полоцк";
            textBoxToWhere.Text = "Браслав";
            textBoxToWhere.ReadOnly = true;

            string idPerson = Login.id_person.ToString();
            connection.Open();
            string selectQuery = "SELECT * FROM marshrytka.person WHERE id = @idPerson; ";
            command = new MySqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@idPerson", idPerson);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                string firstname = mdr.GetString("username");
                string lastname = mdr.GetString("lastname");
                label4.Text = firstname + " " + lastname;
            }
            else
            {
                MessageBox.Show("Error");
            }
            connection.Close();
        }
        private void tydasuda_Click(object sender, EventArgs e)
        {
            // Сохраняем текущие значения текстовых полей
            string temp = textBoxFromWhere.Text;
            // Меняем значения местами
            textBoxFromWhere.Text = textBoxToWhere.Text;
            textBoxToWhere.Text = temp;
        }
        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(numUpDown.Text) || string.IsNullOrEmpty(dtPicker.Text))
            {
                MessageBox.Show("Пожалуйста, заполните всю информацию!", "Ошибка");
                return;
            }

            else
            {
                connection.Open();
                string dateFormatted = dtPicker.Value.ToString("yyyy-MM-dd"); 
                string selectQuery = "SELECT * FROM marshrytka.route WHERE from_where = '" + textBoxFromWhere.Text +
                    "' AND to_where = '" + textBoxToWhere.Text + "' AND date = '" + dateFormatted + 
                    "' AND num_reserved_seats <= '" + numUpDown.Value + "' ; "; 
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read())
                {
                    from = textBoxFromWhere.Text;
                    to = textBoxToWhere.Text;
                    date = dateFormatted;
                    num = numUpDown.Value.ToString();

                    UsFormSelectTime usFormSelectTime = new UsFormSelectTime();
                    usFormSelectTime.ShowDialog();
                }
                else
                {             
                    MessageBox.Show("Error");
                }
                connection.Close();
            }
        }
    }
}
