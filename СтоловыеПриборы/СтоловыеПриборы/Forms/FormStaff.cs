using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace СтоловыеПриборы.Forms
{
    public partial class FormStaff : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=БДСтоловыеПриборы.mdb";
        OleDbConnection myConnection;
        OleDbCommand command;
        public FormStaff()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comboBox1.Items.AddRange(new string[] { "Код сотрудника", "Роль сотрудника", "ФИО", "Логин", "Пароль" });
            comboBox2.Items.AddRange(new string[] { "Код сотрудника", "Роль сотрудника", "ФИО", "Логин", "Пароль" });
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бДСтоловыеПриборыDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.бДСтоловыеПриборыDataSet.Сотрудники);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedPole = comboBox2.SelectedItem.ToString();
            string tekusheeZnachenie = textBox7.Text;
            string novoeZnachenie = textBox8.Text;
            int tekusheeZnachenieInt;
            int novoeZnachenieInt;
            if (selectedPole == "Код сотрудника")
            {
                tekusheeZnachenieInt = Convert.ToInt32(tekusheeZnachenie);
                novoeZnachenieInt = Convert.ToInt32(novoeZnachenie);
                string query = $"UPDATE Сотрудники SET [{selectedPole}] = {novoeZnachenieInt} WHERE [{selectedPole}] = {tekusheeZnachenieInt}";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о сотруднике обновлены!");
            }
            else
            {
                string query = $"UPDATE Сотрудники SET [{selectedPole}] ='{novoeZnachenie}' WHERE [{selectedPole}] = '{tekusheeZnachenie}'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о сотруднике обновлены!");
            }
            this.сотрудникиTableAdapter.Fill(this.бДСтоловыеПриборыDataSet.Сотрудники);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kodSotrudnika = Convert.ToInt32(textBox1.Text);
            string roleSotrudnika = textBox2.Text;
            string fio = textBox3.Text;
            string login = textBox4.Text;
            string password = textBox5.Text;
            string query = $"INSERT INTO Сотрудники VALUES({kodSotrudnika}, '{roleSotrudnika}', '{fio}', '{login}', '{password}')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Сотрудник добавлен");
        }
    }
}
