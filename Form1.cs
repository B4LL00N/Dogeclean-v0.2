using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace dogeclean
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetMD5FromFile(string filenPath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filenPath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var md5signatures = File.ReadAllLines("MD5Base.txt");
            if (md5signatures.Contains(tbMD5.Text))
            {
                lblStatus.Text = "Infected!";
                lblStatus.ForeColor = Color.Red;
            }

            else
            {
                lblStatus.Text = "Clean!";
                lblStatus.ForeColor = Color.Green;
            }

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string infoMessage = "Dogeclean v0.2 (Test Build) Made by crinobaka. Written in C# on .NET forms. http://dogeclean.tk http://dogecleaner.tk";
            string infoTitle = "Information";
            MessageBox.Show(infoMessage, infoTitle);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files | *.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbMD5.Text = GetMD5FromFile(ofd.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string infoMessage = "There is no Help option currently, due to this being a test build";
            string infoTitle = "Tutorial";
            MessageBox.Show(infoMessage, infoTitle);
        }
    }
    }