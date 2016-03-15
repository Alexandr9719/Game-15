using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tag
{
    static class Game
    {
        public static int clicks;
        public static Panel pan = new Panel();
        public static TextBox num_Clicks = new TextBox();
        static Game()
        {
            //Form1.ActiveForm.Controls.Add(pan);
            //Form1.ActiveForm.Controls.Add(num_Clicks);
            clicks = 0;
            pan.Width = 474;
            pan.Height = 433;
            pan.Location = new Point(12, 52);
            pan.Visible = true;
            num_Clicks.Enabled = false;

            num_Clicks.Width = 87;
            num_Clicks.Height = 20;
            num_Clicks.Location = new Point(399, 12);
        }
        public static int[] Arr = new int[] { 1, 5, 9, 13, 2, 6, 10, 14, 3, 7, 11, 15, 4, 8, 12, 0 };
        public static int[,] Arr2 = new int[4, 4];
        public static int[] zero = new int[2];
        public static int[] index = new int[2];     
        
        public static bool CheckVictory(int[,] array)
        {
            int[,] VictoryArray = new int[4, 4] { { 1, 5, 9, 13 }, { 2, 6, 10, 14 }, { 3, 7, 11, 15 }, { 4, 8, 12, 0 } };
            bool res = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (array[i, j] != VictoryArray[i, j])
                    {
                        res = false;

                    }
                }
            }
            return res;
        }

        public static void Rand_arr(this int[] array)
        {
            if (array.Length < 1) return;
            var random = new Random();
            for (var i = 0; i < array.Length; i++)
            {
                var key = array[i];
                var rnd = random.Next(i, array.Length);
                array[i] = array[rnd];
                array[rnd] = key;
            }
        }
        public static T[,] CreateMatrix<T>(T[] array)
        {
            int len = array.Length;

            var rows = (int)(len / Math.Sqrt(len));
            if (rows <= 0) rows = 1;

            int col = array.Length / rows;
            var matrix = new T[rows, col];

            for (int i = 0; i < len; i++)
            {
                matrix[i / rows, i % rows] = array[i];
            }
            return matrix;
        }

        public static void _newBut(int[,] array)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Button _but = new Button();
                    _but.Name = "button" + array[i, j];
                    _but.Text = Convert.ToString(array[i, j]);
                    _but.Location = new Point(i * 100 + 15, j * 100 + 15);
                    _but.Size = new Size(100, 100);
                    _but.Click += _but_Click;
                    pan.Controls.Add(_but);
                    if (_but.Text == "0")
                    {
                        _but.Visible = false;
                        zero[0] = i;
                        zero[1] = j;

                    }

                }
            }
        }

        private static void _but_Click(object sender, EventArgs e)
        {
            int _index = Convert.ToInt32(((Button)sender).Text);
            GetIndex(_index);
            if (((index[0] == zero[0] - 1 || index[0] == zero[0] + 1) && (index[1] == zero[1])) || ((index[1] == zero[1] - 1 || index[1] == zero[1] + 1) && (index[0] == zero[0])))
            {
                clicks++;
                int tempLine = zero[0];
                int tempRow = zero[1];
                zero[0] = index[0];
                zero[1] = index[1];
                Arr2[zero[0], zero[1]] = 0;
                Arr2[tempLine, tempRow] = _index;
                pan.Controls.Clear();
                _newBut(Arr2);
                num_Clicks.Text = Convert.ToString(clicks);

                if (CheckVictory(Arr2) == true)
                {
                    MessageBox.Show("Win!!!");
                }
            }
        }

        static int[] GetIndex(int _butName)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Arr2[i, j] == _butName)
                    {
                        index[0] = i;
                        index[1] = j;
                    }
                }
            }
            return index;

        }
    }
}
