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
        string FilenameWithPath = "";
        
        public Form1()
        {
            InitializeComponent();
            SetTitle();
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

            // stel titel in op "leeg" (we beginnen namelijk aan een nieuw document)
            this.FilenameWithPath = "";

            // en ververs de titelbalk
            SetTitle();
            
        }

        private void SetTitle()
        {
            if (FilenameWithPath == null | FilenameWithPath == "")
            {
                this.Text = "Nieuw document - C# Kladblok";
            }
            else
            {
                string OnlyFilename = System.IO.Path.GetFileNameWithoutExtension(FilenameWithPath);
                this.Text = OnlyFilename + " - C# Kladblok";
            }
        }

        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // toon het OpenFileDialog venster en wacht tot gebruiken reageert
            DialogResult r = openFileDialog1.ShowDialog();

            // heeft de gebruiker een file geselecteerd? dan is het resultaat OK
            if ( r==DialogResult.OK)
            {
                try
                {
                    // vraag het OpenFileDialog venster om het pad en filename 
                    this.FilenameWithPath = openFileDialog1.FileName;

                    // ververs de titelbalk want het geopende bestand is hierboven gewijzigd
                    SetTitle();

                    // lees alle regels in en stop dat in het tekstvak
                    textBox1.Text = System.IO.File.ReadAllText(FilenameWithPath);
                    
                }
                // ging er iets fout? dan komt er een exception. Die handel ik hieronder af
                // door een foutmelding te tonen.
                catch (Exception err)
                {
                    MessageBox.Show("Er is iets fout gegaan tijdens het laden van het bestand.", 
                        "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void opslaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // is er al een bestaande filename? dan bevat this.Filename een tekst
            if ( this.FilenameWithPath == "" )
            {
                // vraag om een filename
                DialogResult r = saveFileDialog1.ShowDialog();
                if ( r == DialogResult.OK)
                {
                    this.FilenameWithPath = saveFileDialog1.FileName;
                }
                else
                {
                    // gebruiker heeft de "opslaan" dialoog geannuleerd. Stop.
                    return;
                }
            }

            // sla alle regels uit textbox1 op in het gekozen bestand.
            System.IO.File.WriteAllText(this.FilenameWithPath, textBox1.Text);
            SetTitle();

        }
    }
}
