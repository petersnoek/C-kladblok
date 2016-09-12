using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kladblok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetTitle(null);
            //Hide();
            //LoginForm f = new LoginForm();
            //DialogResult r = f.ShowDialog();
            //switch (r)
            //{
            //    case DialogResult.Cancel:
            //        Environment.Exit(0);
            //        //Application.Exit();
            //        break;
            //    case DialogResult.OK:
            //        var UserName = f.GetUserName();
            //        this.Show();
            //        break;
            //}

        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close the application and this form.
            Application.Exit();
        }

        private void nieuwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // maak de textbox leeg
            textBox1.Clear();

            // stel titel in op default
            SetTitle(null);
        }

        private void SetTitle(string newTitle)
        {
            if (newTitle == null)
            {
                newTitle = "Nieuw document";
            }
            this.Text = newTitle + " - C# Kladblok";
        }

        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();

            if ( r==DialogResult.OK)
            {
                try
                {
                    textBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                    string OnlyName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    SetTitle(OnlyName);

                }
                catch (Exception err)
                {
                    MessageBox.Show("Er is iets fout gegaan tijdens het laden van het bestand.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
