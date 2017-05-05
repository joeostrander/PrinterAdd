using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace PrinterAdd
{
    public partial class Form1 : Form
    {

        public class NetworkPrinter
        {
            public string Name { get; set; }
            public string Server { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            search();
        } 
        
        private void search() {

            buttonSearch.Enabled = false;
            listView1.Items.Clear();

            DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
            String defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();
            DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + defaultNamingContext);

            String sortField = "printername";
            if (radioButtonPrinterLocation.Checked) {
                sortField = "location";
            }
            SortOption sortOption = new SortOption(sortField,SortDirection.Ascending);

            DirectorySearcher searcher = new DirectorySearcher(searchRoot);
            

            string filter = "";

            if (radioButtonPrinterName.Checked)
            {
                filter = "(&(objectcategory=printqueue)(printername=*" + textBox1.Text + "*))";
            }
            else 
            {
                filter = "(&(objectcategory=printqueue)(location=*" + textBox1.Text + "*))";
            }

            searcher.ReferralChasing = ReferralChasingOption.All;
            searcher.PageSize = 1000;
            searcher.Filter = filter;
            searcher.SearchScope = SearchScope.Subtree;
            searcher.Sort = sortOption;
            
            try
            {
                SearchResultCollection colResults = searcher.FindAll();

                foreach (SearchResult result in colResults)
                {
                    String printername = "";
                    String location = "";
                    String uncname = "";

                    if ((result.Properties.Contains("printername")) && (result.Properties.Contains("uncname")))
                    {
                        printername = result.Properties["printername"][0].ToString();

                        if (result.Properties.Contains("location"))
                            location = result.Properties["location"][0].ToString();

                       uncname = result.Properties["uncname"][0].ToString();
                        
                        ListViewItem lvi = new ListViewItem(printername);
                        lvi.SubItems.Add(location);
                        lvi.SubItems.Add(uncname);

                        listView1.Items.Add(lvi);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            finally {
                buttonSearch.Enabled = true;
            }

            

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            
        }

        private bool isPrinterInstalled(string strUNC) {

            Debug.WriteLine(strUNC);
            NetworkPrinter myPrinter = getNetworkPrinter(strUNC);
 
            ManagementObjectSearcher printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer Where Network = True");
                       

            if (string.IsNullOrEmpty(myPrinter.Name) || string.IsNullOrEmpty(myPrinter.Server))
            {
                return false;
            }

            ManagementObjectCollection colPrinters = printerQuery.Get();

            foreach (ManagementObject printer in colPrinters)
            {
                //Name property is a UNC
                String tmpUNC = printer.Properties["Name"].Value.ToString();

                NetworkPrinter testPrinter = getNetworkPrinter(tmpUNC);
                
                Debug.WriteLine("?..." + testPrinter.Name + "..." + testPrinter.Server);
                if (testPrinter.Name.ToLower() == myPrinter.Name.ToLower())
                {
                    if (testPrinter.Server.ToLower() == myPrinter.Server.ToLower())
                    {
                        return true;
                    }
                }
            }

            //not found?  return false
            return false;
        }

        private NetworkPrinter getNetworkPrinter(String unc) {
            String pattern = @"^\\\\(?<serverName>[^\\\.]+).*?\\(?<printerName>\w+)";
            
            Regex rgx = new Regex(pattern);
            
            MatchCollection matches = Regex.Matches(unc, pattern);
            
            NetworkPrinter tmpPrinter = new NetworkPrinter();
            
            foreach (Match mtch in matches)
            {
                tmpPrinter.Name = mtch.Groups["printerName"].ToString();
                tmpPrinter.Server = mtch.Groups["serverName"].ToString();
            }

            return tmpPrinter;

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();            
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count < 1)
            {
                return;
            }
            String pName = listView1.SelectedItems[0].SubItems[0].Text;
            String pUNC = listView1.SelectedItems[0].SubItems[2].Text;
            addPrinter(pName, pUNC);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addPrinter(String pName,String pUNC)
        {
            if (isPrinterInstalled(pUNC))
            {
                textBoxStatus.Text += "\r\n\r\n" + pName + " is already installed.";
                textBoxStatus.SelectionStart = textBoxStatus.TextLength;
                textBoxStatus.ScrollToCaret();
                return;
            }
            
            try
            {

                textBoxStatus.Text += "\r\n\r\nAdding printer " + pName + "...";
                textBoxStatus.SelectionStart = textBoxStatus.TextLength;
                textBoxStatus.ScrollToCaret();
                string arg = "printui.dll PrintUIEntry /in /n" + pUNC;

                var process = new Process
                {
                    
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "rundll32.exe",
                        Arguments = arg
                    }
                };
                process.Start();
                process.WaitForExit();


                //System.Diagnostics.Process.Start("rundll32.exe", arg);

                if (isPrinterInstalled(pUNC))
                {
                    textBoxStatus.Text += "Success!\r\n";
                }
                else
                {
                    textBoxStatus.Text += "FAILED!\r\n";
                }


         
            }
            catch (Exception ex)
            {
                textBoxStatus.Text += "Error adding printer:  " + pName + "\r\n" + ex.Message + "\r\n\r\n";
            }
            textBoxStatus.SelectionStart = textBoxStatus.TextLength;
            textBoxStatus.ScrollToCaret();
        }

        private void addSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                ListView.SelectedListViewItemCollection colItems = listView1.SelectedItems;

                foreach (ListViewItem lvi in colItems) {
                    String pName = lvi.SubItems[0].Text;
                    String pUNC = lvi.SubItems[2].Text;
                    if ((!string.IsNullOrEmpty(pName)) && (!string.IsNullOrEmpty(pUNC)))
                    {
                        Debug.WriteLine(pName + "..." + pUNC);
                        addPrinter(pName,pUNC);
                    }
                }


            }
        }


    }
}
