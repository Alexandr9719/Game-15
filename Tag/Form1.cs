using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

       
        private void Form1_Load(object sender, EventArgs e)
        {          

            Game.pan.Visible = true;
            Game.pan.Controls.Clear();
            Game.Rand_arr(Game.Arr);
            Game.Arr2 = Game.CreateMatrix<int>(Game.Arr);
            Game._newBut(Game.Arr2);
            Game.num_Clicks.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.num_Clicks.Text = "0";
            Game.pan.Controls.Clear();
            Game.Rand_arr(Game.Arr);
            Game.Arr2 = Game.CreateMatrix<int>(Game.Arr);
            Game._newBut(Game.Arr2);
        }
    }
}
