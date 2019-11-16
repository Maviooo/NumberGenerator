using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NumberGenerator
{
    


    public partial class Form1 : Form
    {
        Boolean dodZera = false;
        
        public Form1()
        {
            InitializeComponent();
            Refresh_Form();
        }
        public void Refresh_Form()
        {
            decimal pocz = numericUpDown1.Value;/// zamienic na decimal
            decimal kon = numericUpDown2.Value;
            decimal skok = numericUpDown4.Value;
            bool zera = checkBox1.Checked;
            bool dodzera = checkBox2.Checked;
            int dodzeraw;
            if (dodzera)
            {
                dodzeraw = Convert.ToInt32(numericUpDown3.Value);
            }
            else
            {
                dodzeraw = 0;
            }
            bool pre = checkBox3.Checked;
            string pref = textBox2.Text;
            bool suf = checkBox4.Checked;
            string suff = textBox3.Text;
            

            Class1 class1 = new Class1();
            string[] przyklady = new string[6];
            int il = decimal.ToInt32(((kon - pocz) / skok) + 1);
            przyklady = class1.Generacja_Str(pocz,kon,skok,zera,dodzera,dodzeraw,pre,pref,suf,suff);
            textBox1.Clear();
            for(int i =0;i<3;i++)
            {
                textBox1.AppendLine(przyklady[i]);
            }
            if (il >= 4)
            {
                
                if (il == 4)
                {
                    textBox1.AppendLine(przyklady[5]);
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                }
                if (il == 5)
                {
                    textBox1.AppendLine(przyklady[4]);
                    textBox1.AppendLine(przyklady[5]);
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                }
                if (il ==6)
                {
                    textBox1.AppendLine(przyklady[3]);
                    textBox1.AppendLine(przyklady[4]);
                    textBox1.AppendLine(przyklady[5]);
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                }
                if(il==7)
                {
                    textBox1.AppendLine(".");
                    textBox1.AppendLine(przyklady[3]);
                    textBox1.AppendLine(przyklady[4]);
                    textBox1.AppendLine(przyklady[5]);
                    textBox1.AppendLine("");
                    textBox1.AppendLine("");
                }
                if(il==8)
                {
                    textBox1.AppendLine(".");
                    textBox1.AppendLine(".");
                    textBox1.AppendLine(przyklady[3]);
                    textBox1.AppendLine(przyklady[4]);
                    textBox1.AppendLine(przyklady[5]);
                    textBox1.AppendLine("");
                }
                if (il > 8)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        textBox1.AppendLine(".");
                    }
                    textBox1.AppendLine(przyklady[3]);
                    textBox1.AppendLine(przyklady[4]);
                    textBox1.AppendLine(przyklady[5]);
                }

            }
            else
            {
                for(int i=0;i<6;i++)
                    textBox1.AppendLine("");
            }

            textBox1.AppendLine("");
            textBox1.AppendLine("");

            string iloscrekordow = "Ilość rekordów :";
            iloscrekordow += il;
            textBox1.AppendLine(iloscrekordow);

        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)  /// zera wiodące
        {
            Refresh_Form();
            if (checkBox1.Checked && !checkBox3.Checked)
            {
                
                checkBox2.Enabled = true;
            }
            else
            {
                checkBox2.Enabled = false;
                checkBox2.Checked = false;

            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e) /// dodatkowe zera 
        {
            Refresh_Form();
            if (checkBox2.Checked)
            {
                numericUpDown3.Enabled = true;
                dodZera = true;
            }
            else
            {
                numericUpDown3.Enabled = false;
                dodZera = false;
                numericUpDown3.Value = numericUpDown5.Minimum;
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e) /// sufix
        {
            Refresh_Form();
            if (checkBox4.Checked)
                textBox3.Enabled = true;
            else
                textBox3.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) /// prefix
        {
            Refresh_Form();
            if (checkBox3.Checked) ///  O N
            {
                textBox2.Enabled = true;
                if(dodZera)
                {
                    checkBox2.Checked = false;
                    checkBox2.Enabled = false;
                    dodZera = true;
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        checkBox2.Checked = false;
                        checkBox2.Enabled = false;
                    }
                }
                
                
            }
            else ///    O F F
            {
                textBox2.Enabled = false;
                if(dodZera)
                {
                    if (checkBox1.Checked)
                    {
                        checkBox2.Enabled = true;
                        numericUpDown3.Enabled = true;
                        checkBox2.Checked = true;
                    }
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        checkBox2.Enabled = true;
                        numericUpDown3.Enabled = true;
                        checkBox2.Checked = false;
                    }
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e) /// Dzielenie na pliki
        {
            ///Refresh_Form();
            if (checkBox5.Checked)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;

            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;   
                radioButton2.Checked = false;
                radioButton1.Checked = false;
                numericUpDown5.Enabled = false;
                numericUpDown6.Enabled = false;
     
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ///Refresh_Form();
            if (radioButton1.Checked)
            {
                numericUpDown6.Enabled = false;
                numericUpDown6.Value = numericUpDown6.Minimum;
                numericUpDown5.Enabled = true;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           /// Refresh_Form();
            if (radioButton2.Checked)
            {
                numericUpDown5.Enabled = false;
                numericUpDown5.Value = numericUpDown5.Minimum;
                numericUpDown6.Enabled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal pocz = numericUpDown1.Value;/// zamienic na decimal
            decimal kon = numericUpDown2.Value;
            decimal skok = numericUpDown4.Value;
            bool zera = checkBox1.Checked;
            bool dodzera = checkBox2.Checked;
            int dodzeraw;
            if (dodzera)
            {
                dodzeraw = Convert.ToInt32(numericUpDown3.Value);
            }
            else
            {
                dodzeraw = 0;
            }
            bool pre = checkBox3.Checked;
            string pref = textBox2.Text;
            bool suf = checkBox4.Checked;
            string suff = textBox3.Text;

            bool dod = checkBox5.Checked;
            bool wplikow = radioButton1.Checked;
            int pliki = Convert.ToInt32(numericUpDown5.Value);
            bool wrecodow = radioButton2.Checked;
            int recordy = Convert.ToInt32(numericUpDown6.Value);
            Class1 class1 = new Class1();
            if (pocz <= kon)
            {
                if (dod)
                    class1.Gneracja_dzielona(pocz, kon, skok, zera, dodZera, dodzeraw, pre, pref, suf, suff, wplikow, pliki, wrecodow, recordy);
                else
                    class1.Generacja(pocz, kon, skok, zera, dodZera, dodzeraw, pre, pref, suf, suff);
                
                MessageBox.Show("Generowanie liczb zakończone powodzneiem!");
            }
            else
                MessageBox.Show("Podany zakres liczb jest nieprawidłlowy!");

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Refresh_Form();
            decimal pocz = numericUpDown1.Value;
            decimal kon = numericUpDown2.Value;
            if (pocz > kon)
                textBox1.Text = "Podany zakres liczb jest nieprawidłlowy!";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Refresh_Form();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Refresh_Form();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Refresh_Form();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Refresh_Form();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Refresh_Form();
        }
    }
    public static class WinFormsExtensions
    {
        public static void AppendLine(this TextBox source, string value)
        {
            if (source.Text.Length == 0)
                source.Text = value;
            else
                source.AppendText("\r\n" + value);
        }
    }
}
