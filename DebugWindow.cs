using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Launcher
{
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {
            this.debugBox.Size = this.Size;
        }

        public void debuggerWindow(string input)
        {
            this.debugBox.AppendText(input);
        }
    }
}
