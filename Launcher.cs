using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Launcher.libs;
using Newtonsoft.Json;
namespace Launcher
{
    
    public partial class Launcher : Form
    {
        public Dictionary<string, object> session;
        public Dictionary<string, object> profile;
        public Dictionary<string, object>[] modPack = new Dictionary<string, object>[100];
        public int numberOfModPacks = 0;
        public ComboboxItem modPackSelect = new ComboboxItem();
        public bool loggedIn = false;
        public bool dragging = false;
        public int mouseLocationX = 0;
        public int mouseLocationY = 0;
        public string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.t2l\";
        public string modPackPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.t2l\modpacks\";
        public string selectedVersion;
        public List<string> versions;
        public Launcher()
        {   
            InitializeComponent();
        }
        
        private void Launcher_Load(object sender, EventArgs e)
        {
            Authentication authorize = new Authentication();
            if (authorize.loadProfile(rootPath))
            {
                if (authorize.validate())
                {
                    Console.WriteLine("Session Validated Successfully");
                    this.session = authorize.connection;
                    this.profile = authorize.profile;
                    welcomeLabel.Text = "Welcome " + profile["name"];
                    LaunchButton.Text = "Launch";
                    Console.WriteLine("Access Token = " + this.session["accessToken"]);
                }
                else
                {
                    Console.WriteLine("Session did not validate succefully, refreshing session");
                    if (authorize.refreshSession())
                    {
                        Console.WriteLine("Session Refreshed Successfully");
                        authorize.saveProfile(rootPath, authorize.rawData);
                    }
                    else
                    {
                        Console.WriteLine("Profile loading failed, you must log in again!");
                    }
                }
            }
            loadModpacks();
        }

