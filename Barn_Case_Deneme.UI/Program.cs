using System;
using System.Windows.Forms;
using Barn_Case_Deneme.UI;
using Barn_Case_Deneme.UI.Controls;

namespace Barn_Case_Deneme.UI
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        //[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Login loginForm = new Login();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Form1());
            }
        }
    }
}