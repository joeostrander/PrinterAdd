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
        private DateTime lastMessage;

        public delegate void AddListViewItemCallback(ListView lv, ListViewItem lvi);
        public delegate void DeleteListViewItemCallback(ListView lv, ListViewItem lvi);
        public delegate void CleanupInstalledPrintersCallback();
        

        private List<String> listInstalledprinters = new List<string>();


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
            ColorLines(listViewSearchResults, false);
        } 
        
        private void search() {

            buttonSearch.Enabled = false;
            listViewSearchResults.Items.Clear();

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
                    String driverName = "";
                    String uncname = "";

                    if ((result.Properties.Contains("printername")) && (result.Properties.Contains("uncname")))
                    {
                        printername = result.Properties["printername"][0].ToString();

                        if (result.Properties.Contains("location"))
                            location = result.Properties["location"][0].ToString();

                        if (result.Properties.Contains("driverName"))
                            driverName = result.Properties["driverName"][0].ToString();

                        uncname = result.Properties["uncname"][0].ToString();
                        
                        ListViewItem lvi = new ListViewItem(printername);
                        lvi.SubItems.Add(location);
                        lvi.SubItems.Add(driverName);
                        lvi.SubItems.Add(uncname);

                        listViewSearchResults.Items.Add(lvi);
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
            lastMessage = DateTime.Now.AddHours(-1);
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

        private void listViewSearchResults_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("ONE");
            if (listViewSearchResults.SelectedItems.Count < 1)
            {
                return;
            }
            String pName = listViewSearchResults.SelectedItems[0].SubItems[GetColumnIndex(listViewSearchResults,"Printer")].Text;
            String pUNC = listViewSearchResults.SelectedItems[0].SubItems[GetColumnIndex(listViewSearchResults, "UNC")].Text;
            Console.WriteLine("TWO {0},{1}", pName, pUNC);
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

            if (listViewSearchResults.SelectedItems.Count > 0)
            {
                ListView.SelectedListViewItemCollection colItems = listViewSearchResults.SelectedItems;

                foreach (ListViewItem lvi in colItems) {
                    String pName = lvi.SubItems[GetColumnIndex(listViewSearchResults,"Printer")].Text;
                    String pUNC = lvi.SubItems[GetColumnIndex(listViewSearchResults, "UNC")].Text;
                    Console.WriteLine("{0},{1}", pName, pUNC);
                    if ((!string.IsNullOrEmpty(pName)) && (!string.IsNullOrEmpty(pUNC)))
                    {
                        Console.WriteLine(pName + "..." + pUNC);
                        addPrinter(pName,pUNC);
                    }
                }


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts;
            ts = DateTime.Now - lastMessage;
            if (ts.TotalSeconds >= 2)
            {
                GetPrintersAsync();
            }
                
        }

        private async Task GetPrintersAsync()
        {
            await Task.Run(() => getInstalledPrinters());
            lastMessage = DateTime.Now;
        }

        private void getInstalledPrinters()
        {
            
             // Use the ObjectQuery to get the list of configured printers
            System.Management.ObjectQuery oquery =
                new System.Management.ObjectQuery("SELECT * FROM Win32_Printer");
 
            System.Management.ManagementObjectSearcher mosearcher =
                new System.Management.ManagementObjectSearcher(oquery);
 
            System.Management.ManagementObjectCollection moc = mosearcher.Get();
            Console.WriteLine(new String('*', 20));

            listInstalledprinters.Clear();


            foreach (ManagementObject mo in moc)
            {
                
                if ((bool)mo["Network"])
                {
                    System.Management.PropertyDataCollection pdc = mo.Properties;
                    //Console.WriteLine(pdc["DeviceID"].Value);
                    String printerName = (string)pdc["ShareName"].Value;
                    String location = (string)pdc["Location"].Value;
                    String driverName = (string)pdc["DriverName"].Value;
                    String unc = (string)pdc["Name"].Value;

                    listInstalledprinters.Add(unc);

                    ListViewItem lvi = new ListViewItem(printerName);
                    lvi.SubItems.Add(location);
                    lvi.SubItems.Add(driverName);
                    lvi.SubItems.Add(unc);
                    lvi.Name = unc; // <-- key

                    if (listViewInstalledPrinters.InvokeRequired)
                    {
                        listViewInstalledPrinters.Invoke(new AddListViewItemCallback(ListViewAdd), new object[] { listViewInstalledPrinters, lvi });
                    }
                    else
                    {
                        ListViewAdd(listViewInstalledPrinters, lvi);

                    }
                    

                    /*
                    foreach (System.Management.PropertyData pd in pdc)
                    {
                      Console.WriteLine("{0} = {1}", pd.Name, mo[pd.Name]);
                    }
                    */
                    
                }
                
            }



            
            if (listViewInstalledPrinters.InvokeRequired)
            {
                listViewInstalledPrinters.Invoke(new CleanupInstalledPrintersCallback(CleanupInstalledPrinters));
            }
            else
            {
                CleanupInstalledPrinters();

            }
            

           
            


        }

        private void CleanupInstalledPrinters()
        {
            //remove any that have been uninstalled
            foreach (ListViewItem lvi in listViewInstalledPrinters.Items)
            {
                if (!listInstalledprinters.Contains(lvi.Name))
                {
                    listViewInstalledPrinters.Items.Remove(lvi);
                }
            }
        }

        

        public void ListViewAdd(ListView lv, ListViewItem lvi)
        {


            //see if it's in the view first...
            if (lv.Items.ContainsKey(lvi.Name)) {
                return;
            }

            Console.WriteLine("ADDING...");

            lv.Items.Add(lvi);
            //lv.Items[lv.Items.Count - 1].EnsureVisible();
            ColorLines(lv,false);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (listViewInstalledPrinters.SelectedItems.Count > 0)
            {
                ListView.SelectedListViewItemCollection colItems = listViewInstalledPrinters.SelectedItems;

                foreach (ListViewItem lvi in colItems) {
                    String pName = lvi.SubItems[GetColumnIndex(listViewInstalledPrinters,"Printer")].Text;
                    String pUNC = lvi.SubItems[GetColumnIndex(listViewInstalledPrinters, "UNC")].Text;
                    if ((!string.IsNullOrEmpty(pName)) && (!string.IsNullOrEmpty(pUNC)))
                    {
                        Console.WriteLine("delete:  " + pName + "..." + pUNC);
                        deletePrinter(pName,pUNC);
                    }
                }


            }

        }

        private int GetColumnIndex(ListView lvi, string strColumnTitle)
        {
            foreach (ColumnHeader col in lvi.Columns)
            {
                if (col.Text == strColumnTitle)
                {
                    return col.Index;
                }
            }
            return 9999;
        }

        private void deletePrinter(String pName,String pUNC)
        {
            if (!isPrinterInstalled(pUNC))
            {
                textBoxStatus.Text += "\r\n\r\n" + pName + " is not installed.";
                textBoxStatus.SelectionStart = textBoxStatus.TextLength;
                textBoxStatus.ScrollToCaret();
                return;
            }
            
            try
            {

                textBoxStatus.Text += "\r\n\r\nUninstalling printer " + pName + "...";
                textBoxStatus.SelectionStart = textBoxStatus.TextLength;
                textBoxStatus.ScrollToCaret();
                string arg = "printui.dll PrintUIEntry /dn /n" + pUNC;

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

                if (!isPrinterInstalled(pUNC))
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
                textBoxStatus.Text += "Error uninstalling printer:  " + pName + "\r\n" + ex.Message + "\r\n\r\n";
            }
            textBoxStatus.SelectionStart = textBoxStatus.TextLength;
            textBoxStatus.ScrollToCaret();
        }


        private void ColorLines(ListView lv, Boolean boolRenumber)
        {
            int count = 0;
            foreach (ListViewItem line in lv.Items)
            {
                count += 1;

                
                if (boolRenumber)
                {
                    line.SubItems[0].Text = count.ToString();
                }
                

                if (count % 2 == 0)
                {
                    line.BackColor = Color.OldLace;
                }
                else
                {
                    line.BackColor = Color.White;
                }

                line.ForeColor = Color.Black;

            }
        }


    }
}
