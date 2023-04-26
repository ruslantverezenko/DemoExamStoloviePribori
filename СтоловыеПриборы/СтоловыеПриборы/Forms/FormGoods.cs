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
    public partial class FormGoods : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=БДСтоловыеПриборы.mdb";
        OleDbConnection myConnection;
        OleDbCommand command;
        public FormGoods()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            comboBox1.Items.AddRange(new string[] { "Артикул", "Наименование", "Единица измерения", "Стоимость", "Размер максимально возможной скидки", "Производитель", "Поставщик", "Категория товара", "Действующая скидка", "Кол-во на складе", "Описание", "Изображение" });
        }

        private void FormGoods_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бДСтоловыеПриборыDataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.бДСтоловыеПриборыDataSet.Товары);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.товарыTableAdapter.Fill(this.бДСтоловыеПриборыDataSet.Товары);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string artikul = textBox1.Text;
            string naimenovanie = textBox2.Text;
            string edinitsaIzmereniya = textBox3.Text;
            int stoimost = Convert.ToInt32(textBox4.Text);
            int maxSkidka = Convert.ToInt32(textBox5.Text);
            string proizvoditel = textBox12.Text;
            string postavshik = textBox6.Text;
            string kategoriyaTovara = textBox7.Text;
            int deystvuyushayaSkidka = Convert.ToInt32(textBox8.Text);
            int kolvoNaSklade = Convert.ToInt32(textBox9.Text);
            string opisanie = textBox10.Text;
            string isobrajeniye = textBox11.Text;

            string query = $"INSERT INTO Товары VALUES('{artikul}', '{naimenovanie}', '{edinitsaIzmereniya}', {stoimost}, {maxSkidka}, '{proizvoditel}', '{postavshik}', '{kategoriyaTovara}', {deystvuyushayaSkidka}, {kolvoNaSklade}, '{opisanie}', '{isobrajeniye}')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Товар добавлен");
            this.товарыTableAdapter.Fill(this.бДСтоловыеПриборыDataSet.Товары);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string artikul = textBox13.Text;
            string query = $"DELETE FROM Товары WHERE Артикул='{artikul}'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о товаре удалены");
            this.товарыTableAdapter.Fill(this.бДСтоловыеПриборыDataSet.Товары);
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            string selectedPole = comboBox1.SelectedItem.ToString();
            string artikul = textBox24.Text;
            string novoeZnachenie = textBox14.Text;
            int novoeZnachenieInt;
            if(selectedPole == "Стоимость" || selectedPole == "Размер максимально возможной скидки" || selectedPole == "Действующая скидка" || selectedPole == "Кол-во на складе")
            {
                novoeZnachenieInt = Convert.ToInt32(novoeZnachenie);
                string query = $"UPDATE Товары SET [{selectedPole}] ={novoeZnachenieInt} WHERE [Артикул] = '{artikul}'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о товаре обновлены!");
            }
            else
            {
                string query = $"UPDATE Товары SET [{selectedPole}] ='{novoeZnachenie}' WHERE [Артикул] = '{artikul}'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Данные о товаре обновлены!");
            }
            this.товарыTableAdapter.Fill(this.бДСтоловыеПриборыDataSet.Товары);

        }
    }
}
