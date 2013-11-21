using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    public partial class Settings : Form
    {
        private ParkingSceneSettings settings;

        public Settings(ParkingSceneSettings settings)
        {
            InitializeComponent();
            this.settings = settings;
            if (settings.Method == Method.Determined)
            {
                radioButton1.Checked = true;
                numericUpDown1.Value = settings.Interval;
            }
            else
            {
                radioButton2.Checked = true;
                if (settings.DistributionLaw == DistributionLaw.Normal)
                {
                    radioButton3.Checked = true;
                    numericUpDown5.Value = settings.M;
                    numericUpDown6.Value = settings.Sigma;
                }
                else if (settings.DistributionLaw == DistributionLaw.Exponential)
                {
                    radioButton4.Checked = true;
                    numericUpDown7.Value = settings.ExpA;
                    numericUpDown9.Value = settings.ExpB;
                    numericUpDown8.Value = (decimal)settings.Lambda;
                }
                else
                {
                    radioButton5.Checked = true;
                    numericUpDown3.Value = settings.UniformA;
                    numericUpDown4.Value = settings.UniformB;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if ((sender as RadioButton).Checked)
            {
                panel1.Enabled = true;
                groupBox3.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                panel1.Enabled = false;
                groupBox3.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                panel3.Enabled = true;
                panel4.Enabled = false;
                panel2.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                panel3.Enabled = false;
                panel4.Enabled = true;
                panel2.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                panel3.Enabled = false;
                panel4.Enabled = false;
                panel2.Enabled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            settings.CarSpeed = (int)numericUpDown2.Value;
            if (radioButton1.Checked)
            {
                settings.Interval = (int)numericUpDown1.Value;
                settings.Method = Method.Determined;
            }
            else
            {
                settings.Method = Method.Random;
                if (radioButton3.Checked)
                {
                    settings.DistributionLaw = DistributionLaw.Normal;
                    settings.M = (int)numericUpDown5.Value;
                    settings.Sigma = (int)numericUpDown6.Value;
                }
                else if (radioButton4.Checked)
                {
                    settings.DistributionLaw = DistributionLaw.Exponential;
                    settings.ExpA = (int)numericUpDown7.Value;
                    settings.ExpB = (int)numericUpDown9.Value;
                    settings.Lambda = (int)numericUpDown8.Value;
                }
                else
                {
                    settings.DistributionLaw = DistributionLaw.Uniform;
                    settings.UniformA = (int)numericUpDown3.Value;
                    settings.UniformB = (int)numericUpDown4.Value;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
