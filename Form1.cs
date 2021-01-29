using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8queen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //放在第一行位置
            eightQueen(0);
            for (int i = 1; i <= qSolutionBoxList.Count; i++)
            {
                listBox1.Items.Add("Solution " + i);
            }
        }

        static int max = 8; //皇后個數
        private int[] qArray = new int[max]; //皇后位置
        private List<string[,]> qSolutionBoxList = new List<string[,]>(); //棋盤解List
        private void eightQueen(int n)
        {
            //放到第8個皇后
            if (n == max)
            {
                string[,] qSolutionBox = new string[max, max]; //棋盤解
                for (int i = 0; i < qArray.Length; i++)
                {
                    for (int j = 0; j < max; j++)
                    {
                        if (j == qArray[i])
                        {
                            qSolutionBox[i, qArray[i]] = "Q";
                        }
                        else
                        {
                            qSolutionBox[i, j] = ".";
                        }
                    }
                }
                qSolutionBoxList.Add(qSolutionBox);
                return;
            }

            for (int i = 0; i < max; i++)
            {
                //將第n個皇后放入該行第i格
                qArray[n] = i;
                if (check(n))
                {
                    //無衝突放入第n個皇后，並接著放第n+1個皇后
                    eightQueen(n + 1);
                }
                //若n+1比對至第7格無安全位，則重放n
            }
        }

        private bool check(int n)
        {
            for (int i = 0; i < n; i++)
            {
                //同一縱列已有皇后
                if (qArray[i] == qArray[n])
                {
                    return false;
                }
                //交叉行已有皇后
                if (Math.Abs(n - i) == Math.Abs(qArray[n] - qArray[i]))
                {
                    return false;
                }

            }
            return true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int index = listBox1.SelectedIndex;

            string[,] q = qSolutionBoxList[index];

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    textBox1.Text += q[i, j] + "\n";
                    CheckBox ckb = (CheckBox)this.Controls.Find("cell" + i + j, true)[0];
                    if (q[i, j] == "Q")
                    {
                        ckb.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        ckb.CheckState = CheckState.Unchecked;
                    }
                }

                textBox1.Text += "\r\n";
            }
        }

    }
}
