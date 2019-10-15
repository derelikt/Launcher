using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Launcher.libs;
namespace Launcher
{
    public partial class Login : Form
    {
        public Dictionary<string,object> connection;
        public Dictionary<string, object> profile;
        public string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.t2l\";
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Login button clicked");
            if (userTextBox.Text != null && passwordTextBox.Text != null)
            {
                if (userTextBox.Text != "" && passwordTextBox.Text != "")
                {
                    Console.WriteLine("Trying login");
                    Authentication login = new Authentication();
                    login.login(userTextBox.Text, passwordTextBox.Text);
                    this.connection = login.connection;
                    this.profile = login.profile;
                    if (connection.ContainsKey("Error"))
                    {
                        statusLabel.Text = connection["Error"].ToString();
                        userTextBox.Text = "";
                        passwordTextBox.Text = "";
                    }
                    else
                    {
                        if (rememberCheckBox.Checked)
                        {
                            login.saveProfile(rootPath,login.rawData);
                        }
                        this.Close();
                    }
                }
                else
                {
                    statusLabel.Text = "Please enter a username and password";
                    Console.WriteLine("Please enter a username and password");
                    Refresh();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
