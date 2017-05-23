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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = "旧版本功能:\r\n1、数据保存EXCEL功能\r\n2、协议接收数据\r\n3、支持协议功能位设置\r\n4、支持协议接收与普通接收选择\r\n5、增加一种新协议\r\n";
            textBox1.AppendText("新版本功能:\r\n6、支持发送EXCEL数据给下位机\r\n");
            textBox1.AppendText("DesignedBy黎明工作室（孟令军）\r\n");
        }
    }
}
