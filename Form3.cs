using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_X
{
    public partial class Form3 : Form
    {
        public Form3(string path, int number)
        {
            InitializeComponent();

            if (number == 1)
            {
                label1.Text = "(CS2) Finishing ...";
            }
            else
            {
                label1.Text = "(R6) Finishing ...";
            }
            Loader_unitaller(path);

        }

        private void Loader_unitaller(string path)
        {
       

            while (!IsProcessRunningpath(path))
            {
                Thread.Sleep(1000);
            }
                
            if (File.Exists(path))
            {
                try { File.Delete(path); } catch { MessageBox.Show("Fatal error, go to " + path);  Application.Exit(); }
            }


        }

        public static bool IsProcessRunningpath(string exePath)
        {
            // Get all processes on the local machine
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    // Compare the main module's file path to the specified path
                    if (process.MainModule.FileName.Equals(exePath, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Some processes may not have access to their MainModule, skip them
                    continue;
                }
            }

            return false;
        }
        public static bool IsProcessRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int r = 219;
        int g = 219;
        int b = 219;
        bool inv = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (r == 15 && g == 15 && b == 15)
            {
                inv = false;
            }
            if (r == 219 && g == 219 && b == 219)
            {
                inv = true;
            }
            if (inv)
            {
                r--;
                g--;
                b--;
                label1.ForeColor = Color.FromArgb(r, g, b);
                r--;
                g--;
                b--;
                label1.ForeColor = Color.FromArgb(r, g, b);
            }
            else
            {
                r++;
                g++;
                b++;
                label1.ForeColor = Color.FromArgb(r, g, b);
                r++;
                g++;
                b++;
                label1.ForeColor = Color.FromArgb(r, g, b);
            }
        }

 
    }
}
