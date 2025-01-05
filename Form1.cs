using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cxapi;
using Newtonsoft.Json;
using CefSharp;
using CefSharp.DevTools.FileSystem;
using System.IO;
using Directory = System.IO.Directory;
using File = System.IO.File;
using System.Diagnostics;

namespace GFsploit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            try
            {
                await Editor.EnsureCoreWebView2Async(null);
                Editor.CoreWebView2.Navigate(new Uri($"file:///{Directory.GetCurrentDirectory()}/Editor/index.html").ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Executor.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ScriptHub.BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
 
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Settings.BringToFront();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!CoreFunctions.IsInjected())
            {
                CoreFunctions.Inject(false);





                MessageBox.Show("Успешно! Приятной игры ;D (( by forword ))", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Что то не так. Попробуйте перезапустить роблокс. (( by forword ))", "Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            string scriptToExecute = await Editor.ExecuteScriptAsync("GetText();");
            string rawScript = JsonConvert.DeserializeObject<string>(scriptToExecute);
            CoreFunctions.ExecuteScript(rawScript);
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            await Editor.ExecuteScriptAsync($"SetText(``);");
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "Lua Files (*.lua)|*.lua|Text Files (*.txt)|*.txt",
                    DefaultExt = "lua",
                    Title = "Save Lua or Text File"
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string textToSave = await Editor.ExecuteScriptAsync("GetText();");
                    string rawText = JsonConvert.DeserializeObject<string>(textToSave);
                    File.WriteAllText(saveFileDialog1.FileName, rawText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Txt Files (*.txt)|*.txt|Lua Files (*.lua)|*.lua|All Files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string script = File.ReadAllText(dialog.FileName);
                await Editor.CoreWebView2.ExecuteScriptAsync($"editor.setValue(`{script}`)");
            }
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox1.Checked)
            {

                this.TopMost = true;

            }
            else
            {

                this.TopMost = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomCheckBox2_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox2.Checked)
            {
                CoreFunctions.SetAutoInject(true);

            }
            else
            {
                CoreFunctions.SetAutoInject(false);

            }
        }

        private void guna2CustomCheckBox3_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox3.Checked)
            {

                this.Opacity = 0.99;
            }
            else
            {

                this.Opacity = 1.0;
            }
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            if (CoreFunctions.IsRobloxOpen())
            {
                CoreFunctions.KillRoblox();

            }
            else
            {
                //потом епт
            }
        }

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            string url = "https://discord.gg/fSvh85qzQX";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
