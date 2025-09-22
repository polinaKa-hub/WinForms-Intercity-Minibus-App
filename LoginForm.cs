using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource = localhost; port=3306; username=root; password=");
        MySqlCommand command;
        MySqlDataReader mdr;
        public static int id_person;
        public Login()
        {
            InitializeComponent();
           
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_PhoneNumber.Text) || string.IsNullOrEmpty(textBox_Password.Text)) {
                MessageBox.Show("Введите номер телефона и пароль!", "Ошибка"); 
            }
            else { 
                connection.Open();
                string selectQuery = "SELECT * FROM marshrytka.person WHERE phone_number = '" + textBox_PhoneNumber.Text + "' AND Password = '" + textBox_Password.Text + "' ; ";
                command = new MySqlCommand(selectQuery, connection);
                mdr = command.ExecuteReader();
                if (mdr.Read()) {

                     id_person= mdr.GetInt32("id"); //id пользователя, который зашел в приложение
                     int login_person = mdr.GetInt32("login");
                    if (login_person == 22) 
                    {
                        UserForm userForm = new UserForm();
                        userForm.ShowDialog();
                    }
                    else {
                        AdminForm adminForm = new AdminForm();
                        adminForm.ShowDialog();
                    }                 
                }
                else
                {
                    MessageBox.Show("Неверно введен номер или пароль!", "Ошибка");
                }
                connection.Close();
            }
        }

        private void button_registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm regForm = new RegistrationForm();
            regForm.ShowDialog();
        }
    }
}
