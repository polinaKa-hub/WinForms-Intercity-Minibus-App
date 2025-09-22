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
using System.Xml.Linq;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp2
{
    public partial class RegistrationForm : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {

            if (checFunction())
            {
                connection.Open();

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM marshrytka.person WHERE phone_number = @PhoneNumber", connection);
                cmd1.Parameters.AddWithValue("@PhoneNumber", textBoxNumberPhone.Text);

                bool phoneExists = false;
                using (var dr2 = cmd1.ExecuteReader())
                    if (phoneExists = dr2.HasRows) MessageBox.Show("Пользователь уже существует!");

                if (!(phoneExists))
                {

                    string iquery = "INSERT INTO marshrytka.person(`username`,`lastname`,`phone_number`,`password`,`login`) VALUES ( '" +
                        textBoxName.Text + "', '" + textBoxLastName.Text + "', '" + textBoxNumberPhone.Text + "', '" + textBoxPassword.Text + "', '" + 22 + "')";
                    MySqlCommand commandDatabase = new MySqlCommand(iquery, connection);
                    commandDatabase.CommandTimeout = 60;

                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Аккаунт создан успешно!");

                }

                connection.Close();

                this.Close();

            }

        }

        private bool checFunction()
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxLastName.Text) || string.IsNullOrEmpty(textBoxPassword.Text) || string.IsNullOrEmpty(textBoxNumberPhone.Text))
            {
                MessageBox.Show("Пожалуйста, заполните всю информацию!", "Ошибка");
                return false;
            }

            if (!Regex.IsMatch(textBoxName.Text, @"^[А-Яа-яЁё]+$") || !Regex.IsMatch(textBoxLastName.Text, @"^[А-Яа-яЁё]+$"))
            {
                MessageBox.Show("Ошибка: Поля имени и фамилии должны содержать только русские буквы", "Ошибка");
                return false;
            }

            if (!Regex.IsMatch(textBoxNumberPhone.Text, @"^\d{7}$"))
            {
                MessageBox.Show("Ошибка: Поле номера телефона должно содержать 7 цифр.", "Ошибка");
                return false;
            }

            if (textBoxPassword.Text.Contains(" "))
            {
                MessageBox.Show("Ошибка: Поле пароля не должно содержать пробелы.", "Ошибка");
                return false;
            }

            return true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            this.Close();

        }
    }

}
