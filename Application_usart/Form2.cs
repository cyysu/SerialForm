using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Application_usart
{
    public partial class Form2 : Form
    {
       // private Form1 f;//添加私有的父窗体的对象。

        public Form2()
        {
            InitializeComponent();
            //初始化
          
            Data1.Text = "0x" + Form1.Flag_VoltageData[0].ToString("X2");
            Data2.Text = "0x" + Form1.Flag_VoltageData[1].ToString("X2");
            Data3.Text = "0x" + Form1.Flag_SOCData[0].ToString("X2");
            Data4.Text = "0x" + Form1.Flag_SOCData[1].ToString("X2");
            Data5.Text = "0x" + Form1.Flag_SOHData[0].ToString("X2");
            Data6.Text = "0x" + Form1.Flag_SOHData[1].ToString("X2");
            Data7.Text = "0x" + Form1.Flag_TemperatureData[0].ToString("X2");
            Data8.Text = "0x" + Form1.Flag_TemperatureData[0].ToString("X2");
            header.Text = "0x" + Form1.Header_data.ToString("X2");
            state.Text = "0x" + Form1.Flag_Sum[0].ToString("X2");
            voltage.Text = "0x" + Form1.Flag_Sum[1].ToString("X2");
            current.Text = "0x" + Form1.Flag_Sum[2].ToString("X2");
            soc.Text = "0x" + Form1.Flag_Sum[3].ToString("X2");
            
            //Data2.Text = Form1.Flag_VoltageData[0].ToString();
           // Data2.Text = Form1.Flag_VoltageData[0].ToString();
            
        }

        private void Data8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {//保存单体功能位
            string str = Data1.Text;
            byte a = 0x10;
            if((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_VoltageData[0] = ((byte)((Convert.ToInt32(str[2])-48) * 16));
            }
            else
            {
                Form1.Flag_VoltageData[0] =  ((byte)((Convert.ToInt32(str[2])-55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_VoltageData[0] += ((byte)((Convert.ToInt32(str[3])-48)));
            }
            else
            {
                Form1.Flag_VoltageData[0] +=  (byte)(Convert.ToInt32(str[3])-55);// +(byte)Convert.ToInt32(str[3]);
            }
         

 
            str = Data2.Text;
            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_VoltageData[1] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_VoltageData[1] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_VoltageData[1] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_VoltageData[1] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }


            str = Data3.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_SOCData[0] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_SOCData[0] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_SOCData[0] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_SOCData[0] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            
            
            str = Data4.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_SOCData[1] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_SOCData[1] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_SOCData[1] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_SOCData[1] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }


            str = Data5.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_SOHData[0] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_SOHData[0] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_SOHData[0] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_SOHData[0] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            
            str = Data6.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_SOHData[1] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_SOHData[1] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_SOHData[1] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_SOHData[1] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }


            str = Data7.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_TemperatureData[0] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_TemperatureData[0] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_TemperatureData[0] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_TemperatureData[0] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            
            str = Data8.Text;
            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_TemperatureData[1] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_TemperatureData[1] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_TemperatureData[1] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_TemperatureData[1] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }

            str = header.Text;
            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Header_data = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Header_data = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Header_data += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Header_data += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }

            str = state.Text;


            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_Sum[0] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_Sum[0] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_Sum[0] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_Sum[0] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }

            str = voltage.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_Sum[1] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_Sum[1] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_Sum[1] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_Sum[1] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }

            str = current.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_Sum[2] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_Sum[2] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_Sum[2] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_Sum[2] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }

            str = soc.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Flag_Sum[3] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Flag_Sum[3] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Flag_Sum[3] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Flag_Sum[3] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }


        }

        private void btn_clear_Click(object sender, EventArgs e)
        {//复位原值
            Data1.Text = "0x0A";
            Data2.Text = "0x1D";
            Data3.Text = "0x1F";
            Data4.Text = "0x2E";
            Data5.Text = "0x33";
            Data6.Text = "0x42";
            Data7.Text = "0x43";
            Data8.Text = "0x43";
            header.Text = "0x88";
            state.Text = "0x03";
            voltage.Text = "0x07";
            current.Text = "0x08";
            soc.Text = "0x09";
        }

        private void Header_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
