using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection sql;
        public Form1()
        {
            InitializeComponent();
        }

        string work1;
        string connectbd = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Администратор\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True
";

        private async void Button1_Click(object sender, EventArgs e)
        {
            string connectbd = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Администратор\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True
";
            SqlConnection sql = new SqlConnection(connectbd);

            await sql.OpenAsync();

            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From Polsovatel where login = '" + textBox2.Text + "'  and Password = '" + textBox3.Text + "'",sql);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                button1.Visible = false;
                button2.Visible = false;

                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox1.Visible = true;
                button3.Visible = true;
                
                string names = textBox2.Text;
                
                string sqlExpression1 = "SELECT Placement FROM Polsovatel WHERE login = @names";                
                using (SqlConnection connection = new SqlConnection(connectbd)){
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression1, connection);

                    command.Parameters.AddWithValue("@names", textBox2.Text);

                    SqlDataReader reader1 = command.ExecuteReader();

                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            string work = reader1.GetValue(0).ToString();

                            

                            textBox1.Text = work;
                        }
                    }               
                    reader1.Close();
                    connection.Close();
                }
                string sqlExpression = "SELECT FirstName FROM Polsovatel WHERE login = @names";
                using (SqlConnection connection1 = new SqlConnection(connectbd))
                {
                    connection1.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection1);

                    command.Parameters.AddWithValue("@names", textBox2.Text);

                    SqlDataReader reader = command.ExecuteReader();

                    // Проверка на наличие выходных данных
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string FirstName = reader.GetValue(0).ToString();

                            textBox5.Text = FirstName;
                        }
                    }
                    reader.Close();
                    connection1.Close();
                }

                string sqlExpression2 = "SELECT SecondName FROM Polsovatel WHERE login = @names";
                using (SqlConnection connection2 = new SqlConnection(connectbd))
                {
                    connection2.Open();
                    SqlCommand command = new SqlCommand(sqlExpression2, connection2);
                    command.Parameters.AddWithValue("@names",textBox2.Text);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string SecondName = reader.GetValue(0).ToString();
                            textBox4.Text = SecondName;
                        }
                    }
                    reader.Close();
                    connection2.Close();
                }

               

                if (textBox1.Text == "Директор  ")
                {
                    listBox1.Visible = true;
                    label1.Visible = true;
                    button12.Visible = true;
                    label20.Visible = true;
                    label21.Visible = true;
                    textBox16.Visible = true;
                    string SqlExpression3 = "SELECT * FROM Polsovatel Where Placement != @work1";
                    using (SqlConnection connection3 = new SqlConnection(connectbd))
                    {
                        connection3.Open();
                        SqlDataReader reader = null;
                        SqlCommand command = new SqlCommand(SqlExpression3, connection3);
                        command.Parameters.AddWithValue("@work1", textBox1.Text);
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox1.Items.Add(Convert.ToString("   " + reader["FirstName"]) + "        " + Convert.ToString(reader["SecondName"]));
                        }
                        reader.Close();
                        connection3.Close();
                    }
                    
                }
                else
                {
                    button3.Visible = false;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                    button6.Visible = true;
                }
               
            }

            else
            {
                MessageBox.Show("Неверные инициалы или пароль");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            button2.Visible = true;

            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox1.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            listBox1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label11.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            label12.Visible = false;
           
            label14.Visible = false;
            label15.Visible = false;

            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox16.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            button12.Visible = false;
           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            textBox1.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            listBox2.Visible = true;
            textBox6.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
           
            label14.Visible = true;
            label15.Visible = true;
            textBox7.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            



            textBox7.Text = "Склад №1";
            string number = textBox7.Text;
            string sqlExpression = "SELECT Town FROM Skladi WHERE number = @number";
            using (SqlConnection connection4 = new SqlConnection(connectbd))
            {
                connection4.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection4);
                command.Parameters.AddWithValue("@number", textBox7.Text);
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string town = reader.GetValue(0).ToString();
                    textBox6.Text = town;
                }
                reader.Close();
                connection4.Close();
            }

            string Expression = "SELECT * FROM sklad1";
            using (SqlConnection connection5 = new SqlConnection(connectbd))
            {
                connection5.Open();
                SqlCommand command = new SqlCommand(Expression, connection5);
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox2.Items.Add("        " +Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " шт");
                }
                reader.Close();
                connection5.Close();
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "Склад №1")
            {
                string Expression1 = "INSERT INTO [sklad1] (name_tovar, kolvo_tovar)VALUES(@name, @kolvo)";
                if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    using (SqlConnection connection1 = new SqlConnection(connectbd))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(Expression1, connection1);
                        command1.Parameters.AddWithValue("name", textBox8.Text);
                        command1.Parameters.AddWithValue("kolvo", textBox10.Text);
                        command1.ExecuteNonQuery();
                        connection1.Close();
                    }
                    listBox2.Items.Clear();
                    textBox8.Text = "";
                    textBox10.Text = "";
                    string Expression = "SELECT * FROM sklad1";
                    using (SqlConnection connection5 = new SqlConnection(connectbd))
                    {
                        connection5.Open();
                        SqlCommand command = new SqlCommand(Expression, connection5);
                        SqlDataReader reader = null;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " шт");
                        }
                        reader.Close();
                        connection5.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Поля 'Товар' и 'Кол-во' должны быть заполнены.");
                }
            }

            if (textBox7.Text == "Склад №2")
            {
                string Expression1 = "INSERT INTO [sklad2] (name_tovar, kolvo_tovar)VALUES(@name, @kolvo)";
                if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    using (SqlConnection connection1 = new SqlConnection(connectbd))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(Expression1, connection1);
                        command1.Parameters.AddWithValue("name", textBox8.Text);
                        command1.Parameters.AddWithValue("kolvo", textBox10.Text);
                        command1.ExecuteNonQuery();
                        connection1.Close();
                    }
                    listBox2.Items.Clear();
                    textBox8.Text = "";
                    textBox10.Text = "";
                    string Expression = "SELECT * FROM sklad2";
                    using (SqlConnection connection5 = new SqlConnection(connectbd))
                    {
                        connection5.Open();
                        SqlCommand command = new SqlCommand(Expression, connection5);
                        SqlDataReader reader = null;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " кг");
                        }
                        reader.Close();
                        connection5.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Поля 'Товар' и 'Кол-во' должны быть заполнены.");
                }
            }

            if (textBox7.Text == "Склад №3")
            {
                string Expression1 = "INSERT INTO [sklad3] (name_tovar, kolvo_tovar)VALUES(@name, @kolvo)";
                if (!string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
                {
                    using (SqlConnection connection1 = new SqlConnection(connectbd))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(Expression1, connection1);
                        command1.Parameters.AddWithValue("name", textBox8.Text);
                        command1.Parameters.AddWithValue("kolvo", textBox10.Text);
                        command1.ExecuteNonQuery();
                        connection1.Close();
                    }
                    listBox2.Items.Clear();
                    textBox8.Text = "";
                    textBox10.Text = "";
                    string Expression = "SELECT * FROM sklad3";
                    using (SqlConnection connection5 = new SqlConnection(connectbd))
                    {
                        connection5.Open();
                        SqlCommand command = new SqlCommand(Expression, connection5);
                        SqlDataReader reader = null;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " кг");
                        }
                        reader.Close();
                        connection5.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Поля 'Товар' и 'Кол-во' должны быть заполнены.");
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "Склад №1")
            {
                if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    string expression1 = "DELETE FROM [sklad1] WHERE [name_tovar] = @name";
                    using (SqlConnection connection1 = new SqlConnection(connectbd))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(expression1, connection1);
                        command1.Parameters.AddWithValue("name", textBox9.Text);
                        command1.ExecuteNonQuery();
                        connection1.Close();
                    }
                    listBox2.Items.Clear();
                    textBox9.Text = "";
                    string Expression = "SELECT * FROM sklad1";
                    using (SqlConnection connection5 = new SqlConnection(connectbd))
                    {
                        connection5.Open();
                        SqlCommand command = new SqlCommand(Expression, connection5);
                        SqlDataReader reader = null;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " шт");
                        }
                        reader.Close();
                        connection5.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Поле должно быть заполнено.");
                }
            }

            if (textBox7.Text == "Склад №2")
            {
                if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    string expression1 = "DELETE FROM [sklad2] WHERE [name_tovar] = @name";
                    using (SqlConnection connection1 = new SqlConnection(connectbd))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(expression1, connection1);
                        command1.Parameters.AddWithValue("name", textBox9.Text);
                        command1.ExecuteNonQuery();
                        connection1.Close();
                    }
                    listBox2.Items.Clear();
                    textBox9.Text = "";
                    string Expression = "SELECT * FROM sklad2";
                    using (SqlConnection connection5 = new SqlConnection(connectbd))
                    {
                        connection5.Open();
                        SqlCommand command = new SqlCommand(Expression, connection5);
                        SqlDataReader reader = null;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " кг");
                        }
                        reader.Close();
                        connection5.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Поле должно быть заполнено.");
                }
            }

            if (textBox7.Text == "Склад №3")
            {
                if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
                {
                    string expression1 = "DELETE FROM [sklad3] WHERE [name_tovar] = @name";
                    using (SqlConnection connection1 = new SqlConnection(connectbd))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(expression1, connection1);
                        command1.Parameters.AddWithValue("name", textBox9.Text);
                        command1.ExecuteNonQuery();
                        connection1.Close();
                    }
                    listBox2.Items.Clear();
                    textBox9.Text = "";
                    string Expression = "SELECT * FROM sklad3";
                    using (SqlConnection connection5 = new SqlConnection(connectbd))
                    {
                        connection5.Open();
                        SqlCommand command = new SqlCommand(Expression, connection5);
                        SqlDataReader reader = null;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " кг");
                        }
                        reader.Close();
                        connection5.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Поле должно быть заполнено.");
                }
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            textBox1.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;

            listBox2.Visible = false;
            textBox6.Visible = false;
            label11.Visible = false;
            label12.Visible = false;

            label14.Visible = false;
            label15.Visible = false;
            textBox7.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            listBox2.Items.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            textBox1.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            listBox2.Visible = true;
            textBox6.Visible = true;
            label11.Visible = true;
            label12.Visible = true;

            label14.Visible = true;
            label15.Visible = true;
            textBox7.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;




            textBox7.Text = "Склад №2";
            string number = textBox7.Text;
            string sqlExpression = "SELECT Town FROM Skladi WHERE number = @number";
            using (SqlConnection connection4 = new SqlConnection(connectbd))
            {
                connection4.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection4);
                command.Parameters.AddWithValue("@number", textBox7.Text);
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string town = reader.GetValue(0).ToString();
                    textBox6.Text = town;
                }
                reader.Close();
                connection4.Close();
            }

            string Expression = "SELECT * FROM sklad2";
            using (SqlConnection connection5 = new SqlConnection(connectbd))
            {
                connection5.Open();
                SqlCommand command = new SqlCommand(Expression, connection5);
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " кг");
                }
                reader.Close();
                connection5.Close();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            textBox1.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            listBox2.Visible = true;
            textBox6.Visible = true;
            label11.Visible = true;
            label12.Visible = true;

            label14.Visible = true;
            label15.Visible = true;
            textBox7.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;




            textBox7.Text = "Склад №3";
            string number = textBox7.Text;
            string sqlExpression = "SELECT Town FROM Skladi WHERE number = @number";
            using (SqlConnection connection4 = new SqlConnection(connectbd))
            {
                connection4.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection4);
                command.Parameters.AddWithValue("@number", textBox7.Text);
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string town = reader.GetValue(0).ToString();
                    textBox6.Text = town;
                }
                reader.Close();
                connection4.Close();
            }

            string Expression = "SELECT * FROM sklad3";
            using (SqlConnection connection5 = new SqlConnection(connectbd))
            {
                connection5.Open();
                SqlCommand command = new SqlCommand(Expression, connection5);
                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox2.Items.Add("        " + Convert.ToString(reader["name_tovar"]) + "       " + Convert.ToString(reader["kolvo_tovar"]) + " кг");
                }
                reader.Close();
                connection5.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;


            label13.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            label13.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            button10.Visible = false;
            button11.Visible = false;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) && 
                !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text))
            {
                string Expression = "INSERT INTO [Polsovatel] (SecondName, FirstName, login, Password, Placement)VALUES(@SecondName, @FirstName, @login, @Password, @Placement)";
                using (SqlConnection connection = new SqlConnection(connectbd))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(Expression, connection);
                    command.Parameters.AddWithValue("SecondName",textBox11.Text);
                    command.Parameters.AddWithValue("FirstName",textBox12.Text);
                    command.Parameters.AddWithValue("login",textBox13.Text);
                    command.Parameters.AddWithValue("Password",textBox14.Text);
                    command.Parameters.AddWithValue("Placement",textBox15.Text);

                    command.ExecuteNonQuery();
                    connection.Close();

                    label13.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    label19.Visible = false;
                    textBox11.Visible = false;
                    textBox12.Visible = false;
                    textBox13.Visible = false;
                    textBox14.Visible = false;
                    textBox15.Visible = false;
                    button10.Visible = false;
                    button11.Visible = false;

                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;

                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены.");
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text))
            {
                string expression = "DELETE FROM [Polsovatel] WHERE login =@login";
                using (SqlConnection connection = new SqlConnection(connectbd))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(expression,connection);
                    command.Parameters.AddWithValue("login",textBox16.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    textBox16.Text = "";

                    listBox1.Items.Clear();
                    string Expression = "SELECT * FROM Polsovatel WHERE Placement !=@work1";
                    using (SqlConnection connection5 = new SqlConnection(connectbd))
                    {
                        connection5.Open();
                        SqlCommand command1 = new SqlCommand(Expression, connection5);
                        command1.Parameters.AddWithValue("@work1", textBox1.Text);
                        SqlDataReader reader = null;
                        reader = command1.ExecuteReader();
                        while (reader.Read())
                        {
                            listBox1.Items.Add("    " + Convert.ToString(reader["FirstName"]) + "       " + Convert.ToString(reader["SecondName"]));
                        }
                        reader.Close();
                        connection5.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Поле должно быть заполнено.");
            }
        }
    }
}
