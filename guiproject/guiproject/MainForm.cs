﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace guiproject
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //保存路径
                string filePath = Path.GetFullPath(openFileDialog1.FileName);
                Console.WriteLine(filePath);
                //读取数据
                StreamReader str = new StreamReader(filePath);
                //获取每行字符
                string line;
                string inputStr = "";
                while ((line = str.ReadLine()) != null)
                {
                    //通过','将行分裂为字符串组
                    inputStr += line+"\n";
                }
                str.Close();
                textBox1.Text = inputStr;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK) 
            {
                string filePath = Path.GetFullPath(saveFileDialog1.FileName);
                StreamWriter sw = new StreamWriter(filePath, false);
                sw.Write(textBox2.Text);
                sw.Flush();
                sw.Close();
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String[] args = textBox3.Text.Split(" ");
                CommandParser parser = new CommandParser(args);
                ParseRes parseRes = parser.getParseRes();
                WordListMaker maker = new WordListMaker();
                string article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
                ArrayList wordList = maker.makeWordList(article);
                CalcuCore core = new CalcuCore(wordList, parseRes);
                core.runByArgs();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        private void buttonn_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text += " ";
            }
            textBox3.Text += buttonn.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonw_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text += " ";
            }
            textBox3.Text += buttonw.Text;
        }

        private void buttonm_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text += " ";
            }
            textBox3.Text += buttonm.Text;
        }

        private void buttonc_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text += " ";
            }
            textBox3.Text += buttonc.Text;
        }

        private void buttonh_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text += " ";
            }
            textBox3.Text += buttonh.Text + " ";
            toolTip1.IsBalloon = true;
            toolTip1.Show("请在命令参数输入框追加输入一个字母代表首字母", textBox3,new Point(312,-80),2000);
        }

        private void buttont_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text += " ";
            }
            textBox3.Text += buttont.Text + " ";
            //textBox3.Focus();
            toolTip1.IsBalloon = true;
            toolTip1.Show("请在命令参数输入框追加输入一个字母代表尾字母", textBox3, new Point(312, -80), 2000);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                textBox3.Text += " ";
            }
            textBox3.Text += button8.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
    }
}
