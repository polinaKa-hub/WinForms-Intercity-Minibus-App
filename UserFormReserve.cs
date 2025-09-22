using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class UserFormReserve : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        string idRoute;
        public UserFormReserve()
        {
            InitializeComponent();
            string idRoute = UsFormSelectTime.id_route.ToString();
           
            string idPerson = Login.id_person.ToString();
            connection.Open();
            string query = "SELECT marshrytka.person.* , marshrytka.route.*, marshrytka.minibus.*, marshrytka.person_route.num_seats , marshrytka.route.id AS r_id " +
                "FROM marshrytka.route " +
            "INNER JOIN marshrytka.minibus ON route.id_minibus = minibus.id " +
            "INNER JOIN marshrytka.person_route ON route.id = person_route.id_route " +
            "INNER JOIN marshrytka.person ON person.id = person_route.id_person " +
            "WHERE marshrytka.person.id = @idPerson;";
          
            MySqlCommand cmd1 = new MySqlCommand(query, connection);
            cmd1.Parameters.AddWithValue("@idPerson", idPerson);
            MySqlDataReader reader = cmd1.ExecuteReader();

            tabControlResSeats.TabPages.Clear();

            int tabPageIndex = 0;
            while (reader.Read())
            {
                tabPageIndex++;
                addPage(reader, tabPageIndex);
            }          
            reader.Close();
           
            connection.Close();
        }

        private void addPage(MySqlDataReader reader, int tabPageIndex)
        {
            TabPage tabPage = new TabPage("Бронь " + tabPageIndex); // Создаем новую вкладку
            
            int routeId = reader.GetInt32("r_id"); // Получаем значение столбца "id" как целое число

            TextBox tbFrom = new TextBox();
            tbFrom.Text = reader.GetString("from_where");
            tbFrom.Width = 60;


            TextBox tbTo = new TextBox();
            tbTo.Text = reader.GetString("to_where");
            tbTo.Width = 60;

            // Создание TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.ColumnCount = 2;
            

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            tableLayoutPanel.Size = new System.Drawing.Size(350,270);

            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            }

            tableLayoutPanel.Location = new Point(20, 0);

            tableLayoutPanel.Controls.Add(tbFrom, 0, 0);
            tableLayoutPanel.Controls.Add(tbTo, 1, 0);
                 
            string time = reader.GetString("time");
            
            TextBox tbDateTime = new TextBox();
            string date = reader.GetString("date");
            tbDateTime.Text =  time + " " + date;
            tbDateTime.Width = 125;

            TextBox tbLabel = new TextBox();
            tbLabel.Text = "Отправление:";

            tableLayoutPanel.Controls.Add(tbLabel, 0, 1);
            tableLayoutPanel.Controls.Add(tbDateTime, 1, 1);
          
            TextBox tbMinibus = new TextBox();
            string brend = reader.GetString("car_brend");
            string licensePlate = reader.GetString("license_plate");
            tbMinibus.Text = brend + "," + licensePlate;
           

            TextBox tbDriver = new TextBox();
            string nameDr = reader.GetString("driver_name");
            string phoneDr = reader.GetString("driver_phone_number");
            tbDriver.Text = nameDr + ", " + phoneDr;
            tbDriver.Width = 150;
            

            tableLayoutPanel.Controls.Add(tbMinibus, 0, 2);
            tableLayoutPanel.Controls.Add (tbDriver, 1, 2);

            TextBox tbtextNum = new TextBox();
            tbtextNum.Text = "Количество мест:";
            tbtextNum.Width = 120;
                       
            TextBox tbNumSeats = new TextBox();
            tbNumSeats.Name = "tbNumSeats";
            tbNumSeats.Text = reader.GetString("num_seats");
            tbNumSeats.Width = 20;
            
            tableLayoutPanel.Controls.Add(tbtextNum, 0, 3);
            tableLayoutPanel.Controls.Add(tbNumSeats, 1, 3);

            TextBox tbSum = new TextBox();
            tbSum.Text = "23 BYN";
            tbSum.Width = 80;

            tableLayoutPanel.Controls.Add(tbSum, 0, 4);

            TextBox tbid = new TextBox();
            tbid.Name = "tbid";
            tbid.Text = routeId.ToString();
            tbid.Visible = false;

            tableLayoutPanel.Controls.Add(tbid, 1, 4);
            

            tableLayoutPanel.Enabled = false;
            tabPage.Controls.Add(tableLayoutPanel);
            tabControlResSeats.TabPages.Add(tabPage); // Добавляем вкладку к tabControlResSeats

            
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            TabPage selectedTabPage = tabControlResSeats.SelectedTab;
            TextBox tbid = selectedTabPage.Controls.Find("tbid", true).FirstOrDefault() as TextBox;
            TextBox tbNumSeats = selectedTabPage.Controls.Find("tbNumSeats", true).FirstOrDefault() as TextBox;
            if (selectedTabPage != null)
            {
                if (tbid != null || tbNumSeats != null)
                {
                    string id_route = tbid.Text;
                    
                    string idPerson = Login.id_person.ToString();

                    connection.Open();
                    string query1 = "DELETE FROM marshrytka.person_route WHERE id_person= @IdPerson AND id_route=@IdRoute;";
                    MySqlCommand cmd1 = new MySqlCommand(query1, connection);
                    cmd1.Parameters.AddWithValue("@IdPerson", idPerson);
                    cmd1.Parameters.AddWithValue("@IdRoute", id_route);

                    try
                    {
                        MySqlDataReader reader1 = cmd1.ExecuteReader();
                        reader1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                    string numSeats = tbNumSeats.Text;
                    string query2 = "UPDATE marshrytka.route SET num_reserved_seats = num_reserved_seats - @numRes WHERE id = @idRoute;";
                    MySqlCommand cmd2 = new MySqlCommand(query2, connection);
                    cmd2.Parameters.AddWithValue("@numRes", numSeats);
                    cmd2.Parameters.AddWithValue("@idRoute", id_route);
                    
                    try
                    {
                        MySqlDataReader reader2 = cmd2.ExecuteReader();
                        MessageBox.Show("Бронь отменена!");
                        this.Close();
                        UserForm userForm = new UserForm();
                        userForm.ShowDialog();
                        reader2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                    connection.Close();
                }

            }
            else
            {
                MessageBox.Show("У вас нет забронированных маршрутов!");
            }
        }
    }
}
