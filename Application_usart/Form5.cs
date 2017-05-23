using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Application_usart
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            int i = 0;
            InitializeComponent();
            comboBox1.Text = "COM1";
            for (i = 1; i < 10; i++)
            {
                comboBox1.Items.Add("COM" + i.ToString());
            }
            comboBox2.Text = "115200";
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (Form1.Funcetion_Receive == 1)
            {
                if (!radioButton1.Checked)
                {
                    string str = serialPort1.ReadExisting();//字符串方式读
                    textBox_receive.AppendText(str);
                    // string[] str = new string[serialPort1.BytesToRead];
                    // serialPort1.read
                }
                else
                {

                    try
                    {
                        Byte[] receivedData = new Byte[serialPort1.BytesToRead];        //创建接收字节数组
                        serialPort1.Read(receivedData, 0, receivedData.Length);         //读取数据
                        for (int i = 0; i < receivedData.Length; i++)
                            textBox_receive.AppendText("0x" + receivedData[i].ToString("X2") + "   ");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "出错提示");

                    }

                }
            }
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            // if(Button_on == 1)
            if (!serialPort1.IsOpen)//如果串口是开
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text, 10);
                float f = Convert.ToSingle(comboBox3.Text.Trim());
                if (f == 0)//设置停止位
                    serialPort1.StopBits = StopBits.None;
                else if (f == 1.5)
                    serialPort1.StopBits = StopBits.OnePointFive;
                else if (f == 1)
                    serialPort1.StopBits = StopBits.One;
                else if (f == 2)
                    serialPort1.StopBits = StopBits.Two;
                else
                    serialPort1.StopBits = StopBits.One;
                //设置数据位
                serialPort1.DataBits = Convert.ToInt32(comboBox4.Text.Trim());
                //设置奇偶校验位
                string s = comboBox5.Text.Trim();
                if (s.CompareTo("无") == 0)
                    serialPort1.Parity = Parity.None;
                else if (s.CompareTo("奇校验") == 0)
                    serialPort1.Parity = Parity.Odd;
                else if (s.CompareTo("偶校验") == 0)
                    serialPort1.Parity = Parity.Even;
                else
                    serialPort1.Parity = Parity.None;
                try
                {
                    serialPort1.Open();     //打开串口
                    button_open.Text = "关闭串口";
                    comboBox1.Enabled = false;//关闭使能
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;
                    comboBox5.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("串口打开失败！");
                }
            }
            else//如果串口是打开的则将其关闭
            {
                serialPort1.Close();
                button_open.Text = "打开串口";
                comboBox1.Enabled = true;//使能配置
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                comboBox5.Enabled = true;
            }           
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            //发送数据
            if (serialPort1.IsOpen)
            {//如果串口开启
                if (textBox_send.Text.Trim() != "")//如果框内不为空则
                {
                    serialPort1.Write(textBox_send.Text.Trim());//写数据
                }
                else
                {
                    MessageBox.Show("发送框没有数据");
                }
            }
            else
            {
                MessageBox.Show("串口未打开");
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_receive.Text = "";
        }
    }
}