        private void loadModpacks()
        {
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            
            WebClient client = new WebClient();
            client.DownloadFile("http://www.tech2logic.com/launcher1234/modpacks/modpacks.json", rootPath + "modpacks.json");
            Dictionary<string, object> modPacksFile;
            Dictionary<string, object> modPacks;
            StreamReader modpacks = new StreamReader(rootPath + "modpacks.json");
            string modPackData = modpacks.ReadToEnd();
            modpacks.Close();
            modPacksFile = JsonConvert.DeserializeObject<Dictionary<string, object>>(modPackData);
            Console.WriteLine(modPacksFile["modpacks"]);
            modPacks = JsonConvert.DeserializeObject<Dictionary<string, object>>(modPacksFile["modpacks"].ToString());
            int n = 0;
            this.ModPackComboBox.DisplayMember = "Text";
            this.ModPackComboBox.ValueMember = "Value";

            while (modPacks.ContainsKey((n + 1).ToString()))
            {
                Console.WriteLine("tick " + n);
                Console.WriteLine(modPacks[(n + 1).ToString()]);
                this.modPack[n] = JsonConvert.DeserializeObject<Dictionary<string, object>>(modPacks[(n + 1).ToString()].ToString());
                Console.WriteLine(this.modPack[n]["name"]);
                this.ModPackComboBox.Items.Add(new { Text = this.modPack[n]["name"], Value = n.ToString() });
                n++;
                Console.WriteLine("tick " + n);

            }
            this.ModPackComboBox.SelectedIndex = 0;
            
            getVersions(this.ModPackComboBox.SelectedIndex);
        }
        private void getVersions(int index)
        {
            if(!Directory.Exists(this.modPackPath + this.modPack[index]["gamePath"].ToString()))
            {
                Directory.CreateDirectory(this.modPackPath + this.modPack[index]["gamePath"].ToString());
            }
            WebClient client = new WebClient();
            Console.WriteLine(this.modPack[index]["location"].ToString() + this.modPack[index]["versions"].ToString());
            Console.WriteLine(this.modPackPath + this.modPack[index]["gamePath"].ToString() + @"\" + this.modPack[index]["versions"].ToString());
            try
            {
                client.DownloadFile(this.modPack[index]["location"].ToString() + this.modPack[index]["versions"].ToString(), this.modPackPath + this.modPack[index]["gamePath"].ToString() + @"\" + this.modPack[index]["versions"].ToString());
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
            }
            StreamReader theFile = new StreamReader(this.modPackPath + this.modPack[index]["gamePath"].ToString() + @"\" + this.modPack[index]["versions"].ToString());
            string versionFile = theFile.ReadToEnd();
            theFile.Close();
            Dictionary<string, object> versionData = JsonConvert.DeserializeObject<Dictionary<string, object>>(versionFile);
            this.versions = JsonConvert.DeserializeObject<List<string>>(versionData["versions"].ToString());
            this.selectedVersion = this.versions.LastOrDefault();
            Console.WriteLine("Version " + this.selectedVersion + " selected");
        }
        private bool loadProfile()
        {
            try
            {
                StreamReader profileStream = new StreamReader(rootPath + "profile.json");
                string jsonData = profileStream.ReadToEnd();
                profileStream.Close();
                Authentication auth = new Authentication();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if (LaunchButton.Text == "Login")
            {
                Login loginform = new Login();
                loginform.ShowDialog();
                if (loginform.connection != null)
                {
                    if (loginform.connection.ContainsKey("accessToken"))
                    {
                        this.session = loginform.connection;
                        this.profile = loginform.profile;
                        welcomeLabel.Text = "Welcome " + profile["name"];
                        LaunchButton.Text = "Launch";
                        Console.WriteLine("Access Token = " + this.session["accessToken"]);
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                WebClient client = new WebClient();
                Console.WriteLine(this.modPack[this.ModPackComboBox.SelectedIndex]["location"] + selectedVersion + "filelist.json");
                client.DownloadFile(this.modPack[this.ModPackComboBox.SelectedIndex]["location"] + selectedVersion + "/filelist.json", this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString() + @"\filelist.json");
                downloadPack(this.ModPackComboBox.SelectedIndex);
                Console.WriteLine(this.ModPackComboBox.SelectedIndex);
                Console.WriteLine(this.modPack[this.ModPackComboBox.SelectedIndex]["name"]);
                this.Hide();
                Launch minecraft = new Launch();
                minecraft.startMinecraft(true, 512, 1048, profile["name"].ToString(), session["accessToken"].ToString(), false, this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString() + @"\", this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["execPath"].ToString(), this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["nativesPath"].ToString(), this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["librariesPath"].ToString(), this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["assetsPath"].ToString(), this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString());
                this.Show();
            }
        }

        private void downloadPack(int index)
        {
            WebClient client = new WebClient();
            StreamReader theFile = new StreamReader(this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString() + @"\filelist.json");
            string fileData = theFile.ReadToEnd();
            theFile.Close();
            Dictionary<string, object> files = JsonConvert.DeserializeObject<Dictionary<string, object>>(fileData);
            List<string> folderList = JsonConvert.DeserializeObject<List<string>>(files["Folders"].ToString());
            foreach (string folder in folderList)
            {
                if (!Directory.Exists(this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString() + @"\" + folder))
                {
                    Directory.CreateDirectory(this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString() + @"\" + folder);
                }
            }
            List<string> fileList = JsonConvert.DeserializeObject<List<string>>(files["Files"].ToString());
            this.fileProgress.Maximum = fileList.Count;
            foreach (string file in fileList)
            {
                if(!File.Exists(this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString() + @"\" + file))
                {
                    try
                    {
                        this.dlProgress.Text = "Downloading " + file;
                        this.Refresh();
                        client.DownloadFile(this.modPack[this.ModPackComboBox.SelectedIndex]["location"] + selectedVersion + "/" + file, this.modPackPath + this.modPack[this.ModPackComboBox.SelectedIndex]["gamePath"].ToString() + @"\" + file);
                    }
                    catch
                    {

                    }
                }
                this.fileProgress.Increment(1);
                this.dlProgress.Text = "Done";
            }
        }
        private void titlebar_mouseDown(object sender, MouseEventArgs e)
        {
            this.dragging = true;
            this.mouseLocationX = e.X;
            this.mouseLocationY = e.Y;
        }

        private void titlebar_dragWindow(object sender, MouseEventArgs e)
        {
            if (this.dragging)
            {
                int xTrans = e.X + this.Location.X;
                int yTrans = e.Y + this.Location.Y;
                this.SetDesktopLocation(xTrans - mouseLocationX, yTrans - mouseLocationY);
            }
        }

        private void titlebar_mouseUp(object sender, MouseEventArgs e)
        {
            this.dragging = false;
        }

        private void modPackChanged(object sender, EventArgs e)
        {
            getVersions(ModPackComboBox.SelectedIndex);
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            welcomeLabel.Text = "Welcome Guest";
            LaunchButton.Text = "Login";
        }
    }
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
