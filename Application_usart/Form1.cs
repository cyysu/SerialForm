using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Data.OleDb;
using System.Diagnostics;  

namespace Application_usart
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 标签宽度
        /// </summary>
        public const int Width_Label = 47;
        /// <summary>
        /// 标签高度
        /// </summary>
        public const int Height_Label = 12;
        /// <summary>
        /// 文本框宽度
        /// </summary>
        public const int Width_Text = 50;
        /// <summary>
        /// 文本框高度
        /// </summary>
        public const int Height_Text = 20;
        /// <summary>
        /// COM号
        /// </summary>
        int COM_MAX = 10;//COM口号最大值
        /// <summary>
        /// 数据显示页码状态
        /// </summary>
        int State_Show = 0;
        int Button_on = 1;
        int temp1 = 0;
        /*声明数据数组*/
        /*1电池电压数组2电池SOC数组3电池SOH数组*/
        /// <summary>
        /// 电池电压
        /// </summary>
        TextBox[] Voltage_Battery = new TextBox[5 * 20];
        /// <summary>
        /// 电池SOC数据文本框数组
        /// </summary>
        TextBox[] Soc_Battery = new TextBox[5 * 20];
        /// <summary>
        /// 电池SOH文本框数组
        /// </summary>
        TextBox[] Soh_Battery = new TextBox[5 * 20];
        TextBox[] Fj_Battery = new TextBox[5 * 20];
        /// <summary>
        /// 电池温度数据
        /// </summary>
        TextBox[] Temperature_Battery = new TextBox[5 * 20];
        
        /*数据帧协议*/
        public static Byte Flag_DataT = 0;//数据发送协议切换
        /// <summary>
        /// 帧头
        /// </summary>
        public static Byte Header_data = 0x88;//数据帧头
        /// <summary>
        /// 功能位
        /// </summary>
        public static Byte[] Function_data = {0x01,0x02,0x03,0x04,0x05,0x06,0x07,0XFF,0XFF,0XFF,0XFF};//功能位
        /// <summary>
        /// 电池最大数量
        /// </summary>
        public static Byte Max_BatteryNum = 100;//电池数量
        
        
        public static byte[] Flag_VoltageData = {0x0A,0x1D};
        public static byte[] Flag_SOCData = { 0x1F, 0x2E };
        public static byte[] Flag_SOHData = { 0x33, 0x42 };
        public static byte[] Flag_TemperatureData = { 0x43, 0x43 };//待添加
        public static byte[] Flag_Sum = { 0x03, 0x07, 0x08, 0x09 };
        /*动态变量*/
        int Length_Data = 0;
        public static int Funcetion_Receive = 0;

        byte[] DATADATA = {0X11,0X01};

        string localFilePath = "";// fileNameExt, newFileName, FilePath; 

        //参数字符串
        string[,] Parameter_A = new string[100, 1];
        string[,] Parameter_B = new string[100, 1];
        string[,] Parameter_C = new string[100, 1];

        string fileNameHistory;

        private List<String> DataList = new List<String>();

        int Count_Battery = 0;



        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            panel1.Visible = false;
  
        }
        /// <summary>
        /// Form1窗体生成函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            PAGE_Init();
            comboBox1.Text = "COM1";
            for(i=1;i<COM_MAX;i++)
            {
                comboBox1.Items.Add("COM" + i.ToString());
            }
            comboBox2.Text = "115200";
           // for(int i = 0;i<)
          //  serialPort1.DataReceived += new SerialDataReceivedEventHandler(post_DataReceived);
        }


        private void post_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Count_Battery = 0;
            Thread.Sleep(800); //延时
         /*   try
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


              */ 
             if (Funcetion_Receive == 0)
             {
                 if (Flag_DataT == 0)
                 {//第一版传输协议
                     try//尝试协议接收数据
                     {
                         Byte[] receivedData = new Byte[serialPort1.BytesToRead];        //创建接收字节数组
                         serialPort1.Read(receivedData, 0, receivedData.Length);         //读取数据
                         //循环遍历接收到的数组
                         for (int i = 0; i < receivedData.Length - 4; i++)
                         {
                             if (receivedData[i] == Header_data)
                             {//数据协议   帧头
                                 if ((receivedData[i + 1] + receivedData[i + 2] + receivedData[i + 3]) == receivedData[i + 4])
                                 {//和校验
                                     if (receivedData[i + 1] >= Flag_VoltageData[0] && receivedData[i + 1] <= Flag_VoltageData[1])
                                     {//电压数据显示
                                         Voltage_Battery[receivedData[i + 1] - Flag_VoltageData[0]].Text = (receivedData[i + 3] * 256 + receivedData[i + 2]).ToString() + "mv";//.ToString("X2");
                                         i = i + 4;
                                         //   textBox_receive.AppendText(i.ToString());//测试用语句
                                     }
                                     else if (receivedData[i + 1] >= Flag_SOCData[0] && receivedData[i + 1] <= Flag_SOCData[1])
                                     {//SOC数据显示
                                         Soc_Battery[receivedData[i + 1] - Flag_SOCData[0]].Text = (receivedData[i + 3] * 256 + receivedData[i + 2]).ToString() + "%";
                                         i = i + 4;
                                         //   textBox_receive.AppendText(i.ToString());//测试用语句
                                     }
                                     else if (receivedData[i + 1] >= Flag_SOHData[0] && receivedData[i + 1] <= Flag_SOHData[1])
                                     {//SOH数据显示
                                         Soh_Battery[receivedData[i + 1] - Flag_SOHData[0]].Text = (receivedData[i + 3] * 256 + receivedData[i + 2]).ToString() + "%";
                                         i = i + 4;
                                         //    textBox_receive.AppendText(i.ToString());//测试用语句
                                     }
                                     else if (receivedData[i + 1] >= Flag_TemperatureData[0] && receivedData[i + 1] <= Flag_TemperatureData[1])
                                     {//Temperature数据显示
                                         Temperature_Battery[receivedData[i + 1] - Flag_TemperatureData[0]].Text = (receivedData[i + 3] * 256 + receivedData[i + 2]).ToString() + "C";
                                         i = i + 4;
                                         //    textBox_receive.AppendText(i.ToString());//测试用语句
                                     }
                                     //总电池显示显示
                                     else if (receivedData[i + 1] == Flag_Sum[0])
                                     {//充电状态
                                         if (receivedData[i + 2] == 0x01)
                                         {
                                             Statu_Battery.Text = "静置状态";
                                             i = i + 4;
                                         }
                                         else if (receivedData[i + 2] == 0x02)
                                         {
                                             Statu_Battery.Text = "放电状态";
                                             i = i + 4;
                                         }
                                         else if (receivedData[i + 2] == 0x04)
                                         {
                                             Statu_Battery.Text = "充电状态";
                                             i = i + 4;
                                         }
                                     }
                                     else if (receivedData[i + 1] == Flag_Sum[1])
                                     {//总电压显示

                                         Voltage_Sum.Text = (receivedData[i + 3] * 256 + receivedData[i + 2]).ToString() + "mv";
                                         i = i + 4;
                                     }
                                     else if (receivedData[i + 1] == Flag_Sum[2])
                                     {//总电流显示

                                         Current_Sum.Text = (receivedData[i + 3] * 256 + receivedData[i + 2]).ToString() + "mA";
                                         i = i + 4;
                                     }
                                     else if (receivedData[i + 1] == Flag_Sum[3])
                                     {//总SOC显示

                                         SOC_Sum.Text = (receivedData[i + 3] * 256 + receivedData[i + 2]).ToString() + "%";
                                         i = i + 4;
                                     }


                                 }

                             }
                             else
                             {
                                 // textBox1.AppendText(receivedData[i].ToString("X2") + " ");
                                 // strRcv += receivedData[i].ToString("X2") + " ";
                             }
                         }
                         Length_Data = Length_Data + receivedData.Length;//记录数据量
                         Counter.Text = Length_Data.ToString();
                         //                int count = strRcv.Length / 48;                           // 记录数据的个数
                         //       for (int j = 0; j < count; j++)
                         {
                             /// 获取每条记录
                             //               string buf1 = strRcv.Substring(j * 48, 48);
                             /// 添加字符串数据到数据库
                             //             DataList.Add(buf1);
                         }

                     }
                     catch (System.Exception ex)
                     {
                         MessageBox.Show(ex.Message, "出错提示");
                         //    textBox1.Text = "";
                     }
                    
                 }
                 else if (Flag_DataT == 1)
                 {//第二版传输协议
                     try//尝试协议接收数据
                     {
                         Byte[] receivedData = new Byte[serialPort1.BytesToRead];        //创建接收字节数组
                         serialPort1.Read(receivedData, 0, receivedData.Length);         //读取数据
                         //循环遍历接收到的数组
                         for (int i = 0; i < receivedData.Length - 4; i++)
                         {
                             if (receivedData[i] == Header_data)
                             {//数据协议   帧头
                                 if ((receivedData[i + 1] + receivedData[i + 2] + receivedData[i + 3] + receivedData[i + 4]) == receivedData[i + 5])
                                 {//和校验
                                     if (receivedData[i + 1] == Function_data[0])
                                     {//总电压
                                         Voltage_Sum.Text = (receivedData[i + 4] * 256 + receivedData[i + 3]).ToString() + "mv";//.ToString("X2");
                                         i = i + 5;
                                     }
                                     else if (receivedData[i + 1] == Function_data[1])
                                     {//总电流
                                         Current_Sum.Text = (receivedData[i + 4] * 256 + receivedData[i + 3]).ToString() + "mA";//.ToString("X2");
                                         i = i + 5;
                                     }
                                     else if (receivedData[i + 1] == Function_data[2])
                                     {//总SOC
                                         SOC_Sum.Text = (receivedData[i + 4] * 256 + receivedData[i + 3]).ToString() + "%";//.ToString("X2");
                                         i = i + 5;
                                     }
                                     else if (receivedData[i + 1] == Function_data[3])
                                     {//电池状态
                                         if (receivedData[i + 3] == 0x01)
                                         {
                                             Statu_Battery.Text = "静置状态";
                                             i = i + 5;
                                         }
                                         else if (receivedData[i + 3] == 0x02)
                                         {
                                             Statu_Battery.Text = "放电状态";
                                             i = i + 5;
                                         }
                                         else if (receivedData[i + 3] == 0x04)
                                         {
                                             Statu_Battery.Text = "充电状态";
                                             i = i + 5;
                                         }
                                     }
                                     else if (receivedData[i + 1] == Function_data[4])
                                     {//单体电压
                                         Voltage_Battery[receivedData[i + 2]].Text = (receivedData[i + 4] * 256 + receivedData[i + 3]).ToString() + "mv";//.ToString("X2");
                                         i = i + 5;
                                         Count_Battery++;
                                     }
                                     else if (receivedData[i + 1] == Function_data[5])
                                     {//单体SOC
                                         Soc_Battery[receivedData[i + 2]].Text = (receivedData[i + 4] * 256 + receivedData[i + 3]).ToString() + "%";//.ToString("X2");
                                         i = i + 5;

                                     }
                                     else if (receivedData[i + 1] == Function_data[6])
                                     {//单体SOH
                                         Soh_Battery[receivedData[i + 2]].Text = (receivedData[i + 4] * 256 + receivedData[i + 3]).ToString() + "%";//.ToString("X2");
                                         i = i + 5;
                                     }
                                     else if(receivedData[i + 1] == Function_data[7])
                                     {
                                         Temperature_Battery[receivedData[i + 2]].Text = (receivedData[i + 4] * 256 + receivedData[i + 3]).ToString() + "°";//.ToString("X2");
                                         i = i + 5;
                                     }

                                 }

                             }
                             else
                             {
                                 // textBox1.AppendText(receivedData[i].ToString("X2") + " ");
                                 // strRcv += receivedData[i].ToString("X2") + " ";
                             }
                         }
                         Length_Data = Length_Data + receivedData.Length;//记录数据量
                         Counter.Text = Length_Data.ToString();
                         //                int count = strRcv.Length / 48;                           // 记录数据的个数
                         //       for (int j = 0; j < count; j++)
                         {
                             /// 获取每条记录
                             //               string buf1 = strRcv.Substring(j * 48, 48);
                             /// 添加字符串数据到数据库
                             //             DataList.Add(buf1);
                         }

                     }
                     catch (System.Exception ex)
                     {
                         MessageBox.Show(ex.Message, "出错提示");
                         //    textBox1.Text = "";
                     }
                 }
                
             }
           
            /////

             DateTime dt = DateTime.Now;

           

            DataList.Add(dt.ToString());

             DataList.Add(Statu_Battery.Text);
             DataList.Add(Voltage_Sum.Text);
             DataList.Add(Current_Sum.Text);
             DataList.Add(SOC_Sum.Text);
             
            for(int i = 0;i<Count_Battery;i++)
            {
                DataList.Add(Voltage_Battery[i].Text);
                DataList.Add(Soc_Battery[i].Text);
                DataList.Add(Soh_Battery[i].Text);
                DataList.Add(Temperature_Battery[i].Text);
            }
            
           
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void button_clear_Click(object sender, EventArgs e)
        {
           
        }

        private void Btn_Volatage_Click(object sender, EventArgs e)
        {//电压显示
            State_Show = 0;
            group_voltage.Visible = true;
            group_soc.Visible = false;
            group_soh.Visible = false;
            group_fujia.Visible = false;
            group_temperature.Visible = false;
        }

        private void Btn_SOC_Click(object sender, EventArgs e)
        {//SOC显示
            State_Show = 1;
            group_voltage.Visible = false;
            group_soc.Visible = true;
            group_soh.Visible = false;
            group_fujia.Visible = false;
            group_temperature.Visible = false;
            
            //this.group_soc.BringToFront();
        }

        private void Btn_SOH_Click(object sender, EventArgs e)
        {
            State_Show = 2;
            group_voltage.Visible = false;
            group_soc.Visible = false;
            group_soh.Visible = true;
            group_fujia.Visible = false;
            group_temperature.Visible = false;
            
        }

        private void Btn_ADD_Click(object sender, EventArgs e)
        {
            State_Show = 3;
            group_voltage.Visible = false;
            group_soc.Visible = false;
            group_soh.Visible = false ;
            group_fujia.Visible = true;
            group_temperature.Visible = false;
        }
        public void PAGE_Init()
        {

            //声明暂存变量
            int i=0,j=0;
            //1电池组电压容器创建
            //添加文本框与字符
            for (i = 0; i < 5;i++ )
            {
                for (j=0;j<20;j++)
                {
                    //创建标签与显示窗体
                    Label Label_Voltage = new Label();

                    //设置标签属性
                    Label_Voltage.Name = "Label_Volatage" + (i + j * 5 + 1).ToString();
                    Label_Voltage.Text = "电池" + (i + j * 5 + 1).ToString();
                    Label_Voltage.Width = Width_Label;
                    Label_Voltage.Height = Height_Label;

                    //位置确定
                    Label_Voltage.Location = new Point(15 + i * (Width_Label + Width_Text + 6), 15 + j * (12 + Height_Label));

                    group_voltage.Controls.Add(Label_Voltage);//将字符添加到容器1中
                    //电池组电压数组设置
                    Voltage_Battery[i + j * 5] = new TextBox();//注意！！！先声明对象
                    Voltage_Battery[i + j * 5].Name = "Voltage_Battery" + i.ToString();
                    Voltage_Battery[i + j * 5 ].Text = "-";
                    Voltage_Battery[i + j * 5].Width = Width_Text;
                    Voltage_Battery[i + j * 5].Height = Height_Text;
                    Voltage_Battery[i + j * 5 ].Location = new Point(67 + i * (Width_Label + Width_Text + 6), 11 + j * (4 + Height_Text));
                    group_voltage.Controls.Add(Voltage_Battery[i + j * 5]);//将电压组添加到容器1中
                }
            }
           //设置宽度
           this.group_voltage.Width = 552;
           this.group_voltage.Height = 500;
            
            //SOC容器搭建
            //添加文本框与字符
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    //创建标签
                    Label Label_Soc = new Label();

                    //设置标签属性
                    Label_Soc.Name = "Label_SOC" + (i + j * 5 + 1).ToString();
                    Label_Soc.Text = "SOC" + (i + j * 5 + 1).ToString();
                    Label_Soc.Width = Width_Label;
                    Label_Soc.Height = Height_Label;
                    //设置文本框数组属性
                    Soc_Battery[i + j * 5] = new TextBox();//注意！！！先声明对象
                    Soc_Battery[i + j * 5].Name = "SOC_Battery" + (i + j * 5 + 1).ToString();
                    Soc_Battery[i + j * 5].Text = "-";
                    Soc_Battery[i + j * 5].Width = Width_Text;
                    Soc_Battery[i + j * 5].Height = Height_Text;

                    //位置确定
                    Label_Soc.Location = new Point(15 + i * (Width_Label + Width_Text + 6), 15 + j * (12 + Height_Label));
                    group_soc.Controls.Add(Label_Soc);//将字符添加到容器2中

                    Soc_Battery[i + j * 5].Location = new Point(67 + i * (Width_Label + Width_Text + 6), 11 + j * (4 + Height_Text));
                    group_soc.Controls.Add(Soc_Battery[i + j * 5]);//将SOC添加到容器2中
                }
            }
            //设置宽度位置
            this.group_soc.Width = group_voltage.Width;
            this.group_soc.Height = group_voltage.Height;
            group_soc.Location = group_voltage.Location;

            //SOH容器搭建
            //添加文本框与字符
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    //创建标签与显示窗体
                    Label Label_Soh = new Label();
    

                    //设置标签属性
                    Label_Soh.Name = "Label_SOH" + (i + j * 5 + 1).ToString();
                    Label_Soh.Text = "SOH" + (i + j * 5 + 1).ToString();
                    Label_Soh.Width = Width_Label;
                    Label_Soh.Height = Height_Label;

                    Soh_Battery[i + j * 5] = new TextBox();//注意！！！先声明对象
                    //设置文本框属性
                    Soh_Battery[i + j * 5].Name = "SOH_Battery" + (i + j * 5 + 1).ToString();
                    Soh_Battery[i + j * 5].Text = "-";
                    Soh_Battery[i + j * 5].Width = Width_Text;
                    Soh_Battery[i + j * 5].Height = Height_Text;

                    //位置确定
                    Label_Soh.Location = new Point(15 + i * (Width_Label + Width_Text + 6), 15 + j * (12 + Height_Label));
                    group_soh.Controls.Add(Label_Soh);//将字符添加到容器3中

                    Soh_Battery[i + j * 5].Location = new Point(67 + i * (Width_Label + Width_Text + 6), 11 + j * (4 + Height_Text));
                    group_soh.Controls.Add(Soh_Battery[i + j * 5]);//将SOH添加到容器3中
                }
            }
            //设置宽度位置
            this.group_soh.Width = group_voltage.Width;
            this.group_soh.Height = group_voltage.Height;
            group_soh.Location = group_voltage.Location;


            //附加页面容器搭建
            //添加文本框与字符
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    //创建标签与显示窗体
                    Label Label_Fj = new Label();

                    //设置标签属性
                    Label_Fj.Name = "Label_Fj" + (i + j * 5 + 1).ToString();
                    Label_Fj.Text = "附加" + (i + j * 5 + 1).ToString();
                    Label_Fj.Width = Width_Label;
                    Label_Fj.Height = Height_Label;

                    Fj_Battery[i + j * 5] = new TextBox();//注意！！！先声明对象
                    //设置文本框属性
                    Fj_Battery[i + j * 5].Name = "Fj_Battery" + (i + j * 5 + 1).ToString();
                    Fj_Battery[i + j * 5].Text = "-";
                    Fj_Battery[i + j * 5].Width = Width_Text;
                    Fj_Battery[i + j * 5].Height = Height_Text;

                    //位置确定
                    Label_Fj.Location = new Point(15 + i * (Width_Label + Width_Text + 6), 15 + j * (12 + Height_Label));
                    group_fujia.Controls.Add(Label_Fj);//将字符添加到容器4中

                    Fj_Battery[i + j * 5].Location = new Point(67 + i * (Width_Label + Width_Text + 6), 11 + j * (4 + Height_Text));
                    group_fujia.Controls.Add(Fj_Battery[i + j * 5]);//将SOC添加到容器4中
                }
            }
            //设置宽度位置
            this.group_fujia.Width = group_voltage.Width;
            this.group_fujia.Height = group_voltage.Height;
            group_fujia.Location = group_voltage.Location;

            //温度页面容器搭建
            //添加文本框与字符
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 20; j++)
                {
                    //创建标签与显示窗体
                    Label Label_Temperature = new Label();

                    //设置标签属性
                    Label_Temperature.Name = "Label_Temperature" + (i + j * 5 + 1).ToString();
                    Label_Temperature.Text = "温度" + (i + j * 5 + 1).ToString();
                    Label_Temperature.Width = Width_Label;
                    Label_Temperature.Height = Height_Label;

                    Temperature_Battery[i + j * 5] = new TextBox();//注意！！！先声明对象
                    //设置文本框属性
                    Temperature_Battery[i + j * 5].Name = "Temperature_Battery" + (i + j * 5 + 1).ToString();
                    Temperature_Battery[i + j * 5].Text = "-";
                    Temperature_Battery[i + j * 5].Width = Width_Text;
                    Temperature_Battery[i + j * 5].Height = Height_Text;

                    //位置确定
                    Label_Temperature.Location = new Point(15 + i * (Width_Label + Width_Text + 6), 15 + j * (12 + Height_Label));
                    group_temperature.Controls.Add(Label_Temperature);//将字符添加到容器4中

                    Temperature_Battery[i + j * 5].Location = new Point(67 + i * (Width_Label + Width_Text + 6), 11 + j * (4 + Height_Text));
                    group_temperature.Controls.Add(Temperature_Battery[i + j * 5]);//将SOC添加到容器4中
                }
            }
            //设置宽度位置
            this.group_temperature.Width = group_voltage.Width;
            this.group_temperature.Height = group_voltage.Height;
            group_temperature.Location = group_voltage.Location;

        /*    foreach (Control C in group_voltage.Controls)
            {

                if (C.Name == "Voltage_Battery10")
                    C.Text = "1";
            } */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//定时器1s
            DateTime dt = DateTime.Now;
           
            Time_Now.Text = dt.ToString();
            

            /*
            foreach (String ss in DataList)
            {

            }*/


         //   Statu_Battery.Text = (DATADATA[0] * 16 + DATADATA[1]).ToString();//测试用语句
      /*      for(int i = 0;i < 100; i++)
            {
                Voltage_Battery[i].Text = temp1.ToString();
            }*/
            //Voltage_Battery[i].Text = temp1.ToString();
            temp1++;
         /*   Control C = ;//声明一个控件
            for(int i = 0;i < 100;i++)
            {
                C.Name = "Voltage_Battery" + i.ToString();
                C.Text = temp1.ToString();
                temp1++;
            }*/
          //  (Controls.FindControl("TextBox的ID") as TextBox).Text = "1";
          //  (Controls.Find("Voltage_Battery10") as TextBox).Text = "1";
        }

        private void textBox_send_TextChanged(object sender, EventArgs e)
        {
            State_Show = 4;
            group_voltage.Visible = false;
            group_soc.Visible = false;
            group_soh.Visible = false;
            group_fujia.Visible = false;
            group_temperature.Visible = true;
        }
        /*文件对话框*/
        private string ShowSaveFileDialog()
        {
            string localFilePath = "";// fileNameExt, newFileName, FilePath; 
            SaveFileDialog sfd = new SaveFileDialog();//保存文件窗口
            
            //设置文件类型 
            sfd.Filter = "Excel文件(*.xlsx)|*.xlsx";//保存类型为EXCEL
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

            }
            return localFilePath;
        }

        private void Btn_DataSave_Click(object sender, EventArgs e)
        {//数据存储
            /*******************数据导入Excel**********************/
            string fileName = ShowSaveFileDialog();         //文件的保存路径和文件名
            try
            {
                // 创建Excel文档
                Microsoft.Office.Interop.Excel.Application ExcelApp
                    = new Microsoft.Office.Interop.Excel.Application();
                //创建EXCEL文档
                Microsoft.Office.Interop.Excel.Workbook ExcelDoc = ExcelApp.Workbooks.Add(Type.Missing);
                // 创建一个EXCEL页

                Microsoft.Office.Interop.Excel.Worksheet xlSheet = ExcelDoc.Worksheets.Add(Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                ExcelApp.DisplayAlerts = false;

                // 单元格下标是从[1，1]开始的
                xlSheet.Cells[1, 1] = "序号";
                xlSheet.Cells[1, 2] = "电压";
                xlSheet.Cells[1, 3] = "SOC";
                xlSheet.Cells[1, 4] = "SOH";
                xlSheet.Cells[1, 5] = "温度";
                //遍历存数据
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 1] = "电池" + i.ToString();
                }
                for (int i = 0; i < 100;i++ )
                {
                    xlSheet.Cells[i + 2, 2] = Voltage_Battery[i].Text;
                }
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 3] = Soc_Battery[i].Text;
                }
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 4] = Soh_Battery[i].Text;
                }
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 5] = Temperature_Battery[i].Text;
                }

                // 文件保存完毕输出信息//将此页保存到我们新建的文档中
                xlSheet.SaveAs(fileName);
                //释放EXCEL资源
                ExcelDoc.Close(Type.Missing, fileName, Type.Missing);
                ExcelApp.Quit();
                MessageBox.Show("数据保存成功！");
            }
            catch
            {
                MessageBox.Show("数据保存失败！");
            }      
        }

        private void Temperature_Battery_Click(object sender, EventArgs e)
        {
            State_Show = 4;
            group_voltage.Visible = false;
            group_soc.Visible = false;
            group_soh.Visible = false;
            group_fujia.Visible = false;
            group_temperature.Visible = true;
        }

        private void 数据存储ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //数据存储
            /*******************数据导入Excel**********************/
            string fileName = ShowSaveFileDialog();         //文件的保存路径和文件名
            try
            {
                // 创建Excel文档
                Microsoft.Office.Interop.Excel.Application ExcelApp
                    = new Microsoft.Office.Interop.Excel.Application();
                
                //创建EXCEL文档
                Microsoft.Office.Interop.Excel.Workbook ExcelDoc = ExcelApp.Workbooks.Add(Type.Missing);
                // 创建一个EXCEL页

    //            Microsoft.Office.Interop.Excel.Worksheet xlSheet = ExcelDoc.Worksheets.Add(Type.Missing,
      //              Type.Missing, Type.Missing, Type.Missing);

                Microsoft.Office.Interop.Excel.Worksheet xlSheet1 = ExcelDoc.Worksheets.Add(Type.Missing,
                   Type.Missing, Type.Missing, Type.Missing);

                ExcelApp.DisplayAlerts = false;
/*
                // 单元格下标是从[1，1]开始的
                xlSheet.Cells[1, 1] = "序号";
                xlSheet.Cells[1, 2] = "电压";
                xlSheet.Cells[1, 3] = "SOC";
                xlSheet.Cells[1, 4] = "SOH";
                xlSheet.Cells[1, 5] = "温度";
                //遍历存数据
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 1] = "电池" + i.ToString();
                }
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 2] = Voltage_Battery[i].Text;
                }
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 3] = Soc_Battery[i].Text;
                }
                for (int i = 0; i < 100; i++)
                {
                    xlSheet.Cells[i + 2, 4] = Soh_Battery[i].Text;
                }  
         */ 
                

                // 单元格下标是从[1，1]开始的
                xlSheet1.Cells[1, 1] = "时间";
                xlSheet1.Cells[1, 2] = "工作状态";
                xlSheet1.Cells[1, 3] = "总电压";
                xlSheet1.Cells[1, 4] = "总电流";
                xlSheet1.Cells[1, 5] = "总SOC";
                // 遍历存数据
               for (int i = 1; i <= 100; i++)
                {
                    xlSheet1.Cells[1, 5 + i] = "电池" + i.ToString();
                }
                int COUNT = 0;
                int COUNT1 = 2;
                
                foreach (String ss in DataList)
                {
                    //Console.WriteLine(ss.ToString());
                    //Console.ReadKey();
                    xlSheet1.Cells[COUNT1, 1] = ss;
                    COUNT1++;
                /*    COUNT++;
                    if (COUNT == 1)
                        xlSheet1.Cells[COUNT1, 1] = ss;
                    else if (COUNT == Count_Battery * 3 + 4)
                    {
                        COUNT = 0;
                        COUNT1++;
                    }
                    else
                    {
                        xlSheet1.Cells[COUNT1, COUNT] = ss;
                    }*/
                }
           /*  /*      */
                // 文件保存完毕输出信息//将此页保存到我们新建的文档中
                //xlSheet.SaveAs(fileName);
                xlSheet1.SaveAs(fileName);
                //释放EXCEL资源
                ExcelDoc.Close(Type.Missing, fileName, Type.Missing);
                ExcelApp.Quit();
                MessageBox.Show("数据保存成功！");
            }
            catch
            {
                MessageBox.Show("数据保存失败！");
            }

        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0); 
        }

        private void 版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
            //MessageBox.Show("版本BMSV1.6\n1、数据保存EXCEL功能\n2、协议接收数据\n3、支持协议功能位设置\n4、支持协议接收与普通接收选择\n5、增加一种新协议\nDesignedBy黎明工作室（孟令军）");
        }

        private void 数据协议ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 普通接收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcetion_Receive = 1;
            协议接收ToolStripMenuItem.Text = "协议接收";
            普通接收ToolStripMenuItem.Text = "普通接收√";
            Form5 f = new Form5();//实例化子窗口时。
            f.Show();

        }

        private void 协议接收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funcetion_Receive = 0;
            协议接收ToolStripMenuItem.Text = "协议接收√";
            普通接收ToolStripMenuItem.Text = "普通接收";
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("帮助文档待开发!请静待下一版本");
        }

        private void 数据协议1旧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataClear();
            数据协议1旧ToolStripMenuItem.Text = "数据协议1旧√";
            数据协议2新ToolStripMenuItem.Text = "数据协议2新";
            Flag_DataT = 0;
            Form2 f = new Form2();//实例化子窗口时。
            f.Show();
        }

        private void 数据协议2新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataClear();
            数据协议1旧ToolStripMenuItem.Text = "数据协议1旧";
            数据协议2新ToolStripMenuItem.Text = "数据协议2新√";
            Flag_DataT = 1;//切换到新协议
            Form3 f = new Form3();//实例化子窗口时。
            f.Show();
        }

        private void 新协议说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();//实例化子窗口时。
            f.Show();
        }

        private void OpenExcel()
        {
            try
            {
                // 创建Excel类
                Microsoft.Office.Interop.Excel.Application ExcelApp
                    = new Microsoft.Office.Interop.Excel.Application();
                //设置只读方式
                ExcelApp.Visible = false; ExcelApp.UserControl = true;
                //打开文档
                Microsoft.Office.Interop.Excel.Workbook ExcelDoc = ExcelApp.Workbooks.Open(localFilePath);
                //取得第一个工作簿
                 Microsoft.Office.Interop.Excel.Worksheet xlSheet = ExcelDoc.Worksheets.get_Item(1);
                //获取行数 
                int rowsint = xlSheet.UsedRange.Cells.Rows.Count;//获取行数

                //////读取第一页数据（第二列数据参数存储到Parameter_A表格中）


                //数据存储为RANGE格式
                Microsoft.Office.Interop.Excel.Range rng1 = xlSheet.Cells.get_Range("B2", "B" + rowsint);
                 object[,] ARRY1 = (object[,])rng1.Value2;
                //字符串 
                //保存为字符串
                 for (int i = 1; i <= rowsint - 1; i++)
                 {
                     Parameter_A[i - 1, 0] = ARRY1[i, 1].ToString();
                 }  
                
                for (int i = 0; i <= rowsint - 2; i++)  
                {
                    textBox1.AppendText(Parameter_A[i, 0]);
                }
                //退出EXCEL
                ExcelApp.Quit();
                Process[] procs = Process.GetProcessesByName("excel");
                foreach (Process pro in procs)
                {
                    pro.Kill();//没有更好的方法,只有杀掉进程  
                }
                GC.Collect();  
               
            }
            catch
            {
                MessageBox.Show("数据保存失败！");
            }   
                
                
        }

        public void DataClear()
        {
            int i = 0;
            for(i=0;i<100;i++)
            {
                Voltage_Battery[i].Text = "";
                Soc_Battery[i].Text = "";
                Soh_Battery[i].Text = "";
                Temperature_Battery[i].Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //读取数据
            OpenExcel();
            //发送数据
            //serialPort1.Write(textBox_send.Text.Trim());//写数据
            //发送数据
            if (serialPort1.IsOpen)
            {//如果串口开启
                for (int i = 0; i < 100;i++ )
                {
                    char str1 = (char)(i);//ID号
                    serialPort1.Write("[" + str1 + Parameter_A[i, 0] + " " + "]");//0x5b + ID  + 0x5d  写数据
                }
                    
            }
            else
            {
                MessageBox.Show("串口未打开");
            }
            
            
        }

        private void File_Chose_Click(object sender, EventArgs e)
        {//文件选择

            OpenFileDialog sfd = new OpenFileDialog();//保存文件窗口

            //设置文件类型 
            sfd.Filter = "Excel文件(*.xlsx)|*.xlsx";//保存类型为EXCEL
            //打开对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了打开按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 

            }
            File_ADD.Text = localFilePath;
        }

        private void 收发测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 上位机说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void group_voltage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 参数发送说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 fo = new Form8();
            fo.Show();
        }

        private void 历史数据存储ToolStripMenuItem_Click(object sender, EventArgs e)
        {//历史数据存储
            //
            fileNameHistory = ShowSaveFileDialog();         //文件的保存路径和文件名
            

            


        }
    }
}
