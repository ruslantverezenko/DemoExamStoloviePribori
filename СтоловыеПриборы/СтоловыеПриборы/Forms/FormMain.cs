﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using СтоловыеПриборы.Forms;

namespace СтоловыеПриборы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormGoods fgoods = new FormGoods();
            fgoods.Owner = this;
            fgoods.Show();
        }
    }
}
