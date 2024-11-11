using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Xml;
using System.Net.Http;




namespace lab11_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            string myContent;
            openFileDialog1.Filter = "Text Files(.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                myContent = reader.ReadToEnd();
                reader.Close();
                richTextBox1.Text = myContent;
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                writer.Write(richTextBox1.Text);
                writer.Close();
            }
            saveFileDialog1.FileName=
                openFileDialog1.FileName.ToString();
            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
           
         
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void uRLStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WebRequest myRequest;

                myRequest = WebRequest.Create(richTextBox1.Text);
                WebResponse myResponse = myRequest.GetResponse();
                Stream rStream = myResponse.GetResponseStream();
                StreamReader reader = new StreamReader(rStream);
                StringBuilder sb = new StringBuilder();
                do
                {
                    sb.Append(reader.ReadLine() + "\n");
                } while (reader.ReadLine() != null);
                richTextBox1.Text = sb.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Invald URL");
            }
            
        }
    }
}
