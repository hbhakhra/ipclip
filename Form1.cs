using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace IpClip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            String strHostName = Dns.GetHostName();
            String ip = null;
            Console.WriteLine("Local Machine's Host Name: " + strHostName);
            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            foreach (var addr in ipEntry.AddressList) {
                if (!addr.AddressFamily.ToString().ToLower().EndsWith("v6"))
                {
                    ip = addr.ToString();
                    break;
                }
            }

            if (ip != null)
            {
                if (MessageBox.Show("IP Address: " + ip + " \r\n\r\nCopy to clipboard?", "IP Clip [msanjay.in]",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Clipboard.SetData(DataFormats.Text, ip);
                }
            }
            else
            {
                MessageBox.Show("IP Address not obtained", "IP Clip [msanjay.in]",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.Close(); 
        }
    }
}
