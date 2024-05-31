using System;
using System.Management;
using System.Windows.Forms;


namespace Project_X
{
    public partial class Loader : Form
    {

        public Loader()
        {
            InitializeComponent();

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
    
            if (CheckAntivirusStatus() == true)
            {
                MessageBox.Show("Real Time protection is on, turn it off before starting...", "Error",MessageBoxButtons.OK );
                Application.Exit();
            }
            Random random = new Random();
            double delayInSeconds = random.NextDouble() * (10.0 - 3.0) + 3.0;
            await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
            this.Hide();
            Form2 frm = new Form2();
            frm.Show();
        }
        private static bool CheckAntivirusStatus()
        {
            try
            {
                // Connect to the root\SecurityCenter2 namespace on the local machine
                ManagementScope scope = new ManagementScope(@"\\.\root\SecurityCenter2");
                scope.Connect();

                // Query the AntiVirusProduct class
                ObjectQuery query = new ObjectQuery("SELECT * FROM AntiVirusProduct");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection = searcher.Get();

                foreach (ManagementObject mObject in queryCollection)
                {
                    // Check if the productState is available
                    if (mObject["productState"] != null)
                    {
                        uint productState = (uint)mObject["productState"];


                        // Active: 397568 (binary: 110000100000000000)
                        // Disabled: 401664 (binary: 110001000000000000)

                        if (productState == 401664)
                        {

                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fatal", "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
