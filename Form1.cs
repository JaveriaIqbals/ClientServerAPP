using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTCP;

namespace ClientServerAPP
{
    public partial class Form1 : Form
    {

        SimpleTcpClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.DataReceived += clientFunction;
            client.Connect(this.textBox1.Text, Convert.ToInt32(this.textBox2.Text));
        }

        void clientFunction(object sender, SimpleTCP.Message e)
        {
            // this is receiving from server.
           this.richTextBox2.Invoke((MethodInvoker)delegate ()
           {
               richTextBox2.Text += e.MessageString;
           });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(richTextBox1.Text, TimeSpan.FromSeconds(3));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
