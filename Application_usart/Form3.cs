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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            Data1.Text = "0x" + Form1.Function_data[4].ToString("X2");

            Data3.Text = "0x" + Form1.Function_data[5].ToString("X2");

            Data5.Text = "0x" + Form1.Function_data[6].ToString("X2");

            Data7.Text = "0x" + Form1.Function_data[7].ToString("X2");

            header.Text = "0x" + Form1.Header_data.ToString("X2");
            state.Text = "0x" + Form1.Function_data[3].ToString("X2");
            voltage.Text = "0x" + Form1.Function_data[0].ToString("X2");
            current.Text = "0x" + Form1.Function_data[1].ToString("X2");
            soc.Text = "0x" + Form1.Function_data[2].ToString("X2");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //保存单体功能位
            string str = Data1.Text;
            byte a = 0x10;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Function_data[4] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[4] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[4] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[4] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }

            str = Data3.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Function_data[5] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[5] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[5] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[5] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            
            
            str = Data5.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Function_data[6] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[6] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[6] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[6] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            
            
            
            
            
            str = Data7.Text;

            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Function_data[7] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[7] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[7] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[7] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
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
                Form1.Function_data[3] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[3] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[3] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[3] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            str = voltage.Text;
            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Function_data[0] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[0] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[0] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[0] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            str = current.Text;
            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Function_data[1] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[1] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[1] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[1] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            str = soc.Text;
            if ((Convert.ToInt32(str[2])) >= 48 && (Convert.ToInt32(str[2])) <= 57)
            {
                Form1.Function_data[2] = ((byte)((Convert.ToInt32(str[2]) - 48) * 16));
            }
            else
            {
                Form1.Function_data[2] = ((byte)((Convert.ToInt32(str[2]) - 55) * 16));// +(byte)Convert.ToInt32(str[3]);
            }
            if ((Convert.ToInt32(str[3])) >= 48 && (Convert.ToInt32(str[3])) <= 57)
            {
                Form1.Function_data[2] += ((byte)((Convert.ToInt32(str[3]) - 48)));
            }
            else
            {
                Form1.Function_data[2] += (byte)(Convert.ToInt32(str[3]) - 55);// +(byte)Convert.ToInt32(str[3]);
            }
            

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            
                Form1.Function_data[0] = 0X00;
                Form1.Function_data[1] = 0X01;
                Form1.Function_data[2] = 2;
                Form1.Function_data[3] = 3;
                Form1.Function_data[4] = 4;
                Form1.Function_data[5] = 5;
                Form1.Function_data[6] = 6;
                Form1.Function_data[7] = 7;
            
        }
    }
}
